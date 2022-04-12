using DressMe.Config;
using DressMe.Interfaces;
using DressMe.Enumerations;
using DressMe.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DressMe.Repositories
{
    public class ChaussureRepository
    {
        private readonly IMongoCollection<Chaussure> repo;
        private StringToEnumConversions conversion;

        public ChaussureRepository(IDressMeDatabaseSettings settings, StringToEnumConversions conversion)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            this.conversion = conversion;
            repo = database.GetCollection<Chaussure>(settings.BasCollectionName);
        }

        public Chaussure FindById(string id)
        {
            return this.repo.Find(c => c.Id == id).FirstOrDefault();
        }

        public List<Chaussure> FindAll()
        {
            return this.repo.Find(c => true).ToList();
        }

        public List<Chaussure> Create(Chaussure chaussure)
        {
            this.repo.InsertOne(chaussure);
            return this.repo.Find(chaussure => true).ToList();

        }

        public void Update(string id, Chaussure chaussure)
        {
            chaussure.Id = id;
            this.repo.ReplaceOne(c => c.Id == id, chaussure);
        }

        public void Delete(string id)
        {
            this.repo.DeleteOne(c => c.Id == id);
        }

        /// <summary>
        /// Retourne les chaussures dans la bdd qui ont une catégorie donnée
        /// </summary>
        /// <returns></returns>
        public List<Chaussure> FindByCategorie(string categorie)
        {
            List<Chaussure> chaussuresByCategorie = new List<Chaussure>() { };
            if (Enum.TryParse<CategorieChaussure>(categorie, out CategorieChaussure tryParseResult))
            {
                chaussuresByCategorie = this.repo.Find(c => c.Categorie == tryParseResult).ToList();
            }

            return chaussuresByCategorie;
        }

        /// <summary>
        /// Mettre un article en favoris ou non
        /// </summary>
        /// <param name="id"></param>
        public void EstFavoris(string id, Chaussure chaussure)
        {
            Chaussure c = FindById(id);
            c.EstFavoris = !c.EstFavoris;
            Update(id, c);
        }

        /// <summary>
        /// Recuperer tous les articles favoris
        /// </summary>
        /// <returns></returns>
        public List<Chaussure> FindAllFavoris()
        {
            return this.repo.Find(c => c.EstFavoris == true).ToList();
        }


        /// <summary>
        /// Retourne les chaussures dans la bdd qui ont une catégorie parmi une liste de catégories
        /// </summary>
        /// <returns></returns>
        public List<Chaussure> FindByCategories(List<CategorieChaussure> categories)
        {
            return this.repo.Find(c => categories.Contains(c.Categorie)).ToList(); ;
        }

        /// <summary>
        /// Retourne les chaussures dans la bdd qui ont une matière parmi une liste de matières
        /// </summary>
        /// <returns></returns>
        public List<Chaussure> FindByMatieres(List<Matiere> matieres)
        {
            return this.repo.Find(c => matieres.Contains(c.Matiere)).ToList(); ;
        }

        /// <summary>
        /// Retourne les chaussures dans la bdd qui ont une matière et une categorie parmi une liste de matières et une liste de categories données
        /// </summary>
        /// <returns></returns>
        public List<Chaussure> FindByMatieresEtCategories(List<Matiere> matieres, List<CategorieChaussure> categories)
        {
            return this.repo.Find(c => matieres.Contains(c.Matiere) && categories.Contains(c.Categorie)).ToList(); ;
        }

        /// <summary>
        /// Retourne les chaussures dans la bdd qui ont une matière donnée
        /// </summary>
        /// <returns></returns>
        public List<Chaussure> FindByMatiere(string matiere)
        {
            List<Chaussure> chausssureByMatiere = new List<Chaussure>() { };
            if (Enum.TryParse<Matiere>(matiere, out Matiere tryParseResult))
            {
                chausssureByMatiere = this.repo.Find(c => c.Matiere == tryParseResult).ToList();
            }

            return chausssureByMatiere;
        }

        public List<Chaussure> FindByMotif(string motif)
        {
            List<Chaussure> chaussureByMotif = new List<Chaussure>() { };
            if (Enum.TryParse<Motifs>(motif, out Motifs tryParseResult))
            {
                chaussureByMotif = this.repo.Find(c => c.Motifs == tryParseResult).ToList();
            }

            return chaussureByMotif;
        }

        public List<Chaussure> FindByType(string type)
        {
            List<Chaussure> chaussureByType = new List<Chaussure>() { };
            if (Enum.TryParse<Types>(type, out Types tryParseResult))
            {
                chaussureByType = this.repo.Find(c => c.Type == tryParseResult).ToList();
            }

            return chaussureByType;
        }

        public List<Chaussure> FindNoPattern()
        {
            Enum.TryParse<Motifs>("pasDeMotifs", out Motifs noMotif);
            return this.repo.Find(c => c.Motifs == noMotif).ToList();
        }


        public List<Chaussure> FindWithPattern()
        {
            Enum.TryParse<Motifs>("pasDeMotifs", out Motifs noMotif);
            return this.repo.Find(c => c.Motifs != noMotif).ToList();
        }


        public List<Chaussure> FindPartyPattern()
        {

            Enum.TryParse<Motifs>("paillettes", out Motifs paillettes);
            Enum.TryParse<Motifs>("strass", out Motifs strass);
            Enum.TryParse<Motifs>("perles", out Motifs perles);

            return this.repo.Find(c => c.Motifs == paillettes || c.Motifs == strass || c.Motifs == perles).ToList();
        }

        /// <summary>
        /// Delete all Chaussures
        /// </summary>
        /// <returns></returns>
        public List<Chaussure> DeleteAllChaussures()
        {
            this.repo.DeleteMany(c => true);
            return this.repo.Find(c => true).ToList();
        }
    }
}
