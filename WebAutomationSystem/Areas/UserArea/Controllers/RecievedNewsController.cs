using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class RecievedNewsController : Controller
    {
        private readonly IMediator _mediator;
        public RecievedNewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _mediator.Send(new GetAllNewsCommandModel());
            return View(model);
        }

        [HttpGet]
        public IActionResult DisplayNews(string NewsDate,
                                            string NewsTitle,
                                                string NewsContent)
        {
            ViewBag.NewsDate = NewsDate;
            ViewBag.NewsTitle = NewsTitle;
            ViewBag.NewsContent = NewsContent;
            return PartialView("_DisplayNews");
        }
    }
}