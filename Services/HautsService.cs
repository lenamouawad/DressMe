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
        public HautsService(HautRepository repository)
        {
            this.repository = repository;
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
            return this.repository.UpdateHaut(id, hautUpdated);
        }

        /// <summary>
        /// Delete Top
        /// </summary>
        /// <param name="id">Top id</param>
        /// <returns></returns>
        public List<Haut> DeleteHaut(string id)
        {
            return this.repository.DeleteHaut(id); ;
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
            List<Haut> hautsDeMatiere = new List<Haut>() { };
            if (Enum.TryParse(matiere, out Matiere tryParseResult))
            {
                hautsDeMatiere = this.repository.GetAllByMatiere(tryParseResult);
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
            return this.repository.GetAllByManche(manche);
        }

        /// <summary>
        /// Returns all non patterned tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetNoPattern()
        {         
            return this.repository.GetNoPattern();
        }

        /// <summary>
        /// Returns all patterned tops
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetWithPattern()
        {
            return this.repository.GetWithPattern();
        }

        /// <summary>
        /// Returns all tops with party patterns 
        /// </summary>
        /// <returns></returns>
        public List<Haut> GetPartyPattern()
        {            
            return this.repository.GetPartyPattern();
        }

        /// <summary>
        /// Returns all tops of a selected category
        /// </summary>
        /// <param name="categorie"></param>
        /// <returns></returns>
        public List<Haut> GetByCategorie(string categorie)
        {
            List<Haut> hautsDeCategorie = new List<Haut>() { };
            if (Enum.TryParse(categorie, out CategorieHaut tryParseResult))
            {
                hautsDeCategorie = this.repository.GetByCategorie(tryParseResult);
            }
            else
            {
                // input string is not a valid enum Categorie
                throw new NotFoundException($"La categorie choisie n'est pas valide");
            }

            return hautsDeCategorie;
        }
    }
}
