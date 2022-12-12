using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Mvc;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class LeaveListRequestController : Controller
    {
        private readonly ILeaveRepository _ileave;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUnitOfWork _context;
        private readonly IWebHostEnvironment _hosting;
        private readonly ILettersRepository _iletter;

        public LeaveListRequestController(ILeaveRepository ileave, 
                                            UserManager<ApplicationUsers> userManager,
                                                IUnitOfWork db,
                                                    IWebHostEnvironment hosting,
                                                        ILettersRepository iletter)
        {
            _ileave = ileave;
            _userManager = userManager;
            _context = db;
            _hosting = hosting;
            _iletter = iletter;

            var stimulKey = Path.Combine(_hosting.ContentRootPath, "wwwroot\\reports\\license", "license.key");
            if (System.IO.File.Exists(stimulKey))
            {
                StiLicense.LoadFromFile(stimulKey);
            }
        }

        public IActionResult Index(int leaveType = 0,
                                      int leaveAccept = 0,
                                            string fromdate = "",
                                                string todate = "",
                                                    string confirmname = "")
        {
            //leaveType
            if (leaveType == 0)
            {
                ViewBag.leaveType_0 = "checked";
            }
            else if (leaveType == 1)
            {
                ViewBag.leaveType_1 = "checked";
            }
            else if (leaveType == 2)
            {
                ViewBag.leaveType_2 = "checked";
            }
            else if (leaveType == 3)
            {
                ViewBag.leaveType_3 = "checked";
            }
            else if (leaveType == 4)
            {
                ViewBag.leaveType_4 = "checked";
            }

            //leaveAccept
            if (leaveAccept == 0)
            {
                ViewBag.leaveAccept_0 = "checked";
            }
            else if (leaveAccept == 1)
            {
                ViewBag.leaveAccept_1 = "checked";
            }
            else if (leaveAccept == 2)
            {
                ViewBag.leaveAccept_2 = "checked";
            }
            else if (leaveAccept == 3)
            {
                ViewBag.leaveAccept_3 = "checked";
            }

            ///fromdate - todate
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

            //confirmname
            ViewBag.confirmname = confirmname;
            //
            var model = _ileave.LeaveList(_userManager.GetUserId(HttpContext.User), leaveType, leaveAccept,
                                            ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                                            ConvertDateTime.ConvertShamsiToMiladi(todate), confirmname);
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteLeave(int LeaveID)
        {
            if (LeaveID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var model = _context.leaveUW.GetById(LeaveID);
            if (model == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            return PartialView("_DeleteLeave", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLeavePost(Leave model)
        {
            try
            {
                _context.leaveUW.DeleteById(model.LeaveID);
                _context.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorView", "Home");
            }
        }

        public IActionResult PrintLeave(int LeaveID)
        {
            if (LeaveID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            StiReport report = new StiReport();
            var model = _ileave.LeavePrint(LeaveID);

            report["printdate"] = ConvertDateTime.ConvertMiladiToShamsi(DateTime.Now, "yyyy/MM/dd");
            report["leavetype"] = model.LeaveTypeDesc;
            report["request_fullname"] = model.FullName_Request;
            report["fullname_confirm"] = model.FullName_Confirm;

            if (model.LeaveType == 1)
            {
                report["fromtime"] = ConvertDateTime.ConvertMiladiToShamsi(model.FromTime_Saati, "HH:mm");
                report["totime"] = ConvertDateTime.ConvertMiladiToShamsi(model.ToTime_Saati, "HH:mm");
                report["time_day"] = ConvertDateTime.ConvertMiladiToShamsi(model.ToTime_Saati, "yyyy/MM/dd");
            }
            if (model.LeaveType != 1)
            {
                report["fromdate"] = ConvertDateTime.ConvertMiladiToShamsi(model.FromDate_Day, "yyyy/MM/dd");
                report["todate"] = ConvertDateTime.ConvertMiladiToShamsi(model.ToDate_Day, "yyyy/MM/dd");
                report["leaveday"] = (model.ToDate_Day.Value.Day - model.FromDate_Day.Value.Day) + 1;
            }

            report["request_jobname"] = _iletter.GetUserJob(model.UserID_Request);
            report["confirm_jobname"] = _iletter.GetUserJob(model.UserID_Confirm);
            ///Sent Image To Stimul
            StiImage im_request = new StiImage();
            im_request.Image = Image.FromFile("wwwroot/upload/signatureimage/" + _iletter.GetUserSignature(model.UserID_Request));
            report["signature_request"] = im_request.Image;
            StiImage im_confirm = new StiImage();
            im_confirm.Image = Image.FromFile("wwwroot/upload/signatureimage/" + _iletter.GetUserSignature(model.UserID_Confirm));
            report["signature_confirm"] = im_confirm.Image;
            ////Font To Stimul
            Stimulsoft.Base.StiFontCollection.AddFontFile("wwwroot/fonts/bmitra/B_Mitra.ttf");
            ///
            report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/reports/leave.mrt"));
            return StiNetCoreReportResponse.PrintAsPdf(report);
        }
    }
}