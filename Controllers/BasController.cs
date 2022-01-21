using DressMe.Exceptions;
using DressMe.Models;
using DressMe.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasController : ControllerBase
    {
        private BasService service;

        public BasController(BasService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Create(Bas bas)
        {
            return Created("", service.Create(bas));
        }

        [HttpGet("{id}")]
        public IActionResult FindById(string id)
        {
            try
            {
                return Ok(this.service.FindById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(this.service.FindAll());
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Bas bas)
        {
            try
            {
                this.service.Update(id, bas);
                return Ok($"Le {bas.Categorie} avec l'id {id} été modifier");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                this.service.Delete(id);
                return Ok("L'article a été supprimé");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
