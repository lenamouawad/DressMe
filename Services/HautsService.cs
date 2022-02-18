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
    public class HautsService
    {
        private HautRepository repository;
        private StringToEnumConversions conversion;

        public HautsService(HautRepository repository, StringToEnumConversions conversion)
        {
            this.repository = repository;
            this.conversion = conversion;
        }

        /// <summary>
        /// Creates a top
        /// </summary>
        /// <param name="haut">Top to create</param>
        /// <returns>List of all tops</returns>
        public List<Haut> AddHaut(Haut haut)
        {
            return this.repository.AddHaut(haut);
        }

        /// <summary>
        /// Modify a top
        /// </summary>
        /// <param name="id">top id </param>
        /// <param name="hautUpdated">top with new info</param>
        /// <returns>updated room info</returns>
        public Haut UpdateHaut(String id, Haut hautUpdated)
        {
            Haut haut = this.repository.FindById(id);
            if (haut == null)
            {
                throw new NotFoundException($"Aucun des hauts n'a ce id :  {id}");
            }
            else
            {
                haut = this.repository.UpdateHaut(id, hautUpdated);
            }

            return haut;
        }

        /// <summary>
        /// Delete Top
        /// </summary>
        /// <param name="id">Top id</param>
        /// <returns></returns>
        public List<Haut> DeleteHaut(string id)
        {
            Haut haut = this.repository.FindById(id);
            List<Haut> listHauts = new List<Haut>() { };

            if (haut == null)
            {
                throw new NotFoundException($"Aucun des hauts n'a ce id :  {id}");
            }
            else
            {
                listHauts = this.repository.DeleteHaut(id);
            }
            return listHauts;
        }

        /// <summary>
        /// Returns all tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetAllHauts()
        {
            return this.repository.GetAllHauts();

        }

        /// <summary>
        /// Returns the top with the given id
        /// </summary>
        /// <param name="id">Top id</param>
        /// <returns></returns>
        public Haut FindById(string id)
        {
            Haut haut = this.repository.FindById(id);
            if (haut == null)
            {
                throw new NotFoundException($"Aucun des hauts n'a ce id :  {id}");
            }
            return haut;
        }

        /// <summary>
        /// Delete all Tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> DeleteAllHaut()
        {
            return this.repository.DeleteAllHaut();
        }

        /// <summary>
        /// Returns all tops of a selected fabric
        /// </summary>
        /// <param name="matiere"></param>
        /// <returns></returns>
        public List<Haut> GetAllByMatiere(string matiere)
        {
            List<Haut> listHauts = new List<Haut>() { };
            if (Enum.TryParse(matiere, out Matiere tryParseResult))
            {
                listHauts = this.repository.GetAllByMatiere(tryParseResult);
                if (listHauts == null)
                {
                    throw new NotFoundException($"Aucun haut de la matière {matiere} n'existe");
                }
            }
            else
            {
                // input string is not a valid enum Matiere
                throw new NotFoundException($"La matière choisie n'est pas valide.");
            }

            return listHauts;
        }

        /// <summary>
        /// Returns all tops of a selected sleeve length
        /// </summary>
        /// <param name="manche"></param>
        /// <returns></returns>
        public List<Haut> GetAllByManche(string manche)
        {
            List<Haut> listHauts = this.repository.GetAllByManche(manche);
            if (listHauts == null)
            {
                throw new NotFoundException($"Aucun haut ayant le type de manche {manche} n'existe");
            }
            return listHauts;
        }

        /// <summary>
        /// Returns all tops of a selected type/occasion
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Haut> GetByType(string type)
        {
            List<Haut> listHauts = this.repository.GetByType(type);
            if (listHauts == null)
            {
                throw new NotFoundException($"Aucun haut n'existe du type {type}");
            }
            return listHauts;
        }

        /// <summary>
        /// Returns all tops with a selected pattern
        /// </summary>
        /// <param name="motif"></param>
        public List<Haut> GetByMotif(string motif)
        {
            List<Haut> listHaut = this.repository.GetByPattern(motif);
            if (listHaut == null)
            {
                throw new NotFoundException($"Aucun haut n'existe ayant le motif {motif}");
            }
            return listHaut;
        }

        /// <summary>
        /// Returns all non patterned tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetNoPattern()
        {
            List<Haut> listHauts = this.repository.GetNoPattern();
            if (listHauts == null)
            {
                throw new NotFoundException($"Aucun haut sans motif n'existe");
            }
            return listHauts;
        }

        /// <summary>
        /// Returns all patterned tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetWithPattern()
        {
            List<Haut> listHauts = this.repository.GetWithPattern();
            if (listHauts == null)
            {
                throw new NotFoundException($"Aucun haut ayant des motifs n'existe");
            }
            return listHauts;
        }

        /// <summary>
        /// Returns all tops with party patterns 
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetPartyPattern()
        {
            List<Haut> listHauts = this.repository.GetPartyPattern();
            if (listHauts == null)
            {
                throw new NotFoundException($"Aucun haut ayant des motifs de fete n'existe");
            }
            return listHauts;
        }

        /// <summary>
        /// Returns all tops of a selected category
        /// </summary>
        /// <param name="categorie"></param>
        /// <returns></returns>
        public List<Haut> GetByCategorie(string categorie)
        {
            List<Haut> listHauts = new List<Haut>() { };
            if (Enum.TryParse(categorie, out CategorieHaut tryParseResult))
            {
                listHauts = this.repository.GetByCategorie(tryParseResult);
                if (listHauts == null)
                {
                    throw new NotFoundException($"Aucun haut de la categorie {categorie} n'existe");
                }
            }
            else
            {
                // input string is not a valid enum Categorie
                throw new NotFoundException($"La categorie choisie n'est pas valide");
            }

            return listHauts;
        }

        /// <summary>
        /// Permet de récupérer les hauts de la bdd qui appartiennent a une categorie convenable a une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Haut> FindHautByMeteo(string meteo)
        {
            List<string> stringListManche = new List<string>();
            List<string> stringListCategorie = new List<string>();


            if (meteo == EnumMeteo.chaud)
            {
                stringListManche.Add(EnumManches.courtes);
                stringListManche.Add(EnumManches.pasDeManches);
                stringListManche.Add(EnumManches.bretelles);

                stringListCategorie.Add(EnumHautCategorie.tshirt);
                stringListCategorie.Add(EnumHautCategorie.top);
                stringListCategorie.Add(EnumHautCategorie.chemise);
                stringListCategorie.Add(EnumHautCategorie.blouse);
            }
            else if (meteo == EnumMeteo.bon)
            {
                stringListManche.Add(EnumManches.courtes);
                stringListManche.Add(EnumManches.longues);

                stringListCategorie.Add(EnumHautCategorie.top);
                stringListCategorie.Add(EnumHautCategorie.tshirt);
                stringListCategorie.Add(EnumHautCategorie.chemise);
                stringListCategorie.Add(EnumHautCategorie.blouse);
            }
            else if (meteo == EnumMeteo.frais)
            {
                stringListManche.Add(EnumManches.longues);

                stringListCategorie.Add(EnumHautCategorie.sweat);
                stringListCategorie.Add(EnumHautCategorie.chemise);
                stringListCategorie.Add(EnumHautCategorie.blouse);
            }
            else if (meteo == EnumMeteo.froid)
            {
                stringListManche.Add(EnumManches.longues);

                stringListCategorie.Add(EnumHautCategorie.pull);
                stringListCategorie.Add(EnumHautCategorie.sweat);
            }
            else 
            { 
                throw new NotFoundException($"La météo indiquée n'est pas valide");
            }

            List<Manches> manches = conversion.StringToManche(stringListManche);
            List<CategorieHaut> categories = conversion.StringToCategorieHaut(stringListCategorie);

            List<Haut> hauts = this.repository.FindHautByManchesEtCat(manches, categories);

            return hauts;
        }

        /// <summary>
        /// Permet de récupérer les vestes de la bdd qui appartiennent a une categorie convenable a une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Haut> FindVesteByMeteo(string meteo)
        {
            List<string> stringListCategorie = new List<string>();

            if (meteo == EnumMeteo.frais)
            {
                stringListCategorie.Add(EnumHautCategorie.veste);
                stringListCategorie.Add(EnumHautCategorie.blazer);
                stringListCategorie.Add(EnumHautCategorie.trench);
                stringListCategorie.Add(EnumHautCategorie.gilet);
            }
            else if (meteo == EnumMeteo.froid)
            {
                stringListCategorie.Add(EnumHautCategorie.manteau);
                stringListCategorie.Add(EnumHautCategorie.doudoune);
            }

            List<CategorieHaut> categories = conversion.StringToCategorieHaut(stringListCategorie);

            return this.repository.FindVesteByCat(categories);
        }

        public List<Haut> FilterByType (List<Haut> hauts, string type)
        {
            List<Haut> hautsByType = new List<Haut>() { };
            Types typeHaut = conversion.OneStringToOneType(type);
            List<Haut> filteredList = new List<Haut>() { };

            foreach (Haut value in hauts)
            {
                if (value.Type == typeHaut)
                {
                    filteredList.Add(value);
                }
            }

            return filteredList;
        }
    }
}