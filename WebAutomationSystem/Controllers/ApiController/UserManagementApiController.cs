using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Controllers.ApiController
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserManagementApiController : ControllerBase
    {
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly ILettersRepository _iltter;

        public UserManagementApiController(SignInManager<ApplicationUsers> signInManager,
                                                UserManager<ApplicationUsers> userManager,
                                                    ILettersRepository iletter)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _iltter = iletter;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    return BadRequest(new { message = "اطلاعات ورود صحیح نیست."});
                }
                else
                {
                    if (user.IsActive == 0)
                    {
                        //کنترل غیرفعال بودن اکانت کاربر
                        return BadRequest(new { message = "این اکانت غیر فعال می باشد." });
                    }
                    {
                        //کنترل اینکه کاربر حتما شغل داشته باشد
                        if (_iltter.GetUserJobID(user.Id) == 0)
                        {
                            return BadRequest(new { message = "کاربر فاقد شغل سازمانی می باشد." });
                        }
                    }
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return Ok(new { message = "شما با موفقیت وارد شدید.", firstname = user.FirstName, family = user.Family});
                    }
                    else
                    {
                        return BadRequest(new { message = "اطلاعات ورود صحیح نیست."});
                    }
                }
            }
            return BadRequest( new { message = "نام کاربری یا رمز عبور وارد نشده است" });
        }

    }
}