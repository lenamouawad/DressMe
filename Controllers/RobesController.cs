using DressMe.Models;
using DressMe.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class RobesController : ControllerBase
    {
        private RobesService service;

        public RobesController(RobesService service)
        {
            this.service = service;
        }

        //POST : localhost:port/api/robes
        /// <summary>
        /// Add a dress
        /// </summary>
        /// <param name="dress">Dress to add</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddDress(Robe dress)
        {
            return Created("", service.AddDress(dress));
        }
        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
