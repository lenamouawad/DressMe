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

        private ChaussureRepository chaussRepo;

        public ArticleService(HautRepository hautRepo, BasService basServ, BasRepository basRepo, HautsService hautServ, ChaussureRepository chaussRepo)
        {
            this.hautRepo = hautRepo;
            this.basRepo = basRepo;
            this.basServ = basServ;
            this.hautServ = hautServ;
            this.chaussRepo = chaussRepo;
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
                    estFavoris = haut.EstFavoris,
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
                    estFavoris = ba.EstFavoris,
                };
                articles.Add(article);
            }

            var rnd = new Random();
            return articles.OrderBy(item => rnd.Next()).ToList();
        }

        public void EstFavoris(string id, Article article)
        {
            if (article.Category == 1)
            {
                Haut haut = this.hautRepo.FindById(article.IdInCategory);
                this.hautRepo.EstFavoris(article.IdInCategory, haut);
            }
            if (article.Category == 2)
            {
                Bas bas = this.basRepo.FindById(article.IdInCategory);
                this.basRepo.EstFavoris(article.IdInCategory, bas);
            }
            if (article.Category == 3)
            {
                Chaussure chaussure = this.chaussRepo.FindById(article.IdInCategory);
                this.chaussRepo.EstFavoris(article.IdInCategory, chaussure);
            }
        }


        /// <summary>
        /// Returns all favorite articles
        /// </summary>
        /// <returns></returns>
        public List<Article> GetAllArticlesFavoris()
        {
            List<Article> allArticles = GetAllArticles();
            return allArticles.Where(article => article.estFavoris == true).ToList();
        }
    }


}
