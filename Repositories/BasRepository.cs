using DressMe.Config;
using DressMe.Interfaces;
using DressMe.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DressMe.Repositories
{
    public class BasRepository
    {
        private readonly IMongoCollection<Bas> repo;

        public BasRepository(IDressMeDatabaseSettings settings)
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

        public List<Bas> Create(Bas bas)
        {
            this.repo.InsertOne(bas);
            return this.repo.Find(bas => true).ToList();

        }

        public void Update(string id, Bas bas)
        {
            bas.Id = id;
            this.repo.ReplaceOne(b => b.Id == id, bas);
        }

        public void Delete(string id)
        {
            this.repo.DeleteOne(b => b.Id == id);
        }

        public List<Bas> FindByCategorie(string categorie)
        {
            List<Bas> basByCategorie = new List<Bas>() { };
            if (Enum.TryParse<CategorieBas>(categorie, out CategorieBas tryParseResult))
            {
                basByCategorie = this.repo.Find(bas => bas.Categorie == tryParseResult).ToList();
            }

            return basByCategorie;
        }

        public List<Bas> FindByMatiere(string matiere)
        {
            List<Bas> basByMatiere = new List<Bas>() { };
            if (Enum.TryParse<Matiere>(matiere, out Matiere tryParseResult))
            {
                basByMatiere = this.repo.Find(bas => bas.Matiere == tryParseResult).ToList();
            }

            return basByMatiere;
        }

        public List<Bas> FindByMotif(string motif)
        {
            List<Bas> basByMotif = new List<Bas>() { };
            if (Enum.TryParse<Motifs>(motif, out Motifs tryParseResult))
            {
                basByMotif = this.repo.Find(bas => bas.Motifs == tryParseResult).ToList();
            }

            return basByMotif;
        }

        public List<Bas> FindByType(string type)
        {
            List<Bas> basByType = new List<Bas>() { };
            if (Enum.TryParse<Types>(type, out Types tryParseResult))
            {
                basByType = this.repo.Find(bas => bas.Type == tryParseResult).ToList();
            }

            return basByType;
        }

        public List<Bas> FindNoPattern()
        {
            Enum.TryParse<Motifs>("pasDeMotifs", out Motifs noMotif);
            return this.repo.Find(bas => bas.Motifs == noMotif).ToList();
        }


        public List<Bas> FindWithPattern()
        {
            Enum.TryParse<Motifs>("pasDeMotifs", out Motifs noMotif);
            return this.repo.Find(bas => bas.Motifs != noMotif).ToList();
        }


        public List<Bas> FindPartyPattern()
        {

            Enum.TryParse<Motifs>("paillettes", out Motifs paillettes);
            Enum.TryParse<Motifs>("strass", out Motifs strass);
            Enum.TryParse<Motifs>("perles", out Motifs perles);

            return this.repo.Find(bas => bas.Motifs == paillettes || bas.Motifs == strass || bas.Motifs == perles).ToList();
        }

        /// <summary>
        /// Delete all Bas
        /// </summary>
        /// <returns></returns>
        public List<Bas> DeleteAllBas()
        {
            this.repo.DeleteMany(bas => true);
            return this.repo.Find(bas => true).ToList();
        }
    }
}
