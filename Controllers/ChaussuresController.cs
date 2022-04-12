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
    public class ChaussuresController : ControllerBase
    {
        private ChaussuresService service;

        public ChaussuresController(ChaussuresService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Create(Chaussure chaussure)
        {
            return Created("", service.Create(chaussure));
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
        public IActionResult Update(string id, Chaussure chaussure)
        {
            try
            {
                this.service.Update(id, chaussure);
                return Ok($"Le {chaussure.Categorie} avec l'id {id} a été modifié");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("estFavoris/{id}")]
        public IActionResult estFavoris(string id, Chaussure chaussure)
        {
            try
            {
                this.service.EstFavoris(id, chaussure);
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


        [HttpGet("categories/{meteo}")]

        public IActionResult FindByCategories(string meteo)
        {
            try
            {
                return Ok(this.service.FindChaussureByCategories(meteo));
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
        public IActionResult DeleteAllChaussures()
        {
            try
            {
                this.service.DeleteAllChaussures();
                return Ok("Toutes les chaussures ont été supprimés");
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }

        }

        /// <summary>
        /// Returns all non patterned chaussures
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
        /// Returns all patterned chaussures
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
        /// Returns all chaussures with party patterns 
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
        /// Returns all chaussures of a selected category
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
        /// Returns all chaussures of a selected pattern
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
        /// Returns all chaussures of a selected type/occasion
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
