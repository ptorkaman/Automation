using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.CommonLayer.Services;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;


namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class UserManagerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUploadFiles _upload;
        private readonly IUnitOfWork _context;
        //یکی از کلاسهای آیدنتیتی جهت کار با کاربران سیستم می باشد
        private readonly UserManager<ApplicationUsers> _userManager;

        public UserManagerController(IUploadFiles upload, IUnitOfWork uow, UserManager<ApplicationUsers> userManager, IMapper mapper)
        {
            _upload = upload;
            _context = uow;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _context.userManagerUW.Get();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserViewModel model,string birthdayDateuser, byte r1, string newImagePathName, string newSignaturePathName)
        {
            if (birthdayDateuser == null)
            {
                ModelState.AddModelError("BirthDayDateMilladi", "لطفا تاریخ تولد را وارد نمایید");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                //insert
                try
                {
                    //کنترل تکراری نبودن نام کاربری
                    if (await _userManager.FindByNameAsync(model.UserName) != null)
                    {
                        ModelState.AddModelError("UserName", "نام کاربری تکراری می باشد.");
                        return View(model);
                    }
                    model.BirthDayDateMilladi = ConvertDateTime.ConvertShamsiToMiladi(birthdayDateuser);
                    var userMapped = _mapper.Map<ApplicationUsers>(model);
                    userMapped.Gender = r1;
                    userMapped.ImagePath = newImagePathName;
                    userMapped.SignaturePath = newSignaturePathName;
                    userMapped.IsActive = 1;
                    IdentityResult result = await _userManager.CreateAsync(userMapped, "123@d_F");

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    //throw;
                    return RedirectToAction("ErrorView", "Home");
                }
            }
            return View(model);
        }

        public IActionResult UploadImageFile(IEnumerable<IFormFile> filearray, string path)
        {
            string filename = _upload.UploadFileFunc(filearray, path);
            return Json(new { status = "success", imagename = filename });
        }

        [HttpGet]
        public IActionResult EditUser(string userId)
        {
            if (userId == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var user = _context.userManagerUW.GetById(userId);
            var mapUser = _mapper.Map<UserViewModel>(user);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserViewModel model, string birthdayDateuser, string newImagePathName, string newSignaturePathName)
        {
            if (birthdayDateuser == null)
            {
                ModelState.AddModelError("BirthDayDateMilladi", "لطفا تاریخ تولد را وارد نمایید");
                return View(model);
            }
            model.ImagePath = newImagePathName;
            model.SignaturePath = newSignaturePathName;
            if (ModelState.IsValid)
            {
                model.BirthDayDateMilladi = ConvertDateTime.ConvertShamsiToMiladi(birthdayDateuser);
                //update
                var user = await _userManager.FindByIdAsync(model.Id);
                IdentityResult result = await _userManager.UpdateAsync(_mapper.Map(model, user));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "UserManager");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UserDetails(string userId)
        {
            var model = _context.userManagerUW.GetById(userId);
            return View(model);
        }

        [HttpGet]
        public IActionResult ActiveOrDeactiveUser(string userID, byte IsActive)
        {
            if (userID == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var user = _context.userManagerUW.GetById(userID);
            if (user == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }

            if (user.IsActive == 1)
            {
                //DeActive
                ViewBag.theme = "darkRed";
                ViewBag.ViewTitle = "غیرفعال کردن کاربر";
                return PartialView("_activeordeactiveuser", user);
            }
            else
            {
                //Active
                ViewBag.theme = "darkgreen";
                ViewBag.ViewTitle = "فعال کردن کاربر";
                return PartialView("_activeordeactiveuser", user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActiveOrDeactiveUserPost(string Id, byte IsActive)
        {
            if (Id == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            else
            {
                try
                {
                    if (IsActive == 1)
                    {
                        //Deactive
                        var user = _context.userManagerUW.GetById(Id);
                        user.IsActive = 0;
                        _context.userManagerUW.Update(user);
                        _context.save();
                    }
                    else
                    {
                        //Active
                        var user = _context.userManagerUW.GetById(Id);
                        user.IsActive = 1;
                        _context.userManagerUW.Update(user);
                        _context.save();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction("ErrorView", "Home");
                }

            }

        }
    }
}