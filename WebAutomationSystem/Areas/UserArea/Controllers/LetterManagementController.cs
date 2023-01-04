using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.CommonLayer.Services;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Repository;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;
using static Stimulsoft.Report.StiRecentConnections;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class LetterManagementController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUploadFiles _upload;
        private readonly IMapper _mapper;
        private readonly ISecretariatTypeRepository _secretariatTypeRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILettersRepository _lettersRepository;
        private readonly IGroupUserRepository _groupUserRepository;
        public LetterManagementController(IUnitOfWork db, IUserRepository userRepository, ILettersRepository lettersRepository, UserManager<ApplicationUsers> userManager, IUploadFiles upload, IMapper mapper, ISecretariatTypeRepository secretariatTypeRepository, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository)
        {
            _context = db;
            _userManager = userManager;
            _upload = upload;
            _mapper = mapper;
            _secretariatTypeRepository = secretariatTypeRepository;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _lettersRepository = lettersRepository;
            _groupUserRepository = groupUserRepository;
        }


        [HttpGet]
        public IActionResult CreateLetter(byte LetterType = 1, int MainLetterID = 0, string LetterNo = "", string LetterDate = "")
        {
            if (LetterType == 2)
            {
                ViewBag.msg = "پاسخ نامه با شماره " + LetterNo + " و تاریخ " + LetterDate;
            }
            ViewBag.LetterType = LetterType;
            ViewBag.MainLetterID = MainLetterID;
            ViewBag.LetterNo = LetterNo;
            ViewBag.LetterDate = LetterDate;
            ViewBag.type = _secretariatTypeRepository.GetAll();
            ViewBag.group = _groupRepository.GetAll();
            ViewBag.users = _userRepository.GetAll();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateLetter(LettersViewModel model, string newfilePathName, string LetterNo, string LetterDate, CancellationToken cancellationToken)
        {
            using (var transaction = _context.BeginTransaction())
            {
                try
                {
                    //insert
                    if (model.ReplyStatus == 1)
                    {
                        if (model.ReplyDate != null)
                            model.ReplyDate = ConvertDateTime.ConvertShamsiToMiladi(model.ReplyDate).ToString();
                    }
                    if (model.AttachmentStatus == 1)
                    {
                        model.LetterAttachamentFile = newfilePathName;
                    }
                    model.UserID = _userManager.GetUserId(HttpContext.User);
                    model.LetterCreateDate = DateTime.Now;
                    var letter = await _lettersRepository.AddAsync(_mapper.Map<Letters>(model), cancellationToken);
                    foreach (var item in model.Recievers)
                    {                  
                        SentLetters SL = new SentLetters
                        {
                            LetterID = letter.LetterID,
                            ReadType = false,
                            SentLetterDate = DateTime.Now,
                            userId_sender = _userManager.GetUserId(HttpContext.User),
                            userId_reciever = item
                        };
                        _context.sentLettersUW.Create(SL);
                    }
                    foreach (var item in model.CopyRecievers)
                    {
                        SentLetters SL = new SentLetters
                        {
                            LetterID = letter.LetterID,
                            ReadType = false,
                            SentLetterDate = DateTime.Now,
                            userId_sender = _userManager.GetUserId(HttpContext.User),
                            userId_reciever = item,
                            IsCopyReciver = true
                        };
                        _context.sentLettersUW.Create(SL);
                    }
                    foreach (var item in model.HiddenRecievers)
                    {
                        SentLetters SL = new SentLetters
                        {
                            LetterID = letter.LetterID,
                            ReadType = false,
                            SentLetterDate = DateTime.Now,
                            userId_sender = _userManager.GetUserId(HttpContext.User),
                            userId_reciever = item,
                            IsHiddenReciver=true
                        };
                        _context.sentLettersUW.Create(SL);
                    }
                    if (model.GroupIds.Count>0)
                    {
                        foreach (var item in model.GroupIds)
                        {
                            var grouplist = _groupUserRepository.GetByGroupId(item);
                            foreach (var group in grouplist)
                            {
                                SentLetters SL = new SentLetters
                                {
                                    LetterID = letter.LetterID,
                                    ReadType = false,
                                    SentLetterDate = DateTime.Now,
                                    userId_sender = _userManager.GetUserId(HttpContext.User),
                                    userId_reciever = group.UserId

                                };
                                _context.sentLettersUW.Create(SL);
                            }
                        }                       
                    }
                    _context.save();
                    transaction.Commit();

                    if (model.Recievers.Count == 0 &&  model.GroupId == null)
                        return RedirectToAction("Index", "Draft");
                    else
                        return RedirectToAction("Index", "SentLetter");
                }
                catch (Exception ex)
                {
                    transaction.RollBack();
                    ViewBag.LetterType = model.LetterType;
                    ViewBag.MainLetterID = model.MainLetterID;
                    ViewBag.LetterNo = LetterNo;
                    ViewBag.LetterDate = LetterDate;
                    if (model.LetterType == 2)
                    {
                        ViewBag.msg = "پاسخ نامه با شماره " + LetterNo + " و تاریخ " + LetterDate;
                    }
                    return View(model);
                }
            }
        }

        [HttpGet]
        public IActionResult AutomationFormList()
        {
            var model = _context.administrativeFormUW.Get(a => a.AdministrativeFormType == true).ToList();
            ViewBag.type = _secretariatTypeRepository.GetAll();

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




        [HttpPost]
        public ActionResult GetLetterBySecretariatTypeId(int id)
        {
            using (var transaction = _context.BeginTransaction())
            {
                try
                {
                    var model = _context.administrativeFormUW.Get(a => a.SecretariatTypeId == id).ToList();
                    return Json(model);
                }
                catch
                {
                    transaction.RollBack();
                    return Json(new { status = "error" });
                }
            }
        }


    }
}