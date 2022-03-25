using DressMe.Config;
using DressMe.Interfaces;
using DressMe.Enumerations;
using DressMe.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using DressMe.DTO;

namespace DressMe.Repositories
{
    public class ArticleRepository
    {
        private readonly IMongoCollection<Article> repo;

        public ArticleRepository(IDressMeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            repo = database.GetCollection<Article>(settings.ArticleCollectionName);
        }
    }
}
