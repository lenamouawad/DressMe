using Microsoft.AspNetCore.Mvc;
using DressMe.Exceptions;
using DressMe.Services;
using System;

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
    }
}
