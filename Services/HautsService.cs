using DressMe.Exceptions;
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
                throw new NotFoundException($"None of the hauts has the ID {id}");
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
            return this.repository.GetAllByMatiere(matiere);
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
    }
}
