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
    public class SentLetterController : Controller
    {
        private readonly ILettersRepository _iletter;
        private readonly UserManager<ApplicationUsers> _userManager;
        public SentLetterController(ILettersRepository iletter, UserManager<ApplicationUsers> userManager)
        {
            _iletter = iletter;
            _userManager = userManager;
        }

        public IActionResult Index(byte classificationradio = 0,
                                     byte replyradio = 2,
                                         byte attachmentradio = 2,
                                             byte readradio = 2,
                                                 byte searchTypeselected = 0,
                                                     byte immediatelytype = 0,
                                                         string inputsearch = "",
                                                             string fromdate = "",
                                                                 string todate = "")
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
                SentLetters(_userManager.GetUserId(HttpContext.User),
                         ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                         ConvertDateTime.ConvertShamsiToMiladi(todate),
                         classificationradio, replyradio, attachmentradio, searchTypeselected, immediatelytype, inputsearch);
            return View(model);
        }
    }
}