using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        public DashboardController(IUnitOfWork context, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ReadReminder(int ReminderID)
        {
            if (ReminderID == 0)
            {
                return RedirectToAction("ErrorView","Home");
            }
            var model = _context.reminderUW.GetById(ReminderID);
            return PartialView("_readReminder", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReadReminderPost(int ReminderID)
        {
            try
            {
                var model = _context.reminderUW.GetById(ReminderID);
                model.IsRead = true;
                _context.reminderUW.Update(model);
                _context.save();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErrorView", "Home");
            }
        }
    }
}