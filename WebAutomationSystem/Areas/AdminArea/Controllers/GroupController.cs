using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;
using WebAutomationSystem.DataModelLayer.ViewModels;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "AdminAreaPanel")]
    public class GroupController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IUserJobRepository _iusertjob;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserJobRepository _userJobRepository;

        public GroupController(IUnitOfWork context, IMapper mapper,IUserJobRepository iusertjob, IGroupRepository groupRepository, IUserJobRepository userJobRepository)
        {
            _iusertjob = iusertjob;
            _context = context;
            _mapper= mapper;   
            _groupRepository= groupRepository;  
            _userJobRepository= userJobRepository;  
        }
    
        // GET: GroupController
        public ActionResult Index()
        {
            var data = _groupRepository.GetAll();
            return View(_groupRepository.GetAll());
        }

        // GET: GroupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.groupUW.Create(model);
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

        // GET: GroupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.groupUW.Get(x=>x.Id==id).FirstOrDefault());
        }

        // POST: GroupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Group model, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.groupUW.Update(model);
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

        // GET: GroupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GroupController/Delete/5
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



        // GET: GroupController/AssignUserToGroup/5
        public ActionResult AssignUserToGroup(int id)
        {
            GroupUserViewModel model = new GroupUserViewModel();
            model.GroupId = id;
            List<UserWithJobNameViewModel> ListUserWithJob = _iusertjob.UserFullNameWithJobName();
            ViewBag.ListUserWithJob = ListUserWithJob;
            ViewBag.Title = _context.groupUW.Get(x => x.Id == id).FirstOrDefault().Title;
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

        // POST: GroupController/AssignUserToGroup/5
        [HttpPost]
        public ActionResult AssignUserToGroup(int id,string selectedItems,int groupId)
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
                    _context.groupUserUW.DeleteByRange(rp => rp.GroupId == id);
                    //ثبت کاربرهای جدید
                    for (int i = 0; i <= items.Count() - 1; i++)
                    {
                        var user=_userJobRepository.GetByJobId(Convert.ToInt32( items[i].id));
                        if (user != null)
                        {
                            GroupUser groupUser = new GroupUser
                            {
                                GroupId = id,
                                UserId = user.UserID
                            };
                            _context.groupUserUW.Create(groupUser);
                        }
                        
                    }
                    transaction.Commit();
                    _context.save();
                    return Json(new { status = "success" });
                }
                catch(Exception ex) 
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
