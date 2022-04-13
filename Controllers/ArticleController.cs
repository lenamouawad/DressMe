using Microsoft.AspNetCore.Mvc;
using DressMe.Exceptions;
using DressMe.Services;
using System;
using DressMe.DTO;

namespace DressMe.Controllers
{
    //localhost:port/api/article
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private ArticleService service;
        public ArticleController(ArticleService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Returns all tops
        /// </summary>
        /// <returns></returns>
        [HttpGet("allArticles")]
        public IActionResult GetAllArticles()
        {
            try
            {
                return Ok(this.service.GetAllArticles());
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
        [HttpGet("favoris")]
        public IActionResult GetAllArticlesFavoris()
        {
            try
            {
                return Ok(this.service.GetAllArticlesFavoris());
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("estFavoris/{id}")]
        public IActionResult estFavoris(string id, Article article)
        {
            try
            {
                this.service.EstFavoris(id, article);
                return Ok($"L'article a été mise a jour");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
