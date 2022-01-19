using DressMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using DressMe.Config;

namespace DressMe.Repositories
{
    public class RobeRepository
    {
        private readonly IMongoCollection<Robe> dresses;
        public RobeRepository(IDressMeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            dresses = database.GetCollection<Robe>(settings.RobeCollectionName);
        }

        /// <summary>
        /// Adds a dress to the database
        /// </summary>
        /// <param name="dress">Added dress</param>
        /// <returns>List of all dresses in the dressing</returns>
        public List<Robe> AddDress(Robe dress)
        {
            this.dresses.InsertOne(dress);
            return this.dresses.Find(movie => true).ToList();
        }
    }
}
