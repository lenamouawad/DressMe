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
    //localhost:port/api/hauts
    [Route("api/[controller]")]
    [ApiController]
    public class HautsController : ControllerBase
    {
        private HautsService service;
        public HautsController(HautsService service)
        {
            this.service = service;
        }

        //POST : localhost:port/api/hauts
        /// <summary>
        /// Adds a top to the database
        /// </summary>
        /// <param name="haut">Top to create</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddHaut(Haut haut)
        {
            try
            {
                return Created("", service.AddHaut(haut));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Modify a top
        /// </summary>
        /// <param name="id">top id </param>
        /// <param name="hautUpdated">top with new info</param>
        /// <returns>updated room info</returns>
        [HttpPut("update")]
        public IActionResult UpdateHaut(String id, Haut hautUpdated)
        {
            try
            {
                return Ok(service.UpdateHaut(id, hautUpdated));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("estFavoris/{id}")]
        public IActionResult estFavoris(string id)
        {
            try
            {
                this.service.EstFavoris(id);
                return Ok($"L'article a été mise a jour");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("AllFavoris")]
        public IActionResult FindAllFavoris()
        {
            return Ok(this.service.FindAllFavoris());
        }

        /// <summary>
        /// Delete Top
        /// </summary>
        /// <param name="id">Top id</param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteHaut(string id)
        {
            try
            {
                this.service.DeleteHaut(id);
                return Ok("The top was deleted");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete all Tops
        /// </summary>
        /// <returns></returns>
        [HttpDelete("deleteAllHaut")]
        public IActionResult DeleteAllHaut()
        {
            try
            {
                this.service.DeleteAllHaut();
                return Ok("All the tops are deleted");
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        /// <summary>
        /// Returns all tops
        /// </summary>
        /// <returns></returns>
        [HttpGet("allHauts")]
        public IActionResult GetAllHauts()
        {
            try
            {
                return Ok(this.service.GetAllHauts());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Returns the top with the given id
        /// </summary>
        /// <param name="id">Top id</param>
        /// <returns></returns>
        [HttpGet("id/{id}")]
        public IActionResult GetHautById(string id)
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

        /// <summary>
        /// Returns all tops of a selected fabric
        /// </summary>
        /// <param name="matiere"></param>
        /// <returns></returns>
        [HttpGet("matiere/{matiere}")]
        public IActionResult GetAllByMatiere(string matiere)
        {
            try
            {
                return Ok(this.service.GetAllByMatiere(matiere));
            }
            catch (NotFoundException e)
            {
                return NotFound("La matière choisie n'est pas valide.");
            }
        }

        /// <summary>
        /// Returns all tops of a selected fabric
        /// </summary>
        /// <param name="manche"></param>
        /// <returns></returns>
        [HttpGet("manches/{manche}")]
        public IActionResult GetAllByManche(string manche)
        {
            try
            {
                return Ok(this.service.GetAllByManche(manche));
            }
            catch (NotFoundException e)
            {
                return NotFound("Le type de manche choisi n'est pas valide");
            }
        }

        /// <summary>
        /// Returns all non patterned tops
        /// </summary>
        /// <returns></returns>
        [HttpGet("sansMotifs")]
        public IActionResult GetNoPattern()
        {
            try
            {
                return Ok(this.service.GetNoPattern());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Returns all patterned tops
        /// </summary>
        /// <returns></returns>
        [HttpGet("avecMotifs")]
        public IActionResult GetWithPattern()
        {
            try
            {
                return Ok(this.service.GetWithPattern());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Returns all tops with party patterns 
        /// </summary>
        /// <returns></returns>
        [HttpGet("motifsDeFete")]
        public IActionResult GetPartyPattern()
        {
            try
            {
                return Ok(this.service.GetPartyPattern());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Returns all tops of a selected category
        /// </summary>
        /// <returns></returns>
        [HttpGet("categorie/{categorie}")]
        public IActionResult GetByCategorie(string categorie)
        {
            try
            {
                return Ok(this.service.GetByCategorie(categorie));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        /// <summary>
        /// Returns all tops of a selected pattern
        /// </summary>
        /// <returns></returns>
        [HttpGet("motif/{motif}")]
        public IActionResult GetByMotif(string motif)
        {
            try
            {
                return Ok(this.service.GetByMotif(motif));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        /// <summary>
        /// Returns all tops of a selected type/occasion
        /// </summary>
        /// <returns></returns>
        [HttpGet("type/{type}")]
        public IActionResult GetByType(string type)
        {
            try
            {
                return Ok(this.service.GetByType(type));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

    }
}