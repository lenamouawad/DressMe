using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DressMe.Config;
using DressMe.Models;
using MongoDB.Driver;

namespace DressMe.Repositories
{
    public class ChemiseRepository
    {
        private readonly IMongoCollection<Chemise> chemises;
        public ChemiseRepository(IDressMeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            chemises = database.GetCollection<Chemise>(settings.ChemiseCollectionName);
        }

        /// <summary>
        /// Adds a chemise to the database
        /// </summary>
        /// <param name="dress">Added chemise</param>
        /// <returns>List of all chemises in the dressing</returns>
        public List<Chemise> AddChemise(Chemise chemise)
        {
            this.chemises.InsertOne(chemise);
            return this.chemises.Find(movie => true).ToList();
        }
    }
}
