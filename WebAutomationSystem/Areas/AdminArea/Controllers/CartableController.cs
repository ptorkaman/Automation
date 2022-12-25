using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "AdminAreaPanel")]
    public class CartableController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IUserJobRepository _iusertjob;

        public CartableController(IUnitOfWork context, IMapper mapper,IUserJobRepository iusertjob)
        {
            _iusertjob = iusertjob;
            _context = context;
            _mapper= mapper;    
        }
    
        // GET: CartableController
        public ActionResult Index()
        {
            return View(_context.cartableUW.Get());
        }

        // GET: CartableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cartable model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.cartableUW.Create(model);
                    _context.save();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: CartableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.cartableUW.Get(x=>x.Id==id).FirstOrDefault());
        }

        // POST: CartableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cartable model, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.cartableUW.Update(model);
                    _context.save();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: CartableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartableController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: CartableController/AssignUserTocartable/5
        public ActionResult AssignUserTocartable(int id)
        {
            CartableUserViewModel model = new CartableUserViewModel();
            model.CartableId = id;
            List<UserWithJobNameViewModel> ListUserWithJob = _iusertjob.UserFullNameWithJobName();
            ViewBag.ListUserWithJob = ListUserWithJob;
            ViewBag.Title = _context.cartableUW.Get(x => x.Id == id).FirstOrDefault().Title;
            List<TreeViewModel> node = new List<TreeViewModel>();

            node.Add(new TreeViewModel
            {
                id = "1",
                text = "مدیر عامل",
                parent = "#"
            });

            foreach (JobsChart job in _context.jobsChartUW.Get(j => j.JobsChartLevel != 0))
            {
                foreach (var item in ListUserWithJob)
                {
                    if (job.JobsChartID == item.JobId)
                        job.JobsChartName += " <span style='color:green;'>( " + item.UserFullNameWithJob + " )</span>";
                }
                node.Add(new TreeViewModel
                {
                    id = job.JobsChartID.ToString(),
                    parent = job.JobsChartLevel.ToString(),
                    text = job.JobsChartName
                });
            }
     
            ViewBag.JobJson = JsonConvert.SerializeObject(node);
            return View(model);
        }

        // POST: CartableController/AssignUserTocartable/5
        [HttpPost]
        public ActionResult AssignUserTocartable(int id,string selectedItems,int cartableId)
        {
            using (var transaction = _context.BeginTransaction())
            {
                try
                {
                    List<TreeViewModel> items = JsonConvert.DeserializeObject<List<TreeViewModel>>(selectedItems);
                    if (items.Count() == 0)
                    {
                        return Json(new { status = "noselected" });
                    }

                    //حذف همه  کاربرها از کارتابل
                    _context.cartableUserUW.DeleteByRange(rp => rp.CartableId == id);
                    //ثبت کاربرهای جدید
                    for (int i = 0; i <= items.Count() - 1; i++)
                    {
                        CartableUser cartableUser = new CartableUser
                        {
                            CartableId = id,
                            UserId = items[i].id
                        };
                        _context.cartableUserUW.Create(cartableUser);
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
