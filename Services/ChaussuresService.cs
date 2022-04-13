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
    public class ChaussuresService
    {
        private ChaussureRepository repository;
        private StringToEnumConversions conversion;

        public ChaussuresService(ChaussureRepository repository, StringToEnumConversions conversion)
        {
            this.repository = repository;
            this.conversion = conversion;
        }

        public List<Chaussure> Create(Chaussure chaussure)
        {
            return this.repository.Create(chaussure);
        }

        public List<Chaussure> FindAll()
        {
            List<Chaussure> listChaussure = this.repository.FindAll();
            if (listChaussure == null)
            {
                throw new NotFoundException($"Not found chaussures");
            }
            return listChaussure;

        }

        public Chaussure FindById(string id)
        {
            Chaussure chaussure = this.repository.FindById(id);
            if (chaussure == null)
            {
                throw new NotFoundException($"None of the chaussure has the ID {id}");
            }
            return chaussure;
        }

        public void Delete(string id)
        {
            this.repository.Delete(id);
        }

        public Chaussure Update(string id, Chaussure chaussure)
        {
            this.repository.Update(id, chaussure);
            return chaussure;
        }

        public void EstFavoris(string id, Chaussure chaussure)
        {
            this.repository.EstFavoris(id, chaussure);
        }

        public List<Chaussure> FindAllFavoris()
        {
            List<Chaussure> listChaussure = this.repository.FindAllFavoris();
            if (listChaussure == null)
            {
                throw new NotFoundException($"Not found favoris articles");
            }
            return listChaussure;
        }

        /// <summary>
        /// Delete all chaussure
        /// </summary>
        /// <returns></returns>
        public List<Chaussure> DeleteAllChaussures()
        {
            return this.repository.DeleteAllChaussures();
        }

        public List<Chaussure> FindByCategorie(string categorie)
        {
            List<Chaussure> chaussure = this.repository.FindByCategorie(categorie);
            if (chaussure == null)
            {
                throw new NotFoundException($"None of the chaussures is a {categorie}");
            }
            return chaussure;
        }

        public List<Chaussure> FindByMatiere(string matiere)
        {
            List<Chaussure> chaussure = this.repository.FindByMatiere(matiere);
            if (chaussure == null)
            {
                throw new NotFoundException($"None of the chaussure is made of {matiere}");
            }
            return chaussure;
        }

        public List<Chaussure> FindByMotif(string motif)
        {
            List<Chaussure> chaussure = this.repository.FindByMotif(motif);
            if (chaussure == null)
            {
                throw new NotFoundException($"None of the chaussure has the pattern {motif}");
            }
            return chaussure;
        }

        public List<Chaussure> FindByType(string type)
        {
            List<Chaussure> chaussure = this.repository.FindByType(type);
            if (chaussure == null)
            {
                throw new NotFoundException($"None of the chaussures is of type {type}");
            }
            return chaussure;
        }

        public List<Chaussure> FindNoPattern()
        {
            List<Chaussure> chaussure = this.repository.FindNoPattern();
            if (chaussure == null)
            {
                throw new NotFoundException($"None of the chaussures doesnt have a pattern");
            }
            return chaussure;
        }


        public List<Chaussure> FindWithPattern()
        {
            List<Chaussure> chaussures = this.repository.FindWithPattern();
            if (chaussures == null)
            {
                throw new NotFoundException($"None of the chaussures has a pattern");
            }
            return chaussures;
        }


        public List<Chaussure> FindPartyPattern()
        {
            List<Chaussure> chaussures = this.repository.FindPartyPattern();
            if (chaussures == null)
            {
                throw new NotFoundException($"None of the chaussures has a party pattern");
            }
            return chaussures;
        }

        /// <summary>
        /// Permet de récupérer les categories de chaussure convenables pour une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<CategorieChaussure> FindChaussureCategories(string meteo)
        {
            List<string> stringList = new List<string>();
            if (meteo == EnumMeteo.chaud)
            {
                stringList.Add(EnumChaussureCategorie.sandales);
                stringList.Add(EnumChaussureCategorie.mocassin);
            }
            else if (meteo == EnumMeteo.bon)
            {
                stringList.Add(EnumChaussureCategorie.escarpin);
                stringList.Add(EnumChaussureCategorie.basket);

            }
            else if (meteo == EnumMeteo.frais || meteo == EnumMeteo.froid)
            {
                stringList.Add(EnumChaussureCategorie.basket);
                stringList.Add(EnumChaussureCategorie.bottes);
            }
            else
            {
                throw new NotFoundException($"La météo indiquée n'est pas valide");
            }
            
            List<CategorieChaussure> categories = conversion.StringToCategorieChaussure(stringList);
            return categories;
        }

        /// <summary>
        /// Permet de récupérer les chaussures de la bdd qui appartiennent a une categorie convenable a une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Chaussure> FindChaussureByCategories(string meteo)
        {
            List<CategorieChaussure> categories = FindChaussureCategories(meteo);
            return this.repository.FindByCategories(categories);
        }


        /// <summary>
        /// Retourne une liste de chaussure convenables pour une météo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Chaussure> FindChaussureByMeteo(string meteo)
        {
            List<Chaussure> chaussures = new List<Chaussure>();

            chaussures = FindChaussureByCategories(meteo);


            return chaussures;

        }

        public List<Chaussure> FilterByType(List<Chaussure> chaussures, string type)
        {
            List<Chaussure> chaussureByType = new List<Chaussure>() { };
            Types typeChaussure = conversion.OneStringToOneType(type);
            List<Chaussure> filteredList = new List<Chaussure>() { };

            foreach (Chaussure value in chaussures)
            {
                if (value.Type == typeChaussure)
                {
                    filteredList.Add(value);
                }
            }

            return filteredList;
        }
    }
}
