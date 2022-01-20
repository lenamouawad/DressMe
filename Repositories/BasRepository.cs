using DressMe.Config;
using DressMe.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Repositories
{
    public class BasRepository
    {
        private readonly IMongoCollection<Bas> repo;

        public BasRepository(DressMeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            repo = database.GetCollection<Bas>(settings.BasCollectionName);
        }

        public Bas FindById(string id)
        {
            return this.repo.Find(b => b.Id == id).FirstOrDefault();
        }

        public List<Bas> FindAll()
        {
            return this.repo.Find(b => true).ToList();
        }

        public void Create(Bas bas)
        {
            this.repo.InsertOne(bas);
        }

        public void Update(string id, Bas bas)
        {
            bas.Id = id;
            this.repo.ReplaceOne(c => c.Id == id, bas);
        }

        public void Delete(string id)
        {
            this.repo.DeleteOne(b => b.Id == id);
        }
    }
}
