using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAutomationSystem.DataModelLayer.Entities;
using WebAutomationSystem.DataModelLayer.Services;

namespace WebAutomationSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdministrativeFormApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        public AdministrativeFormApiController(IUnitOfWork context)
        {
            _context = context;
        }

        //api/AdministrativeFormApi
        [HttpGet]
        public IEnumerable<AdministrativeForm> GetAllAdministrativeForm()
        {
            return _context.administrativeFormUW.Get();
        }

        //api/AdministrativeFormApi/4
        [HttpGet("{id}")]
        public AdministrativeForm GetFormById(int id)
        {
            var model = _context.administrativeFormUW.GetById(id);
            if (model == null)
            {
                NotFound();
            }
            return model;
        }

        //api/AdministrativeFormApi
        [HttpPost]
        public IActionResult Create([FromBody] AdministrativeForm model)
        {
            _context.administrativeFormUW.Create(model);
            _context.save();

            return Ok();
        }

        //api/AdministrativeFormApi/4
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] AdministrativeForm model)
        {
            var query = _context.administrativeFormUW.GetById(model.Id);
            if (query == null)
            {
                NotFound();
            }
            query.AdministrativeFormTitle = model.AdministrativeFormTitle;
            query.AdministrativeFormContent = model.AdministrativeFormContent;
            query.AdministrativeFormType = model.AdministrativeFormType;

            _context.administrativeFormUW.Update(query);
            _context.save();

            return Ok();
        }

        //api/AdministrativeFormApi/4
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var query = _context.administrativeFormUW.GetById(id);
            if (query == null)
            {
                NotFound();
            }
            _context.administrativeFormUW.Delete(query);
            _context.save();

            return NoContent();
        }
    }
}