using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}