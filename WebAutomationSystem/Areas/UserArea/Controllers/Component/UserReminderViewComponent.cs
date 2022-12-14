using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.UserArea.Controllers.Component
{
    [ViewComponent(Name = "UserReminderViewComponent")]
    public class UserReminderViewComponent : ViewComponent
    {

        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUsers> _userManager;

        public UserReminderViewComponent(IUnitOfWork context, UserManager<ApplicationUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var model = _context.reminderUW.Get(r => r.UserID == _userManager.GetUserId(HttpContext.User) &&
                                           r.ReminderDate == DateTime.Now.Date);
            return View(model);
        }
    }
}
