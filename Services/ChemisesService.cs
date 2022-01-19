using DressMe.Models;
using DressMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Services
{
    public class ChemisesService
    {
        private ChemiseRepository repository;
        public ChemisesService(ChemiseRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds a chemise to the dressing
        /// </summary>
        /// <param name="chemise">Chemise to add</param>
        /// <returns>List of all chemises </returns>
        public List<Chemise> AddChemise(Chemise chemise)
        {
            return this.repository.AddChemise(chemise);
        }
    }
}
