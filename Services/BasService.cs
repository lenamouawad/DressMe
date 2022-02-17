using DressMe.Exceptions;
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

    }
}
