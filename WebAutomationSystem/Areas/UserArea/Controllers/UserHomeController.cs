using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class UserHomeController : Controller
    {
        private readonly IUnitOfWork _context;

        public UserHomeController(IUnitOfWork context)
        {
            _context = context;
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
                return RedirectToAction("ErrorView", "Home");
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