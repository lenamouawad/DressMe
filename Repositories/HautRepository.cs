using DressMe.Config;
using DressMe.Exceptions;
using DressMe.Interfaces;
using DressMe.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Repositories
{
    public class HautRepository
    {
        private readonly IMongoCollection<Haut> hauts;
        public HautRepository(IDressMeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            hauts = database.GetCollection<Haut>(settings.HautCollectionName);
        }

        /// <summary>
        /// Creates a top and adds it to the database
        /// </summary>
        /// <param name="haut">Created top</param>
        /// <returns>List of all tops</returns>
        public List<Haut> AddHaut(Haut haut)
        {
            this.hauts.InsertOne(haut);
            return this.hauts.Find(haut => true).ToList();
        }

        /// <summary>
        /// Modify a top
        /// </summary>
        /// <param name="id">top id </param>
        /// <param name="hautUpdated">top with new info</param>
        /// <returns>updated top info</returns>
        public Haut UpdateHaut(String id, Haut hautUpdated)
        {
            hautUpdated.Id = id;
            this.hauts.FindOneAndReplace(haut => haut.Id == id, hautUpdated);
            return this.hauts.Find(haut => haut.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Delete Top
        /// </summary>
        /// <param name="id">Top id</param>
        /// <returns></returns>
        public List<Haut> DeleteHaut(string id)
        {
            this.hauts.DeleteOne(haut => haut.Id == id);
            return this.hauts.Find(haut => true).ToList();
        }

        /// <summary>
        /// Delete all Tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> DeleteAllHaut()
        {
            this.hauts.DeleteMany(haut => true);
            return this.hauts.Find(haut => true).ToList();
        }

        /// <summary>
        /// Returns all hauts
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetAllHauts()
        {
            return this.hauts.Find(haut => true).ToList();
        }

        /// <summary>
        /// Returns the haut with the given id
        /// </summary>
        /// <param name="id">Id of the haut</param>
        /// <returns></returns>
        public Haut FindById(string id)
        {
            return this.hauts.Find(haut => haut.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Returns all tops of a selected fabric
        /// </summary>
        /// <param name="matiere"></param>
        /// <returns></returns>
        public List<Haut> GetAllByMatiere(string matiere)
        {
            List<Haut> hautsDeMatiere = new List<Haut>() {};
            Matiere tryParseResult;
            if (Enum.TryParse<Matiere>(matiere, out tryParseResult))
            {
                hautsDeMatiere = this.hauts.Find(haut => haut.Matiere == tryParseResult).ToList();
            }
            else
            {
                // input string is not a valid enum Matiere
                throw new NotFoundException($"La matière choisie n'est pas valide.");
            }

            return hautsDeMatiere;
        }

        /// <summary>
        /// Returns all tops of a selected sleeve length
        /// </summary>
        /// <param name="manche"></param>
        /// <returns></returns>
        public List<Haut> GetAllByManche(string manche)
        {
            List<Haut> hautsDeManche = new List<Haut>() { };
            Manches tryParseResult;
            if (Enum.TryParse<Manches>(manche, out tryParseResult))
            {
                hautsDeManche = this.hauts.Find(haut => haut.Manches == tryParseResult).ToList();
            }
            else
            {
                // input string is not a valid enum Matiere
                throw new NotFoundException($"Le type de manche choisi n'est pas valide");
            }

            return hautsDeManche;
        }

    }
}
