using DressMe.Config;
using DressMe.Exceptions;
using DressMe.Interfaces;
using DressMe.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using DressMe.Enumerations;

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
        public List<Haut> GetAllByMatiere(Matiere matiere)
        {
            return this.hauts.Find(haut => haut.Matiere == matiere).ToList();

        }

        /// <summary>
        /// Returns all tops of a selected sleeve length
        /// </summary>
        /// <param name="manche"></param>
        /// <returns></returns>
        public List<Haut> GetAllByManche(string manche)
        {
            List<Haut> hautsDeManche = new List<Haut>() { };
            if (Enum.TryParse<Manches>(manche, out Manches tryParseResult))
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

        /// <summary>
        /// change in true or false favoris
        /// </summary>
        /// <param name="id"></param>
        public void EstFavoris(string id)
        {
            Haut haut = FindById(id);
            haut.EstFavoris = !haut.EstFavoris;
            UpdateHaut(id, haut);
        }
        /// <summary>
        /// Recuperer tous les articles favoris
        /// </summary>
        /// <returns></returns>
        public List<Haut> FindAllFavoris()
        {
            return this.hauts.Find(h => h.EstFavoris == true).ToList();
        }


        /// <summary>
        /// Retourne les hauts dans la bdd qui ont une catégorie parmi une liste de catégories et une longueur de manches parmis plusieurs
        /// </summary>
        /// <returns></returns>
        public List<Haut> FindHautByManchesEtCat(List<Manches> manches, List<CategorieHaut> categories)
        {
            return this.hauts.Find(haut => categories.Contains(haut.Categorie) && manches.Contains(haut.Manches)).ToList(); ;
        }

        /// <summary>
        /// Retourne les hauts dans la bdd qui sont des catégories vestes
        /// </summary>
        /// <returns></returns>
        public List<Haut> FindVesteByCat(List<CategorieHaut> categories)
        {
            return this.hauts.Find(haut => categories.Contains(haut.Categorie)).ToList(); ;
        }

        /// <summary>
        /// Returns all tops of a selected type/occasion
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Haut> GetByType(string type)
        {
            List<Haut> basByType = new List<Haut>() { };
            if (Enum.TryParse<Types>(type, out Types tryParseResult))
            {
                basByType = this.hauts.Find(haut => haut.Type == tryParseResult).ToList();
            }

            return basByType;
        }

        /// <summary>
        /// Returns all tops of a selected pattern
        /// </summary>
        /// <param name="motif"></param>
        /// <returns></returns>
        public List<Haut> GetByPattern(string motif)
        {
            List<Haut> basByMotif = new List<Haut>() { };
            if (Enum.TryParse<Motifs>(motif, out Motifs tryParseResult))
            {
                basByMotif = this.hauts.Find(haut => haut.Motifs == tryParseResult).ToList();
            }

            return basByMotif;
        }

        /// <summary>
        /// Returns all non patterned tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetNoPattern()
        {
            Enum.TryParse<Motifs>("pasDeMotifs", out Motifs noMotif);
            return this.hauts.Find(haut => haut.Motifs == noMotif).ToList();
        }

        /// <summary>
        /// Returns all patterned tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetWithPattern()
        {
            Enum.TryParse<Motifs>("pasDeMotifs", out Motifs noMotif);
            return this.hauts.Find(haut => haut.Motifs != noMotif).ToList();
        }

        /// <summary>
        /// Returns all tops with party patterns 
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetPartyPattern()
        {
            Enum.TryParse<Motifs>("paillettes", out Motifs paillettes);
            Enum.TryParse<Motifs>("strass", out Motifs strass);
            Enum.TryParse<Motifs>("perles", out Motifs perles);

            return this.hauts.Find(haut => haut.Motifs == paillettes || haut.Motifs == strass || haut.Motifs == perles).ToList();
        }

        /// <summary>
        /// Returns all tops of a selected category
        /// </summary>
        /// <param name="categorie"></param>
        /// <returns></returns>
        public List<Haut> GetByCategorie(CategorieHaut categorie)
        {
            return this.hauts.Find(haut => haut.Categorie == categorie).ToList();
        }

    }
}