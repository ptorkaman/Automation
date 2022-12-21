using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "AdminAreaPanel")]
    public class CartableController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public CartableController(IUnitOfWork context, IMapper mapper)
        {
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
    }
}
