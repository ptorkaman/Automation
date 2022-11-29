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
    public class JobsChartController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public JobsChartController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<TreeViewModel> node = new List<TreeViewModel>();

            node.Add(new TreeViewModel
            {
                id = "1",
                text = "مدیر عامل",
                parent = "#"
            });

            foreach (JobsChart job in _context.jobsChartUW.Get(j => j.JobsChartLevel != 0))
            {
                node.Add(new TreeViewModel
                {
                    id = job.JobsChartID.ToString(),
                    parent = job.JobsChartLevel.ToString(),
                    text = job.JobsChartName
                });
            }

            ViewBag.JobJson = JsonConvert.SerializeObject(node);
            return View();
        }

        [HttpGet]
        public IActionResult AddJobsChart(int id, string parentname)
        {
            ViewBag.parentname = parentname;
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddJobsChart(JobsChartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapModel = _mapper.Map<JobsChart>(model);
                _context.jobsChartUW.Create(mapModel);
                _context.save();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditJobsChart(int id, string parentname)
        {
            if (id == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var jobschart = _context.jobsChartUW.GetById(id);
            var mapModel = _mapper.Map<JobsChartViewModel>(jobschart);
            if (mapModel != null)
            {
                return View(mapModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditJobsChart(JobsChartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var jobMapper = _mapper.Map<JobsChart>(model);
                _context.jobsChartUW.Update(jobMapper);
                _context.save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}