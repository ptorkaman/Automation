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

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class LetterManagementController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUploadFiles _upload;
        private readonly IMapper _mapper;

        public LetterManagementController(IUnitOfWork db, 
                                            UserManager<ApplicationUsers> userManager,
                                                        IUploadFiles upload,
                                                            IMapper mapper)
        {
            _context = db;
            _userManager = userManager;
            _upload = upload;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateLetter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLetter(LettersViewModel model,string newfilePathName)
        {
            if (ModelState.IsValid)
            {
                //insert
                if (model.ReplyStatus == 1)
                {
                    model.ReplyDate = ConvertDateTime.ConvertShamsiToMiladi(model.ReplyDate).ToString();
                }
                if (model.AttachmentStatus == 1)
                {
                    model.LetterAttachamentFile = newfilePathName;
                }
                model.UserID = _userManager.GetUserId(HttpContext.User);
                model.LetterCreateDate = DateTime.Now;
                _context.lettersUW.Create(_mapper.Map<Letters>(model));
                _context.save();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AutomationFormList()
        {
            var model = _context.administrativeFormUW.Get(a => a.AdministrativeFormType == true).ToList();
            return PartialView("_automationFormList", model);
        }

        [HttpGet]
        public IActionResult DefaultFormList()
        {
            var model = _context.administrativeFormUW.Get(a => a.AdministrativeFormType == false && a.UserID == _userManager.GetUserId(HttpContext.User)).ToList();
            return PartialView("_defaultFormList", model);
        }

        public IActionResult UploadAttachFile(IEnumerable<IFormFile> filearray, string path, long filesize)
        {
            if (filesize >= 512000)
            {
                return Json(new { status = "badsize" });
            }
            var user = _context.userManagerUW.GetById(_userManager.GetUserId(HttpContext.User));
            string filename = _upload.UploadAttachamentFunc(filearray, path, user.UserName);
            return Json(new { status = "success", imagename = filename });
        }

        [HttpGet]
        public IActionResult SearchInSubject(string term)
        {
            try
            {
                var query = _context.administrativeFormUW.Get(Ad => Ad.AdministrativeFormTitle.Contains(term) &&
                Ad.UserID == _userManager.GetUserId(HttpContext.User)).Select(Ad => Ad.AdministrativeFormTitle).ToList();

                return Ok(query);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
    }
}