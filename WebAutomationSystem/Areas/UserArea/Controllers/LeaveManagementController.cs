using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class LeaveManagementController : Controller
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly ILeaveRepository _ileave;
        private readonly IUnitOfWork _context;

        public LeaveManagementController(UserManager<ApplicationUsers> userManager,
                                             ILeaveRepository ileave,
                                                IUnitOfWork context)
        {
            _userManager = userManager;
            _ileave = ileave;
            _context = context;
        }


        public IActionResult Index(int leaveType = 0, int leaveAccept = 0, string fromdate = "", string todate = "", string confirmname = "")
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
            var model = _ileave.LeaveManagement(_userManager.GetUserId(HttpContext.User), leaveType, leaveAccept,
                                                ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                                                ConvertDateTime.ConvertShamsiToMiladi(todate), confirmname);
            return View(model);
        }

        [HttpGet]
        public IActionResult AcceptOrReject(byte flag, int LeaveID, string FullName)
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

            if (flag == 1)
            {
                ViewBag.flag = 1;
                ViewBag.theme = "darkgreen";
                ViewBag.ViewTitle = "پذیرفتن مرخصی";
            }
            else
            {
                ViewBag.flag = 2;
                ViewBag.theme = "darkred";
                ViewBag.ViewTitle = "رد مرخصی";
            }
            ViewBag.FullName = FullName;
            return PartialView("_AcceptOrReject", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptOrRejectPost(int LeaveID, byte flag)
        {
            try
            {
                _ileave.AcceptRejectLeave(LeaveID, flag);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorView", "Home");
            }
        }

        [HttpGet]
        public IActionResult UserLeaveDetails(string UserID, string FullName)
        {
            if (UserID == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.UserID = UserID;
            ViewBag.FullName = FullName;
            return PartialView("_UserLeaveDetails");
        }

        [HttpPost]
        public IActionResult CalculateUserLeave(string UserID, string startdate = "", string enddate = "")
        {
            if (startdate == "" || startdate == null)
            {
                startdate = "1300/01/01";
            }
            if (enddate == "" || enddate == null)
            {
                enddate = "1600/01/01";
            }
            //محاسبه انواع مرخصی های استفاده شده
            int Estehghaghy = _ileave.GetUserLeave_Estehghaghi(UserID,
                                                                   ConvertDateTime.ConvertShamsiToMiladi(startdate),
                                                                   ConvertDateTime.ConvertShamsiToMiladi(enddate));
            int Estelaji = _ileave.GetUserLeave_Estelaji(UserID,
                                                              ConvertDateTime.ConvertShamsiToMiladi(startdate),
                                                              ConvertDateTime.ConvertShamsiToMiladi(enddate));
            int BiHoghugh = _ileave.GetUserLeave_BiHoghugh(UserID,
                                                              ConvertDateTime.ConvertShamsiToMiladi(startdate),
                                                              ConvertDateTime.ConvertShamsiToMiladi(enddate));
            string Saati = _ileave.GetUserLeave_Saati(UserID,
                                                              ConvertDateTime.ConvertShamsiToMiladi(startdate),
                                                              ConvertDateTime.ConvertShamsiToMiladi(enddate));

            return Json(new { status = "ok", estehghaghy = Estehghaghy, estelaji = Estelaji, bihoghugh = BiHoghugh, saati = Saati });
        }

    }
}