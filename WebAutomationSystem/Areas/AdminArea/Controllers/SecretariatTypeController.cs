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
    public class SecretariatTypeController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IUserJobRepository _iusertjob;

        public SecretariatTypeController(IUnitOfWork context, IMapper mapper,IUserJobRepository iusertjob)
        {
            _iusertjob = iusertjob;
            _context = context;
            _mapper= mapper;    
        }
    
        // GET: SecretariatTypeController
        public ActionResult Index()
        {
            return View(_context.secretariatTypeUW.Get());
        }

        // GET: SecretariatTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SecretariatTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecretariatTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SecretariatType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.secretariatTypeUW.Create(model);
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

        // GET: SecretariatTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.secretariatTypeUW.Get(x=>x.Id==id).FirstOrDefault());
        }

        // POST: SecretariatTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SecretariatType model, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.secretariatTypeUW.Update(model);
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

        // GET: SecretariatTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SecretariatTypeController/Delete/5
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



        // GET: SecretariatTypeController/AssignUserTosecretariatType/5
        public ActionResult AssignUserTosecretariatType(int id)
        {
            //SecretariatTypeViewModel model = new SecretariatTypeViewModel();
            //model.SecretariatTypeId = id;
            //List<UserWithJobNameViewModel> ListUserWithJob = _iusertjob.UserFullNameWithJobName();
            //ViewBag.ListUserWithJob = ListUserWithJob;
            //ViewBag.Title = _context.secretariatTypeUW.Get(x => x.Id == id).FirstOrDefault().Title;
            //List<TreeViewModel> node = new List<TreeViewModel>();

            //node.Add(new TreeViewModel
            //{
            //    id = "1",
            //    text = "مدیر عامل",
            //    parent = "#"
            //});

            //foreach (JobsChart job in _context.jobsChartUW.Get(j => j.JobsChartLevel != 0))
            //{
            //    foreach (var item in ListUserWithJob)
            //    {
            //        if (job.JobsChartID == item.JobId)
            //            job.JobsChartName += " <span style='color:green;'>( " + item.UserFullNameWithJob + " )</span>";
            //    }
            //    node.Add(new TreeViewModel
            //    {
            //        id = job.JobsChartID.ToString(),
            //        parent = job.JobsChartLevel.ToString(),
            //        text = job.JobsChartName
            //    });
            //}
     
            //ViewBag.JobJson = JsonConvert.SerializeObject(node);
            return View();
        }

        // POST: SecretariatTypeController/AssignUserTosecretariatType/5
        [HttpPost]
        public ActionResult AssignUserTosecretariatType(int id,string selectedItems,int secretariatTypeId)
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
                    //_context.secretariatTypeUserUW.DeleteByRange(rp => rp.SecretariatTypeId == id);
                    ////ثبت کاربرهای جدید
                    //for (int i = 0; i <= items.Count() - 1; i++)
                    //{
                    //    SecretariatTypeUser secretariatTypeUser = new SecretariatTypeUser
                    //    {
                    //        SecretariatTypeId = id,
                    //        UserId = items[i].id
                    //    };
                    //    _context.secretariatTypeUserUW.Create(secretariatTypeUser);
                    //}
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
