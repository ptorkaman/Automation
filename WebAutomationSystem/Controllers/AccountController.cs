using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly ILettersRepository _iltter;

        public AccountController(SignInManager<ApplicationUsers> signInManager, 
                                    UserManager<ApplicationUsers> userManager,
                                        ILettersRepository iletter)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _iltter = iletter;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user.IsAdmin == 1)
                {
                    return Redirect("/AdminArea/Dashboard/Index");
                }
                else
                {
                    return Redirect("/UserArea");
                }
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
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    ModelState.AddModelError("Password", "اطلاعات ورود صحیح نیست");
                    return View(model);
                }
                else
                {
                    if (user.IsActive == 0)
                    {
                        //کنترل غیرفعال بودن اکانت کاربر
                        ModelState.AddModelError("Password", "این اکانت غیر فعال می باشد.");
                        return View(model);
                    }
                    {
                        //کنترل اینکه کاربر حتما شغل داشته باشد
                        if (_iltter.GetUserJobID(user.Id) == 0)
                        {
                            ModelState.AddModelError("Password", "کاربر فاقد شغل سازمانی می باشد.");
                            return View(model);
                        }
                    }
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {

                        if (user.IsAdmin == 1)
                        {
                            //Admin
                            return Redirect("/AdminArea/Dashboard/Index");
                        }
                        else if (user.IsAdmin == 2)
                        {
                            //User
                            return Redirect("/userArea");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("Password", "اطلاعات ورود صحیح نیست");
                        return View(model);
                    }
                }
           
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Account/Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}