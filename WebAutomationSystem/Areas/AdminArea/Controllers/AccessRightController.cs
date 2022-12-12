using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "AdminAreaPanel")]
    public class AccessRightController : Controller
    {
        //دارای یک نکته مهم
        private readonly IUnitOfWork _context;
        private readonly IRoleRepository _Irr;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<ApplicationRoles> _roleManager;

        public AccessRightController(IUnitOfWork context, 
                                     UserManager<ApplicationUsers> userManager, 
                                     RoleManager<ApplicationRoles> roleManager,
                                     IRoleRepository irr)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _Irr = irr;
        }

        public IActionResult Index()
        {
            var model = _context.userManagerUW.Get();
            return View(model);
        }


        private void FillTreeView()
        {
            List<TreeViewModel> node = new List<TreeViewModel>();

            node.Add(new TreeViewModel
            {
                id = "1",
                text = "حقوق دسترسی",
                parent = "#"
            });

            foreach (ApplicationRoles role in _context.roleManagerUW.Get(r => r.RoleLevel != "0"))
            {
                node.Add(new TreeViewModel
                {
                    id = role.Id.ToString(),
                    parent = role.RoleLevel.ToString(),
                    text = role.Description
                });
            }

            ViewBag.AccessRight = JsonConvert.SerializeObject(node);
        }

        [HttpGet]
        public IActionResult AddRoleToUser(string userId, string FirstName, string Family)
        {
            FillTreeView();
            ViewBag.FullName = FirstName + " " + Family;
            ViewBag.userId = userId;

            ViewBag.userRole = _Irr.GetRoleId(userId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(string selectedItems, string userId)
        {
            try
            {
                //تبدیل رشته جیسون به یک لیست
                List<TreeViewModel> items = JsonConvert.DeserializeObject<List<TreeViewModel>>(selectedItems);
                if (items.Count() == 0)
                {
                    return Json(new { status = "noselected" });
                }

                //پیدا کردن کاربر
                var user = await _userManager.FindByIdAsync(userId);

                //پیدا کردن همه نقش های کاربر
                var roles = await _userManager.GetRolesAsync(user);
                //حذف همه دسترسی های قبلی کاربر
                IdentityResult deleteAllrole = await _userManager.RemoveFromRolesAsync(user, roles);


                if (deleteAllrole.Succeeded)
                {
                    //ثبت دسترسی های جدید به کاربر
                    for (int i = 0; i <= items.Count - 1; i++)
                    {
                        ApplicationRoles approle = await _roleManager.FindByIdAsync(items[i].id);
                        if (approle != null)
                        {
                            await _userManager.AddToRoleAsync(user, approle.Name);
                        }
                    }
                }
                return Json(new { status = "success" });

            }
            catch
            {
                return RedirectToAction("ErrorView", "Home");
            }
            
        }

        [HttpGet]
        public IActionResult AddRolePatternToUser(string userId, string FirstName, string Family)
        {
            if (userId == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.FullName = FirstName + " " + Family;
            ViewBag.userId = userId;
            FillCombo();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRolePatternToUser(string userId, int RolePatternID)
        {
            if (RolePatternID == -1)
            {
                ViewBag.msg = "لطفا یک نقش را انتخاب نمایید ...";
                ViewBag.alert = "alert-danger";
                FillCombo();
                return View();
            }
            //پیدا کردن کاربر
            var user = await _userManager.FindByIdAsync(userId);
            //پیدا کردن همه نقش های کاربر
            var roles = await _userManager.GetRolesAsync(user);
            //حذف همه دسترسی های قبلی کاربر
            IdentityResult deleteAllrole = await _userManager.RemoveFromRolesAsync(user, roles);
            //پیدا کردن همه دسترسی های یک نقش
            var getRoleFromPattern = _context.rolePatternDetailsUW.Get(rp => rp.RolePatternID == RolePatternID, null, "Roles").ToList();

            if (deleteAllrole.Succeeded)
            {
                //ثبت دسترسیهای نقش برای کاربر
                for (int i = 0; i <= getRoleFromPattern.Count() - 1; i++)
                {
                    await _userManager.AddToRoleAsync(user, getRoleFromPattern[i].Roles.Name);
                }
            }
            FillCombo();
            ViewBag.msg = "نقش انتخاب شده با موفقیت به کاربر انتساب داده شد.";
            ViewBag.alert = "alert-success";
            return View();
        }

        public void FillCombo()
        {
            List<RolePattern> ListRolePattern = _context.rolePatternUW.Get().ToList();
            RolePattern RP = new RolePattern
            {
                RolePatternID = -1,
                RolePatternName = "لطفا یک نقش کاربری را انتخاب نمایید..."
            };

            ListRolePattern.Insert(0, RP);
            ViewBag.patternlist = ListRolePattern;
        }
    }
}