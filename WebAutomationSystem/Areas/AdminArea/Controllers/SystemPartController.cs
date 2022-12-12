using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class SystemPartController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly RoleManager<ApplicationRoles> _roleManaegr;

        public SystemPartController(IUnitOfWork context, IMapper mapper, RoleManager<ApplicationRoles> roleManaegr)
        {
            _context = context;
            _mapper = mapper;
            _roleManaegr = roleManaegr;
        }

        public IActionResult Index()
        {
            FillTreeView();
            return View();
        }

        private void FillTreeView()
        {
            List<TreeViewModel> node = new List<TreeViewModel>();

            node.Add(new TreeViewModel
            {
                id = "1",
                text = "اجزای سیستم",
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

            ViewBag.SystemPart = JsonConvert.SerializeObject(node);
        }

        [HttpGet]
        public IActionResult AddSystemPart(string id, string parentname)
        {
            ViewBag.parentname = parentname;
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSystemPart(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapModel = _mapper.Map<ApplicationRoles>(model);
                IdentityResult roleResult = await _roleManaegr.CreateAsync(mapModel);
                if (roleResult.Succeeded)
                {
                    FillTreeView();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}