using DressMe.Models;
using DressMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Services
{
    public class RobesService
    {
        private RobeRepository repository;
        public RobesService(RobeRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds a dress to the dressing
        /// </summary>
        /// <param name="dress">Dress to add</param>
        /// <returns>List of all dresses </returns>
        public List<Robe> AddDress(Robe dress)
        {
            return this.repository.AddDress(dress);
        }
    }
}
