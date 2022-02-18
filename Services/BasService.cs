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
    public class BasService
    {
        private BasRepository repository;
        private StringToEnumConversions conversion;

        public BasService(BasRepository repository, StringToEnumConversions conversion)
        {
            this.repository = repository;
            this.conversion = conversion;
        }

        public List<Bas> Create(Bas bas)
        {
            return this.repository.Create(bas);
        }

        public List<Bas> FindAll()
        {
            List<Bas> listBas = this.repository.FindAll();
            if (listBas == null)
            {
                throw new NotFoundException($"Not found bas");
            }
            return listBas;

        }

        public Bas FindById(string id)
        {
            Bas bas = this.repository.FindById(id);
            if (bas == null)
            {
                throw new NotFoundException($"None of the bas has the ID {id}");
            }
            return bas;
        }

        public void Delete(string id)
        {
            this.repository.Delete(id);
        }

        public Bas Update(string id, Bas bas)
        {
            this.repository.Update(id, bas);
            return bas;
        }

        /// <summary>
        /// Delete all Bas
        /// </summary>
        /// <returns></returns>
        public List<Bas> DeleteAllBas()
        {
            return this.repository.DeleteAllBas();
        }

        public List<Bas> FindByCategorie(string categorie)
        {
            List<Bas> bas = this.repository.FindByCategorie(categorie);
            if (bas == null)
            {
                throw new NotFoundException($"None of the bas is a {categorie}");
            }
            return bas;
        }

        public List<Bas> FindByMatiere(string matiere)
        {
            List<Bas> bas = this.repository.FindByMatiere(matiere);
            if (bas == null)
            {
                throw new NotFoundException($"None of the bas is made of {matiere}");
            }
            return bas;
        }

        public List<Bas> FindByMotif(string motif)
        {
            List<Bas> bas = this.repository.FindByMotif(motif);
            if (bas == null)
            {
                throw new NotFoundException($"None of the bas has the pattern {motif}");
            }
            return bas;
        }

        public List<Bas> FindByType(string type)
        {
            List<Bas> bas = this.repository.FindByType(type);
            if (bas == null)
            {
                throw new NotFoundException($"None of the bas is of type {type}");
            }
            return bas;
        }

        public List<Bas> FindNoPattern()
        {
            List<Bas> bas = this.repository.FindNoPattern();
            if (bas == null)
            {
                throw new NotFoundException($"None of the bas doesnt have a pattern");
            }
            return bas;
        }


        public List<Bas> FindWithPattern()
        {
            List<Bas> bas = this.repository.FindWithPattern();
            if (bas == null)
            {
                throw new NotFoundException($"None of the bas has a pattern");
            }
            return bas;
        }


        public List<Bas> FindPartyPattern()
        {
            List<Bas> bas = this.repository.FindPartyPattern();
            if (bas == null)
            {
                throw new NotFoundException($"None of the bas has a party pattern");
            }
            return bas;
        }

        /// <summary>
        /// Permet de récupérer les categories de bas convenables pour une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<CategorieBas> FindBasCategories(string meteo)
        {
            List<string> stringList = new List<string>();
            if (meteo == EnumMeteo.chaud)
            {
                stringList.Add(EnumBasCategorie.shorts);
                stringList.Add(EnumBasCategorie.jupeCourte);
                stringList.Add(EnumBasCategorie.jupeLongue);
            }
            else if (meteo == EnumMeteo.bon)
            {
                stringList.Add(EnumBasCategorie.jupeLongue);
                stringList.Add(EnumBasCategorie.jeans);
                stringList.Add(EnumBasCategorie.pantalon);
            }
            else if (meteo == EnumMeteo.frais || meteo == EnumMeteo.froid)
            {
                stringList.Add(EnumBasCategorie.pantalon);
                stringList.Add(EnumBasCategorie.jeans);
                // si jamais on ajoute accessoire on pourra ajouter jupe ici et faire une condition + collant si jupe
            }
            else
            {
                throw new NotFoundException($"La météo indiquée n'est pas valide");
            }

            List<CategorieBas> categories = conversion.StringToCategorieBas(stringList);
            return categories;
        }

        /// <summary>
        /// Permet de récupérer les matieres de bas convenables pour une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Matiere> FindBasMatieres(string meteo)

        {
            List<string> stringList = new List<string>();
            if (meteo == EnumMeteo.chaud)
            {
                stringList.Add(EnumMatiere.dentelle);
                stringList.Add(EnumMatiere.coton);
                stringList.Add(EnumMatiere.lin);
                stringList.Add(EnumMatiere.soie);
                stringList.Add(EnumMatiere.denim);
                stringList.Add(EnumMatiere.autre);
            }
            else if (meteo == EnumMeteo.bon)
            {
                stringList.Add(EnumMatiere.satin);
                stringList.Add(EnumMatiere.dentelle);
                stringList.Add(EnumMatiere.coton);
                stringList.Add(EnumMatiere.lin);
                stringList.Add(EnumMatiere.soie);
                stringList.Add(EnumMatiere.denim);
                stringList.Add(EnumMatiere.autre);
            }
            else if (meteo == EnumMeteo.frais)
            {
                stringList.Add(EnumMatiere.satin);
                stringList.Add(EnumMatiere.coton);
                stringList.Add(EnumMatiere.denim);
                stringList.Add(EnumMatiere.cuir);
                stringList.Add(EnumMatiere.soie);
                stringList.Add(EnumMatiere.velours);
                stringList.Add(EnumMatiere.autre);

            }
            else if (meteo == EnumMeteo.froid)
            {
                stringList.Add(EnumMatiere.coton);
                stringList.Add(EnumMatiere.cuir);
                stringList.Add(EnumMatiere.soie);
                stringList.Add(EnumMatiere.velours);
                stringList.Add(EnumMatiere.cachemire);
                stringList.Add(EnumMatiere.maille);
                stringList.Add(EnumMatiere.laine);
                stringList.Add(EnumMatiere.fourrure);
                stringList.Add(EnumMatiere.velours);
                stringList.Add(EnumMatiere.autre);
            }
            else
            {
                throw new NotFoundException($"La météo indiquée n'est pas valide");
            }

            List<Matiere> matieres = conversion.StringToMatiere(stringList);
            return matieres;
        }

        /// <summary>
        /// Permet de récupérer les bas de la bdd qui appartiennent a une categorie convenable a une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Bas> FindBasByCategories(string meteo)
        {
            List<CategorieBas> categories = FindBasCategories(meteo);
            return this.repository.FindByCategories(categories);
        }

        /// <summary>
        /// Permet de récupérer les bas de la bdd qui ont une matiere convenable pour une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Bas> FindBasByMatieres(string meteo)

        {
            List<Matiere> matieres = FindBasMatieres(meteo);
            return this.repository.FindByMatieres(matieres);
        }

        /// <summary>
        /// Permet de récupérer les bas de la bdd qui ont une matiere et une categorie convenables pour une meteo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Bas> FindBasByMatieresEtCategories(string meteo)

        {
            List<Matiere> matieres = FindBasMatieres(meteo);
            List<CategorieBas> categories = FindBasCategories(meteo);
            return this.repository.FindByMatieresEtCategories(matieres, categories);
        }

        /// <summary>
        /// Retourne une liste de bas convenables pour une météo donnée
        /// </summary>
        /// <param name="meteo"></param>
        /// <returns></returns>
        public List<Bas> FindBasByMeteo(string meteo)
        {
            List<Bas> bas = new List<Bas>();

            bas = FindBasByMatieresEtCategories(meteo);
           
            if (bas.Count == 0)
            {
                bas = FindBasByCategories(meteo);
            }
            return bas;

        }

        public List<Bas> FilterByType(List<Bas> bas, string type)
        {
            List<Bas> basByType = new List<Bas>() { };
            Types typeBas = conversion.OneStringToOneType(type);
            List<Bas> filteredList = new List<Bas>() { };

            foreach (Bas value in bas)
            {
                if (value.Type == typeBas)
                {
                    filteredList.Add(value);
                }
            }

            return filteredList;
        }
    }
}

