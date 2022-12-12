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
    public class SentNotationController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly INotationRepository _inotation;
        private readonly UserManager<ApplicationUsers> _userManager;

        public SentNotationController(IUnitOfWork context, INotationRepository inotation, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _inotation = inotation;
            _userManager = userManager;
        }

        public IActionResult Index(byte searchTypeselected = 0,
                                       string inputsearch = "",
                                             string fromdate = "",
                                                  string todate = "")
        {
            ViewBag.searchTypeselected = searchTypeselected;
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

            var model = _inotation.
                SentNotationList(_userManager.GetUserId(HttpContext.User),
                         ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                         ConvertDateTime.ConvertShamsiToMiladi(todate),
                         searchTypeselected, inputsearch);
            return View(model);
        }

        [HttpGet]
        public IActionResult ReadNotation(string NotationContent, string NotationTitle, string NotationDate)
        {
            ViewBag.NotationDate = NotationDate;
            ViewBag.NotationTitle = NotationTitle;
            ViewBag.NotationContent = NotationContent;
            return PartialView("_ReadNotation");
        }
    }
}