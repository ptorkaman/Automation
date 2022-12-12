using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class DraftController : Controller
    {
        private readonly ILettersRepository _iletter;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUnitOfWork _context;

        public DraftController(ILettersRepository iletter, UserManager<ApplicationUsers> userManager, IUnitOfWork context)
        {
            _iletter = iletter;
            _userManager = userManager;
            _context = context;
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

        public IActionResult Index()
        {
            var model = _iletter.LettersList(_userManager.GetUserId(HttpContext.User));
            ViewBag.JobIdList = JsonConvert.SerializeObject(_context.jobsChartUW.Get().Select(j => j.JobsChartID).ToList());
            TreeViewCreator();

            ViewBag.userJobId = _context.userJobUW.Get
                (u => u.UserID == _userManager.GetUserId(HttpContext.User) && u.IaHaveJob == true).Select(s => s.JobID).Single();
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int LetterID)
        {
            if (LetterID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var model = _context.lettersUW.GetById(LetterID);
            if (model == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            return PartialView("_deletedraft", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLetter(int LetterID)
        {
            try
            {
                if (LetterID == 0)
                {
                    return RedirectToAction("ErrorView", "Home");
                }
                _context.lettersUW.DeleteById(LetterID);
                _context.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorView", "Home");
            }
        }

        [HttpPost]
        public IActionResult SentLetter(int LetterID, string SelectedUserToSent, byte LetterType, int MainLetterID)
        {
            try
            {
                if (LetterType == 1)
                {
                    if (LetterID == 0)
                    {
                        return Json(new { status = "noletterselected" });
                    }
                    List<TreeViewModel> items = JsonConvert.DeserializeObject<List<TreeViewModel>>(SelectedUserToSent);
                    if (items.Count == 0)
                    {
                        return Json(new { status = "nouserselected" });
                    }
                    for (int i = 0; i < items.Count; i++)
                    {
                        SentLetters SL = new SentLetters
                        {
                            LetterID = LetterID,
                            ReadType = false,
                            SentLetterDate = DateTime.Now,
                            userId_sender = _userManager.GetUserId(HttpContext.User),
                            userId_reciever = _iletter.GetUserIdFromJobID(Convert.ToInt32(items[i].id))

                        };
                        _context.sentLettersUW.Create(SL);
                    }
                }
                else if (LetterType == 2)
                {
                    //پاسخ نامه
                    string CreatorUserID = _context.lettersUW.Get(L => L.LetterID == MainLetterID).Select(U => U.UserID).Single();
                    SentLetters SL = new SentLetters
                    {
                        LetterID = LetterID,
                        ReadType = false,
                        SentLetterDate = DateTime.Now,
                        userId_sender = _userManager.GetUserId(HttpContext.User),
                        userId_reciever = CreatorUserID

                    };
                    _context.sentLettersUW.Create(SL);
                }
            

                //Exit Letter From Draft
                _iletter.ExitLetterFromDraft(LetterID, _userManager.GetUserId(HttpContext.User));
                return Json(new { status = "ok" });
            }
            catch
            {
                return Json(new { status = "error" });
            }
    
        }
    }
}