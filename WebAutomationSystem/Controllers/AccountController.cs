using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUsers> _signInManager;

        public AccountController(SignInManager<ApplicationUsers> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/AdminArea/Dashboard/Index");
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return Redirect("/AdminArea/UserManager/Index");
                }
                else
                {
                    ModelState.AddModelError("Password", "اطلاعات ورود صحیح نیست");
                    return View(model);
                }
            }

            return View(model);
        }
    }
}