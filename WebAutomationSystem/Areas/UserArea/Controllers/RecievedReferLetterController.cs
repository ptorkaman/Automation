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
    public class RecievedReferLetterController : Controller
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly ILettersRepository _iletter;
        private readonly IUnitOfWork _context;
        public RecievedReferLetterController(ILettersRepository iletter, 
                                                UserManager<ApplicationUsers> userManager,
                                                    IUnitOfWork context)
        {
            _userManager = userManager;
            _iletter = iletter;
            _context = context;
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
                RecievedReferLetters(_userManager.GetUserId(HttpContext.User),
                         ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                         ConvertDateTime.ConvertShamsiToMiladi(todate),
                         classificationradio, attachmentradio, searchTypeselected, immediatelytype, inputsearch);
            return View(model);
        }


        [HttpGet]
        public IActionResult ReferLetter(int LetterID, string mainUserId)
        {
            if (LetterID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.JobIdList = JsonConvert.SerializeObject(_context.jobsChartUW.Get().Select(j => j.JobsChartID).ToList());
            TreeViewCreator();

            ViewBag.userJobId = _context.userJobUW.Get
                (u => u.UserID == _userManager.GetUserId(HttpContext.User) && u.IaHaveJob == true).Select(s => s.JobID).Single();
            ViewBag.LetterId = LetterID;
            ViewBag.MainUserId = mainUserId;
            return PartialView("_ReferLetter");
        }

        [HttpPost]
        public IActionResult ReferralLetter
            (int LetterID, string SelectedUserToRefer, string MainUserId, string Description)
        {
            try
            {
                List<TreeViewModel> items = JsonConvert.DeserializeObject<List<TreeViewModel>>(SelectedUserToRefer);
                if (items.Count == 0)
                {
                    return Json(new { status = "nouserselected" });
                }
                for (int i = 0; i < items.Count; i++)
                {
                    string RecievedUserID = _iletter.GetUserIdFromJobID(Convert.ToInt32(items[i].id));
                    //کنترل عدم ارجاع تکراری

                    var checkBeforeRefer = _context.referralLettersUW.Get
                        (Rl => Rl.LetterID == LetterID &&
                        Rl.RecieveReferUserID == RecievedUserID &&
                        Rl.mainUserID == MainUserId);

                    if (checkBeforeRefer.Count() == 0)
                    {
                        ReferralLetters RL = new ReferralLetters
                        {
                            LetterID = LetterID,
                            ReadType = false,
                            mainUserID = MainUserId,
                            ReferUserID = _userManager.GetUserId(HttpContext.User),
                            RecieveReferUserID = RecievedUserID,
                            ReferDate = DateTime.Now,
                            Description = Description
                        };
                        _context.referralLettersUW.Create(RL);
                        _context.save();
                    }
                }
                return Json(new { status = "ok" });
            }
            catch
            {
                return Json(new { status = "error" });
            }
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
               JsonConvert.SerializeObject(_context.userJobUW.Get(uj => uj.IaHaveJob == true).Select(uj => uj.JobID).ToList());

            ViewBag.JobJson = JsonConvert.SerializeObject(node);
        }
    }
}