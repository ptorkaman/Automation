using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<ApplicationUsers> _userManager;

        public ChangePasswordController(UserManager<ApplicationUsers> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Changing(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(_userManager.GetUserId(HttpContext.User));
                PasswordVerificationResult oldpassresult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.OldPassword);

                if (oldpassresult == PasswordVerificationResult.Success)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
                    var result = await _userManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ViewBag.msg = "در ثبت اطلاعات مشکلی به وجود آمده است";
                        ViewBag.alt = "alert-danger";
                        return View("ChangePassword");
                    }
                    ViewBag.msg = "رمز عبور شما با موفقیت تغییر کرد";
                    ViewBag.alt = "alert-success";
                    return View("ChangePassword");
                }
                else
                {
                    ViewBag.msg = "رمز عبور قدیمی صحیح نیست";
                    ViewBag.alt = "alert-danger";
                    return View("ChangePassword");
                }
            }
            return View("ChangePassword", model);
        }
    }
}