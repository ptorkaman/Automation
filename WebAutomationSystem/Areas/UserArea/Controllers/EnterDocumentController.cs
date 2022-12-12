using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.CommonLayer.Services;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class EnterDocumentController : Controller
    {
        private readonly IUserJobRepository _iusertjob;
        private readonly IUploadFiles _upload;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _context;
        private readonly ILettersRepository _iletter;
        private readonly IForignDocumentRepository _idoc;
        private readonly UserManager<ApplicationUsers> _userManager;

        public EnterDocumentController(IUserJobRepository iusertjob, 
                                            IUploadFiles upload, 
                                                    IMapper mapper,
                                                        UserManager<ApplicationUsers> userManager,
                                                            IUnitOfWork context,
                                                                IForignDocumentRepository idoc,
                                                                    ILettersRepository iletter)
        {
            _iusertjob = iusertjob;
            _upload = upload;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _idoc = idoc;
            _iletter = iletter;
        }

        public IActionResult RegisterEnterDocument()
        {
            FillCombo();
            ViewBag.ImageDocumentName = "/upload/documentattach/documentlogo.png";
            return View();
        }

        private void FillCombo()
        {
            List<UserWithJobNameViewModel> ListUserWithJob = _iusertjob.UserFullNameWithJobName();
            UserWithJobNameViewModel jobuser = new UserWithJobNameViewModel
            {
                UserID = "-1",
                UserFullNameWithJob = "انتخاب واحد ارائه دهنده خدمت"
            };
            ListUserWithJob.Insert(0, jobuser);
            ViewBag.ListUserWithJob = ListUserWithJob;
        }

        public IActionResult UploadAttachFile(IEnumerable<IFormFile> filearray, string path, long filesize)
        {
            if (filesize >= 512000)
            {
                return Json(new { status = "badsize" });
            }
           
            string filename = _upload.UploadFileFunc(filearray, path);
            return Json(new { status = "success", imagename = filename });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterDocument(ForeignDocumentViewModel model, string newfilePathName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapModel = _mapper.Map<ForeignDocument>(model);
                    mapModel.UserID_SaveDocument = _userManager.GetUserId(HttpContext.User);
                    mapModel.DocumentEnterDate = DateTime.Now;
                    mapModel.DocumentImagePath = newfilePathName;
                    //DocumentNumber
                    mapModel.DocumentNumber = _idoc.CreateDoumentNumber();
                    //JobsChartID
                    mapModel.JobsChartID = _iletter.GetUserJobID(mapModel.UserID_RecieveDocument);
                    //
                    _context.foreignDocumentUW.Create(mapModel);
                    ViewBag.ImageDocumentName = "/upload/documentattach/" + newfilePathName;
                    _context.save();
                    FillCombo();
                    ViewBag.msg = "اطلاعات با موفقیت ثبت شد.";
                    ViewBag.alert = "alert-success";
                    return View("RegisterEnterDocument");
                }
                catch
                {
                    FillCombo();
                    ViewBag.msg = "در ثبت اطلاعات مشکلی به وجود آمده است.";
                    ViewBag.alert = "alert-danger";
                    ViewBag.ImageDocumentName = "/upload/documentattach/" + newfilePathName;
                    return View("RegisterEnterDocument");
                }
            }
            else
            {
                FillCombo();
                if (newfilePathName == null)
                {
                    ViewBag.ImageDocumentName = "/upload/documentattach/documentlogo.png";
                }
                else
                {
                    ViewBag.ImageDocumentName = "/upload/documentattach/" + newfilePathName;
                }
                return View("RegisterEnterDocument",model);
            }
        }
    }
}