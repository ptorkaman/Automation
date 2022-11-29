using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{

    [Area("AdminArea")]
    [Authorize]
    public class UserJobManagerController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IUserJobRepository _userjob;

        public UserJobManagerController(IUnitOfWork context, IUserJobRepository userjob)
        {
            _context = context;
            _userjob = userjob;
        }

        public IActionResult Index()
        {
            var model = _context.userManagerUW.Get();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddJobToUser(string userId, string FirstName, string Family)
        {
            List<TreeViewModel> node = new List<TreeViewModel>();

            node.Add(new TreeViewModel
            {
                id = "1",
                text = "مدیر عامل",
                parent = "#"
            });

            foreach (JobsChart job in _context.jobsChartUW.Get(j => j.JobsChartLevel != 0))
            {
                node.Add(new TreeViewModel
                {
                    id = job.JobsChartID.ToString(),
                    parent = job.JobsChartLevel.ToString(),
                    text = job.JobsChartName
                });
            }


            ViewBag.ReservedJobList = 
               JsonConvert.SerializeObject(_context.userJobUW.Get(uj => uj.IaHaveJob == true).Select(uj => uj.JobID).ToList());


            ViewBag.FullName = FirstName + " " + Family;
            ViewBag.userId = userId;
            ViewBag.JobJson = JsonConvert.SerializeObject(node);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddJobToUser(UserJob model)
        {
            if (ModelState.IsValid)
            {
                UserJob UJ = new UserJob()
                {
                    IaHaveJob = true,
                    StartJobDate = DateTime.Now,
                    UserID = model.UserID,
                    JobID = model.JobID
                };

                _context.userJobUW.Create(UJ);
                _context.save();
                return RedirectToAction("JobhistoryList", new { userId = model.UserID });
            }
            return RedirectToAction("JobhistoryList", new { userId = model.UserID });
        }

        [HttpGet]
        public IActionResult JobhistoryList(string userId)
        {
            if (userId == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var model = _context.userJobUW.Get(uj => uj.UserID == userId, null, "Jobs");
            var checkForjob = model.Where(m => m.IaHaveJob == true).ToList();
            if (checkForjob.Count() > 0)
            {
                ViewBag.CheckJob = 1;
            }

            ViewBag.userId = userId;
            return View(model);
        }

        [HttpGet]
        public IActionResult DelJobFromUser(int UserJobId, string userId)
        {
            if (UserJobId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.UserJobId = UserJobId;
            ViewBag.userId = userId;
            return PartialView("_deljobfromuser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelJobFromUserPost(int UserJobId, string userId)
        {
            if (UserJobId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            _userjob.DeleteJobFromUser(UserJobId);
            return RedirectToAction("JobhistoryList" , new { userId = userId });
        }
    }
}