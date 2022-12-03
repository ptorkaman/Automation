using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class RolePatternController : Controller
    {

        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IRoleRepository _irr;

        public RolePatternController(IUnitOfWork context, IMapper mapper, IRoleRepository irr)
        {
            _context = context;
            _mapper = mapper;
            _irr = irr;
        }

        public IActionResult Index()
        {
            return View(_context.rolePatternUW.Get());
        }

        [HttpGet]
        public IActionResult AddRolePattern()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRolePattern(RolePatternViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.rolePatternUW.Create(_mapper.Map<RolePattern>(model));
                _context.save();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int RolePatternID)
        {
            if (RolePatternID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            return View(_mapper.Map<RolePatternViewModel>(_context.rolePatternUW.GetById(RolePatternID)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RolePatternViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.rolePatternUW.Update(_mapper.Map<RolePattern>(model));
                _context.save();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SetAccessToRolePattern(string RolePatternName, int RolePatternID)
        {
            ViewBag.RolePatternName = RolePatternName;
            ViewBag.RolePatternID = RolePatternID;
            ViewBag.getRolePatternID = _irr.GetRolePatternId(RolePatternID);
            FillTreeView();
            return View();
        }

        [HttpPost]
        public IActionResult SetAccessToRolePatternPost(string SelectedItems, int RolePatternID)
        {

            using (var transaction = _context.BeginTransaction())
            {
                try
                {
                    List<TreeViewModel> items = JsonConvert.DeserializeObject<List<TreeViewModel>>(SelectedItems);
                    if (items.Count() == 0)
                    {
                        return Json(new { status = "noselected" });
                    }

                    //حذف همه دسترسیهای نقش
                    _context.rolePatternDetailsUW.DeleteByRange(rp => rp.RolePatternID == RolePatternID);
                    //ثبت دسترسی های جدید
                    for (int i = 0; i <= items.Count() - 1; i++)
                    {
                        RolePatternDetails RP = new RolePatternDetails
                        {
                            RolePatternID = RolePatternID,
                            RoleID = items[i].id
                        };
                        _context.rolePatternDetailsUW.Create(RP);
                    }
                    transaction.Commit();
                    _context.save();
                    return Json(new { status = "success" });
                }
                catch
                {
                    transaction.RollBack();
                    return Json(new { status = "error" });
                }
            }
         
        }

        private void FillTreeView()
        {
            List<TreeViewModel> node = new List<TreeViewModel>();

            node.Add(new TreeViewModel
            {
                id = "1",
                text = "حقوق دسترسی",
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

            ViewBag.AccessRight = JsonConvert.SerializeObject(node);
        }
    }
}