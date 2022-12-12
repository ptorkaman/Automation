using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "AdminAreaPanel")]
    public class ReminderController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUsers> _userManager;

        public ReminderController(IUnitOfWork context, UserManager<ApplicationUsers> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _context.reminderUW.Get(r => r.UserID == _userManager.GetUserId(HttpContext.User));
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewReminder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewReminder(ReminderViewModel model, string ReminderDateShamsi)
        {
            if (ReminderDateShamsi == null)
            {
                ModelState.AddModelError("ReminderDate", "تاریخ یادآوری وارد نشده است");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                model.ReminderDate = ConvertDateTime.ConvertShamsiToMiladi(ReminderDateShamsi);
                model.ReminderCreateDate = DateTime.Now;
                model.UserID = _userManager.GetUserId(HttpContext.User);

                var mapModel = _mapper.Map<Reminder>(model);
                _context.reminderUW.Create(mapModel);
                _context.save();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteRemider(int ReminderID)
        {
            if (ReminderID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var reminder = _context.reminderUW.GetById(ReminderID);
            if (reminder == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }

            return PartialView("_deleteReminder", reminder);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteReminderPost(int ReminderID)
        {
            if (ReminderID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            else
            {
                try
                {
                    _context.reminderUW.DeleteById(ReminderID);
                    _context.save();
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