using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.CommonLayer.Services;
using WebAutomationSystem.DataModelLayer;
using WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "AdminAreaPanel")]
    public class NewsController : Controller
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUploadFiles _upload;

        //
        private readonly IMediator _mediator;

        public NewsController(IUploadFiles upload,
                                 UserManager<ApplicationUsers> userManager,
                                     IMediator mediator)
        {
            _upload = upload;
            _userManager = userManager;
            _mediator = mediator;
        }
        //کاهش وابستگی ها
        //خالص کردن کلاس - یعنی هر کلاس فقط یک عملیات را انجام می دهد و ورودی و خروجی مشخصی دارد
        public async Task<IActionResult> Index()
        {
            //Select
            var model = await _mediator.Send(new GetAllNewsCommandModel());
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNews(NewsCreateCommandModel model, string newfilePathName)
        {
            if (ModelState.IsValid)
            {
                //insert
                model.UserID = _userManager.GetUserId(HttpContext.User);
                model.NewsAttachment = newfilePathName;
                int getNewsID = await _mediator.Send(model);
                return RedirectToAction("Index");
            }
            return View(model);
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

        [HttpGet]
        public async Task<IActionResult> EditNews(int NewsID)
        {
            if (NewsID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var model = await _mediator.Send(new NewsGetByIdModel { NewsID = NewsID });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNews(NewsUpdateCommandModel model,
                                                    string newfilePathName,
                                                        string OldAttachmentName)
        {
            if (ModelState.IsValid)
            {
                if (newfilePathName != null)
                {
                    model.NewsAttachment = newfilePathName;
                }
                if (model.NewsAttachment == null)
                {
                    model.NewsAttachment = OldAttachmentName;
                }

                await _mediator.Send(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteNews(int NewsID)
        {
            if (NewsID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.NewsID = NewsID;
            return PartialView("_DeleteNews");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNewsPost(int NewsID)
        {
            await _mediator.Send(new DeActiveCommandModel { NewsID = NewsID });
            return RedirectToAction("Index");
        }
    }
}