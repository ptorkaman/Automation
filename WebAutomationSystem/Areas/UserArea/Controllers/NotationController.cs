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
    public class NotationController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly ILettersRepository _iletter;
        private readonly UserManager<ApplicationUsers> _userManager;

        public NotationController(IUnitOfWork context, ILettersRepository iletter, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _iletter = iletter;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            TreeViewCreator();
            ViewBag.JobIdList = JsonConvert.SerializeObject(_context.jobsChartUW.Get().Select(j => j.JobsChartID).ToList());
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
        public IActionResult SentNotation(string NotationTitle, string NotationContent, string SelectedUserToSent)
        {
            try
            {
                List<TreeViewModel> items = JsonConvert.DeserializeObject<List<TreeViewModel>>(SelectedUserToSent);
                if (items.Count == 0)
                {
                    return Json(new { status = "nouserselected" });
                }
                if (items.Count > 1)
                {
                    return Json(new { status = "justoneperson" });
                }

                Notation N = new Notation
                {
                    NotationContent = NotationContent,
                    NotationTitle = NotationTitle,
                    NotationDate = DateTime.Now,
                    UserID_Creator = _userManager.GetUserId(HttpContext.User),
                    UserID_Reciever = _iletter.GetUserIdFromJobID(Convert.ToInt32(items[0].id))
                };
                _context.notationUW.Create(N);
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