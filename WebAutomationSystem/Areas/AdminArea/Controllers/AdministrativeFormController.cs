using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Repository;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "AdminAreaPanel")]
    public class AdministrativeFormController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly ISecretariatTypeRepository _secretariatTypeRepository;
        public AdministrativeFormController(IUnitOfWork context,
                                        UserManager<ApplicationUsers> userManager,
                                                 IMapper mapper, ISecretariatTypeRepository secretariatTypeRepository)
        {
            _secretariatTypeRepository = secretariatTypeRepository;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_context.administrativeFormUW.Get(ad => ad.UserID == _userManager.GetUserId(HttpContext.User) && ad.AdministrativeFormType == true));

        }

        [HttpGet]
        public IActionResult AddNewDefaultForm()
        {
            ViewBag.type = _secretariatTypeRepository.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewDefaultForm(AdministrativeFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserID = _userManager.GetUserId(HttpContext.User);
                model.AdministrativeFormType = true;
                _context.administrativeFormUW.Create(_mapper.Map<AdministrativeForm>(model));
                _context.save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int AdministrativeFormID)
        {
            if (AdministrativeFormID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var model = _context.administrativeFormUW.GetById(AdministrativeFormID);
            if (model == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            return PartialView("_deleteform", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteForm(int AdministrativeFormID)
        {
            if (AdministrativeFormID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            try
            {
                _context.administrativeFormUW.DeleteById(AdministrativeFormID);
                _context.save();
                return RedirectToAction("Index");
            }
            catch
            {

                return RedirectToAction("ErrorView", "Home");
            }
        }
    }
}