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
                return Ok($"Le {bas.Categorie} avec l'id {id} a été modifié");
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

        
        [HttpGet("matiere/{matiere}")]
        public IActionResult FindByMatiere(string matiere)
        {
            try
            {
                return Ok(this.service.FindByMatiere(matiere));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        

        

        /// <summary>
        /// Delete all Bas
        /// </summary>
        /// <returns></returns>
        [HttpDelete("deleteAllBas")]
        public IActionResult DeleteAllBas()
        {
            try
            {
                this.service.DeleteAllBas();
                return Ok("Tous les bas ont été supprimés");
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        /// <summary>
        /// Returns all non patterned bas
        /// </summary>
        /// <returns></returns>
        [HttpGet("sansMotifs")]
        public IActionResult FindNoPattern()
        {
            try
            {
                return Ok(this.service.FindNoPattern());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Returns all patterned bas
        /// </summary>
        /// <returns></returns>
        [HttpGet("avecMotifs")]
        public IActionResult FindWithPattern()
        {
            try
            {
                return Ok(this.service.FindWithPattern());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Returns all bas with party patterns 
        /// </summary>
        /// <returns></returns>
        [HttpGet("motifsDeFete")]
        public IActionResult FindPartyPattern()
        {
            try
            {
                return Ok(this.service.FindPartyPattern());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Returns all bas of a selected category
        /// </summary>
        /// <returns></returns>
        [HttpGet("categorie/{categorie}")]
        public IActionResult FindByCategorie(string categorie)
        {
            try
            {
                return Ok(this.service.FindByCategorie(categorie));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        /// <summary>
        /// Returns all bas of a selected pattern
        /// </summary>
        /// <returns></returns>
        [HttpGet("motif/{motif}")]
        public IActionResult FindByMotif(string motif)
        {
            try
            {
                return Ok(this.service.FindByMotif(motif));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        /// <summary>
        /// Returns all bas of a selected type/occasion
        /// </summary>
        /// <returns></returns>
        [HttpGet("type/{type}")]
        public IActionResult FindByType(string type)
        {
            try
            {
                return Ok(this.service.FindByType(type));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }
    }
}
