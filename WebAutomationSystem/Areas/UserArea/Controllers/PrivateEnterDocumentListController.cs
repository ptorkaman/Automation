using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.CommonLayer.PublicClass;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize(Roles = "UserAreaPanel")]
    public class PrivateEnterDocumentListController : Controller
    {
        private readonly IForignDocumentRepository _idoc;
        private readonly UserManager<ApplicationUsers> _userManager;

        public PrivateEnterDocumentListController(IForignDocumentRepository idoc,
                                                    UserManager<ApplicationUsers> userManager)
        {
            _idoc = idoc;
            _userManager = userManager;
        }

        public IActionResult Index(byte searchTypeselected = 0,
                                         string inputsearch = "",
                                              string fromdate = "",
                                                string todate = "")
        {
            ViewBag.searchTypeselected = searchTypeselected;
            ViewBag.inputsearch = inputsearch;
            ViewBag.fromdate = fromdate;
            ViewBag.todate = todate;

            if (fromdate == "" || fromdate == null)
            {
                fromdate = "1300/01/01";
            }
            if (todate == "" || todate == null)
            {
                todate = "1600/01/01";
            }

            //
            var model = _idoc.PrivateForeignDocumentList(_userManager.GetUserId(HttpContext.User),
                                                    ConvertDateTime.ConvertShamsiToMiladi(fromdate),
                                                    ConvertDateTime.ConvertShamsiToMiladi(todate),
                                                    searchTypeselected, inputsearch);
            return View(model);
        }
    }
}