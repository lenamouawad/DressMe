using DressMe.Config;
using DressMe.Exceptions;
using DressMe.Interfaces;
using DressMe.Models;
using DressMe.Enumeration;
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
        /// Returns all tops of short sleeve lengths
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetHautsChauds()
        {
            Enum.TryParse<Manches>(EnumManches.courtes, out Manches courtes);
            Enum.TryParse<Manches>(EnumManches.pasDeManches, out Manches pasDeManches);
            Enum.TryParse<Manches>(EnumManches.bretelles, out Manches bretelles);

            Enum.TryParse<CategorieHaut>(EnumHautCategorie.tshirt, out CategorieHaut tshirt);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.top, out CategorieHaut top);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.chemise, out CategorieHaut chemise);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.blouse, out CategorieHaut blouse);

            List<Haut> hauts = this.hauts.Find(haut => (haut.Manches == courtes || haut.Manches == pasDeManches || haut.Manches == bretelles) && 
                                                       (haut.Categorie == tshirt || haut.Categorie == top || haut.Categorie == blouse || haut.Categorie == chemise))
                                                       .ToList();

            return hauts;
        }

        public List<Haut> GetHautsBon()
        {
            Enum.TryParse<Manches>(EnumManches.courtes, out Manches courtes);
            Enum.TryParse<Manches>(EnumManches.longues, out Manches longues);

            Enum.TryParse<CategorieHaut>(EnumHautCategorie.top, out CategorieHaut top);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.chemise, out CategorieHaut chemise);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.blouse, out CategorieHaut blouse);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.sweat, out CategorieHaut sweat);


            List<Haut> hauts = this.hauts.Find(haut => (haut.Manches == courtes || haut.Manches == longues) &&
                                                       (haut.Categorie == top || haut.Categorie == chemise || haut.Categorie == blouse || haut.Categorie == sweat))
                                                       .ToList();

            return hauts;
        }

        /// <summary>
        /// Returns all tops for cold weather
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetHautsFrais()
        {
            Enum.TryParse<Manches>(EnumManches.longues, out Manches longues);

            Enum.TryParse<CategorieHaut>(EnumHautCategorie.top, out CategorieHaut top);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.chemise, out CategorieHaut chemise);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.blouse, out CategorieHaut blouse);

            List<Haut> hauts = this.hauts.Find(haut => (haut.Manches == longues) &&
                                                       (haut.Categorie == top || haut.Categorie == chemise || haut.Categorie == blouse))
                                                       .ToList();

            return hauts;
        }

        /// <summary>
        /// Returns all tops for cold weather
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetHautsFroid()
        {
            Enum.TryParse<Manches>(EnumManches.longues, out Manches longues);

            Enum.TryParse<CategorieHaut>(EnumHautCategorie.pull, out CategorieHaut pull);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.sweat, out CategorieHaut sweat);

            List<Haut> hauts = this.hauts.Find(haut => (haut.Manches == longues) &&
                                                       (haut.Categorie == pull || haut.Categorie == sweat))
                                                       .ToList();

            return hauts;
        }

        /// <summary>
        /// Returns all tops for cold weather
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetVestesFrais()
        {
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.veste, out CategorieHaut veste);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.blazer, out CategorieHaut blazer);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.trench, out CategorieHaut trench);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.gilet, out CategorieHaut gilet);
            List<Haut> hauts = this.hauts.Find(haut => haut.Categorie == veste || haut.Categorie == blazer || haut.Categorie == gilet || haut.Categorie == trench)
                                                       .ToList();

            return hauts;
        }

        /// <summary>
        /// Returns all tops for very cold weather
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetVestesFroid()
        {

            Enum.TryParse<CategorieHaut>(EnumHautCategorie.manteau, out CategorieHaut manteau);
            Enum.TryParse<CategorieHaut>(EnumHautCategorie.doudoune, out CategorieHaut doudoune);

            List<Haut> hauts = this.hauts.Find(haut => haut.Categorie == manteau || haut.Categorie == doudoune)
                                                       .ToList();

            return hauts;
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

        /// <summary>
        /// Returs all tops that could be worn for a selected weather
        /// </summary>
        /// <param name="categorie"></param>
        /// <returns></returns>
        public List<Haut> GetByMeteo(string meteo)
        {
            List<Haut> hauts = new List<Haut> { };
            if (meteo == EnumMeteo.bon)
            {
                GetAllByManche(EnumManches.courtes);
            }
            return hauts;
        }
    }
}