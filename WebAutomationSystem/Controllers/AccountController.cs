using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;

        public AccountController(SignInManager<ApplicationUsers> signInManager, IDNTCaptchaValidatorService validatorService, UserManager<ApplicationUsers> userManager, ILettersRepository iletter, IOptions<DNTCaptchaOptions> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _iltter = iletter;
            _validatorService = validatorService;
            _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;
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
                if (!_validatorService.HasRequestValidCaptchaEntry(Language.Persian, DisplayMode.NumberToWord))
                {
                    ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "لطفا متن را به صورت عدد وارد کنید.");
                    return View(model);
                }
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