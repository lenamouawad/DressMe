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
    public class ChemisesController : ControllerBase
    {
        private ChemisesService service;

        public ChemisesController(ChemisesService service)
        {
            this.service = service;
        }

        //POST : localhost:port/api/chemises
        /// <summary>
        /// Add a chemise
        /// </summary>
        /// <param name="chemise">Chemise to add</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddChemise(Chemise chemise)
        {
            return Created("", service.AddChemise(chemise));
        }

    }
}
