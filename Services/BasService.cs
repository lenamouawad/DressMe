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


        public Bas Create(Bas bas)
        {
            this.repository.Create(bas);

            return bas;
        }

        public List<Bas> FindAll()
        {
            List<Bas> listBas = this.repository.FindAll();
            if(listBas == null)
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

        public List<Bas> FindByCategorie(string categorie)
        {
            List<Bas> listBas = this.repository.FindByCategorie(categorie);
            if (listBas == null)
            {
                throw new NotFoundException($"Not found bas with {categorie} categorie");
            }
            return listBas;
        }

        public List<Bas> FindByMatiere(string matiere)
        {
            List<Bas> listBas = this.repository.FindByMatiere(matiere);
            if (listBas == null)
            {
                throw new NotFoundException($"Not found bas with {matiere} matiere");
            }
            return listBas;
        }

        public List<Bas> FindByMotif(string motif)
        {
            List<Bas> listBas = this.repository.FindByMotif(motif);
            if (listBas == null)
            {
                throw new NotFoundException($"Not found bas with {motif} motif");
            }
            return listBas;
        }

        public List<Bas> FindByType(string type)
        {
            List<Bas> listBas = this.repository.FindByType(type);
            if (listBas == null)
            {
                throw new NotFoundException($"Not found bas with {type} type");
            }
            return listBas;
        }

    }
}
