﻿using DressMe.Exceptions;
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
        public BasService(BasRepository repository)
        {
            this.repository = repository;
        }


        public List<Bas> Create(Bas bas)
        {
            return this.repository.Create(bas);
        }

        public List<Bas> FindAll()
        {
            List<Bas> listBas = this.repository.FindAll();

            return listBas;

        }

        public Bas FindById(string id)
        {
            Bas bas = this.repository.FindById(id);
            if (bas == null)
            {
                throw new NotFoundException($"None of the hauts has the ID {id}");
            }
            return bas;
        }

        public void Delete(string id)
        {
            this.repository.Delete(id);
        }

        public void Update(string id, Bas bas)
        {
            this.repository.Update(id, bas);
        }

        /// <summary>
        /// Delete all Bas
        /// </summary>
        /// <returns></returns>
        public List<Bas> DeleteAllBas()
        {
            return this.repository.DeleteAllBas();
        }

    }
}
