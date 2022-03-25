using DressMe.DTO;
using DressMe.Enumerations;
using DressMe.Exceptions;
using DressMe.Interfaces;
using DressMe.Models;
using DressMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Services
{
    public class ArticleService
    {
        private HautRepository hautRepo;
        private BasRepository basRepo;

        private BasService basServ;
        private HautsService hautServ;

        public ArticleService(HautRepository hautRepo, BasService basServ, BasRepository basRepo, HautsService hautServ)
        {
            this.hautRepo = hautRepo;
            this.basRepo = basRepo;
            this.basServ = basServ;
            this.hautServ = hautServ;
        }

        /// <summary>
        /// Returns all articles
        /// </summary>
        /// <returns></returns>
        public List<Article> GetAllArticles()
        {
            List<Haut> hauts = this.hautRepo.GetAllHauts();
            List<Bas> bas = this.basRepo.FindAll();

            List<Article> articles = new List<Article>();

            foreach(Haut haut in hauts)
            {
                Article article = new Article
                {
                    IdInCategory = haut.Id,
                    Category = 1,
                    ImgUrl = haut.ImgUrl,
                };
                articles.Add(article);
            }

            foreach (Bas ba in bas)
            {
                Article article = new Article
                {
                    IdInCategory = ba.Id,
                    Category = 2,
                    ImgUrl = ba.ImgUrl,
                };
                articles.Add(article);
            }

            var rnd = new Random();
            return articles.OrderBy(item => rnd.Next()).ToList();
        }
    }


}
