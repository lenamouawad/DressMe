using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DressMe.Exceptions;
using DressMe.Models;
using DressMe.Repositories;
using DressMe.Services;
using System.Net;

namespace DressMe.Controllers
{
    //localhost:port/api/tenue
    [Route("api/[controller]")]
    [ApiController]
    public class TenueController : ControllerBase
    {
        private TenueService service;
        public TenueController(TenueService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Returns all outfits
        /// </summary>
        /// <returns></returns>
        [HttpGet("allTenue")]
        public IActionResult GetAllTenue()
        {
            try
            {
                return Ok(this.service.GetAllTenue());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Delete all tenues
        /// </summary>
        /// <returns></returns>
        [HttpDelete("deleteAllTenue")]
        public IActionResult DeleteAllTenue()
        {
            try
            {
                this.service.DeleteAllTenue();
                return Ok("All the outfits are deleted");
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        //POST : localhost:port/api/tenue
        /// <summary>
        /// Creates an outfit
        /// </summary>
        /// <param name="type"></param>
        /// <param name="meteo"></param>
        /// <returns></returns>
        [HttpPost("{meteo}/{type}")]
        public IActionResult ProposerTenue(string meteo, string type)
        {
            try
            {
                return Created("", service.ProposerTenue(meteo, type));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Find tenue DTO by Id
        /// </summary>
        /// <param name="id">tenue id</param>
        /// <returns></returns>
        [HttpGet("id/DTO/{id}")]
        public IActionResult FindTenueDTOById(string id)
        {
            try
            {
                return Ok(this.service.FindDTOById(id));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }




    }
}