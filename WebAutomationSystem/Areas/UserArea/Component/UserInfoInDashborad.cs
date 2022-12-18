using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutomationSystem.DataModelLayer;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.UserArea.Component
{
    [ViewComponent(Name = "UserInfoInDashborad")]
    public class UserInfoInDashborad : ViewComponent
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUnitOfWork _context;

        public UserInfoInDashborad( UserManager<ApplicationUsers> userManager, IUnitOfWork context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var model = _context.userManagerUW.GetById(_userManager.GetUserId(HttpContext.User));
            return View(model);
        }
    }
}
