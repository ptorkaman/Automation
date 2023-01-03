using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using System.Drawing;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class ReferralLettersController : Controller
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly ILettersRepository _iletter;
        private readonly IReferralLetterRepository _referralLetterRepository;

        public ReferralLettersController(UserManager<ApplicationUsers> userManager, ILettersRepository iletter, IReferralLetterRepository referralLetterRepository)
        {
            _userManager = userManager;
            _iletter = iletter;
            _referralLetterRepository = referralLetterRepository;
        }

        public IActionResult Index(byte classificationradio = 0, byte replyradio = 2, byte attachmentradio = 2, byte readradio = 2, byte searchTypeselected = 0, byte immediatelytype = 0, string inputsearch = "", string fromdate = "", string todate = "")
        {
            //طبقه بندی
            switch (classificationradio)
            {
                case 0:
                    ViewBag.classificationradio_all = "checked";
                    break;
                case 1:
                    ViewBag.classificationradio_1 = "checked";
                    break;
                case 2:
                    ViewBag.classificationradio_2 = "checked";
                    break;
                case 3:
                    ViewBag.classificationradio_3 = "checked";
                    break;
            }
            //درخواست پاسخ
            switch (replyradio)
            {
                case 0:
                    ViewBag.radioreply_0 = "checked";
                    break;
                case 1:
                    ViewBag.radioreply_1 = "checked";
                    break;
                case 2:
                    ViewBag.radioreply_all = "checked";
                    break;
            }
            //پیوست
            switch (attachmentradio)
            {
                case 0:
                    ViewBag.attachmentradio_0 = "checked";
                    break;
                case 1:
                    ViewBag.attachmentradio_1 = "checked";
                    break;
                case 2:
                    ViewBag.attachmentradio_all = "checked";
                    break;
            }
            //وضعیت خوانده شدن
            switch (readradio)
            {
                case 0:
                    ViewBag.radioread_0 = "checked";
                    break;
                case 1:
                    ViewBag.radioread_1 = "checked";
                    break;
                case 2:
                    ViewBag.radioread_all = "checked";
                    break;
            }

            ViewBag.searchTypeselected = searchTypeselected;
            ViewBag.immediatelytype = immediatelytype;
            ViewBag.inputsearch = inputsearch;
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

            var model = _iletter.
                ReferLetters(_userManager.GetUserId(HttpContext.User),
                         ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                         ConvertDateTime.ConvertShamsiToMiladi(todate),
                         classificationradio, attachmentradio, searchTypeselected, immediatelytype, inputsearch);
            return View(model);
        }

        public IActionResult ReadLetter(int LetterID)
        {
            if (LetterID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            //Update ReadLetter Status
            _iletter.UpdateLetterReadStatus(_userManager.GetUserId(HttpContext.User), LetterID);
            //
            StiReport report = new StiReport();
            var model = _iletter.ReadLetter(_userManager.GetUserId(HttpContext.User), LetterID);
            report["letterdate"] = ConvertDateTime.ConvertMiladiToShamsi(model.LetterSentDate, "yyyy/MM/dd");
            report["foriat"] = model.ImmediatellyStatusText;
            report["attachment"] = model.AttachmentStatusText;
            report["tabaghe"] = model.ClassificationStatusText;
            report["lettercontent"] = model.LetterContent;
            report["lettersubject"] = model.LetterSubject;
            report["fromuser"] = _iletter.GetUserJob(model.UserID_Sender);
            report["touser"] = _iletter.GetUserJob(model.UserID_Reciever);
            ///Sent Image To Stimul
            StiImage im = new StiImage();
            im.Image = Image.FromFile("wwwroot/upload/signatureimage/" + _iletter.GetUserSignature(model.UserID_Sender));
            report["signature"] = im.Image;
            ////Font To Stimul
            Stimulsoft.Base.StiFontCollection.AddFontFile("wwwroot/fonts/bmitra/B_Mitra.ttf");
            ///
            report.Load(StiNetCoreHelper.MapPath(this, "wwwroot/reports/letter.mrt"));
            return StiNetCoreReportResponse.PrintAsPdf(report);
        }

    }
}