using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class LeaveController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly ILettersRepository _iletter;
        private readonly ILeaveRepository _ileave;
        private readonly UserManager<ApplicationUsers> _userManager;

        public LeaveController(IUnitOfWork db,
                                    ILettersRepository iletter,
                                            UserManager<ApplicationUsers> userManager,
                                                ILeaveRepository ileave)
        {
            _context = db;
            _iletter = iletter;
            _userManager = userManager;
            _ileave = ileave;
        }

        public IActionResult CreateLeave(string fromdate = "" , string todate = "")
        {
            ViewBag.fromdate = fromdate;
            ViewBag.todate = todate;
            if (fromdate == "" || fromdate == null)
            {
                fromdate = "1300/01/01";
            }
            if (todate == "" || todate == null)
            {
                todate = "1600/01/01";
            }
            //محاسبه انواع مرخصی های استفاده شده
            ViewBag.Estehghaghy = _ileave.GetUserLeave_Estehghaghi(_userManager.GetUserId(HttpContext.User),
                                                                   ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                                                                   ConvertDateTime.ConvertShamsiToMiladi(todate));
            ViewBag.Estelaji = _ileave.GetUserLeave_Estelaji(_userManager.GetUserId(HttpContext.User),
                                                              ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                                                              ConvertDateTime.ConvertShamsiToMiladi(todate));
            ViewBag.BiHoghugh = _ileave.GetUserLeave_BiHoghugh(_userManager.GetUserId(HttpContext.User),
                                                              ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                                                              ConvertDateTime.ConvertShamsiToMiladi(todate));
            ViewBag.Saati = _ileave.GetUserLeave_Saati(_userManager.GetUserId(HttpContext.User),
                                                              ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                                                              ConvertDateTime.ConvertShamsiToMiladi(todate));
            //
            ViewBag.JobIdList = JsonConvert.SerializeObject(_context.jobsChartUW.Get().Select(j => j.JobsChartID).ToList());
            TreeViewCreator();
            ViewBag.userJobId = _context.userJobUW.Get
              (u => u.UserID == _userManager.GetUserId(HttpContext.User) && u.IsHaveJob == true).Select(s => s.JobID).Single();
            return View();
        }

        private void TreeViewCreator()
        {
            List<TreeViewModel> node = new List<TreeViewModel>();

            node.Add(new TreeViewModel
            {
                id = "1",
                text = "مدیر عامل",
                parent = "#"
            });

            //foreach (JobsChart job in _context.jobsChartUW.Get(j => j.JobsChartLevel != 0))
            foreach (JobsChartWithUserInfoViewModel job in _iletter.JobsChartWithUserInfo())
            {
                node.Add(new TreeViewModel
                {
                    id = job.JobsChartID.ToString(),
                    parent = job.JobsChartLevel.ToString(),
                    text = job.JobsChartName + "(" + job.FirstName + " " + job.Family + ")"
                });
            }


            ViewBag.ReservedJobList =
               JsonConvert.SerializeObject(_context.userJobUW.Get(uj => uj.IsHaveJob == true).Select(uj => uj.JobID).ToList());

            ViewBag.JobJson = JsonConvert.SerializeObject(node);
        }

        [HttpPost]
        public IActionResult RequestLeave(CreateLeaveViewModel model, string SelectedUserToSent)
        {
            try
            {
                DateTime? FromTime = null;
                DateTime? ToTime = null;
                DateTime? FromDate = null;
                DateTime? ToDate = null;

                //کنترل اینکه کاربر تایید کننده مرخصی انتخاب شده باشد
                if (SelectedUserToSent == null)
                {
                    return Json(new { status = "noUserSelectedtoconfirm" });
                }
                List<TreeViewModel> items = JsonConvert.DeserializeObject<List<TreeViewModel>>(SelectedUserToSent);
                if (items.Count == 0)
                {
                    return Json(new { status = "noUserSelectedtoconfirm" });
                }
                if (items.Count > 1)
                {
                    return Json(new { status = "morethanoneconfirm" });
                }

                //کنترل صحت مرخصی ساعتی
                if (model.LeaveType == 1)
                {
                    model.FromDate_Day = null;
                    model.ToDate_Day = null;

                    if (model.FromTime_Saati == null || model.ToTime_Saati == null)
                    {
                        //اگر کاربر تاریخ شروع و تاریخ اتمام مرخصی ساعتی را وارد نکرده بود
                        return Json(new { status = "empty" });
                    }

                    FromTime = ConvertDateTime.ConvertShamsiToMiladi(model.FromTime_Saati);
                    ToTime = ConvertDateTime.ConvertShamsiToMiladi(model.ToTime_Saati);

                    if (FromTime.Value.Date != ToTime.Value.Date)
                    {
                        //کنترل اینکه تاریخ شروع و پایان مرخصی ساعتی در یک روز باشد
                        return Json(new { status = "datenotsimilar" });
                    }
                    if (FromTime > ToTime)
                    {
                        //کنترل اینکه ساعت شروع مرخصی از ساعت پایان بزرگتر نباشد
                        return Json(new { status = "frombiggerto" });
                    }
                }
                else
                {
                    model.FromTime_Saati = null;
                    model.ToTime_Saati = null;

                    if (model.FromDate_Day == null || model.ToDate_Day == null)
                    {
                        return Json(new { status = "empty" });
                    }
                    FromDate = ConvertDateTime.ConvertShamsiToMiladi(model.FromDate_Day);
                    ToDate = ConvertDateTime.ConvertShamsiToMiladi(model.ToDate_Day);

                    if (FromDate > ToDate)
                    {
                        return Json(new { status = "frombiggerto" });
                    }
                }

                Leave L = new Leave
                {
                    LeaveType = model.LeaveType,
                    LeaveAccept = 1,
                    Description = model.Description,
                    FromDate_Day = FromDate,
                    ToDate_Day = ToDate,
                    FromTime_Saati = FromTime,
                    ToTime_Saati = ToTime,
                    LeaveRequestDate = DateTime.Now,
                    UserID_Request = _userManager.GetUserId(HttpContext.User),
                    UserID_Confirm = _iletter.GetUserIdFromJobID(Convert.ToInt32(items[0].id))
                };
                _context.leaveUW.Create(L);
                _context.save();

                return Json(new { status = "ok" });
            }
            catch
            {
                return Json(new { status = "error" });
            }
        }
    }
}