using DressMe.DTO;
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
    public class TenueService
    {
        private TenueRepository repo;
        private HautRepository hautRepo;
        private BasRepository basRepo;
        private BasService basServ;
        private HautsService hautServ;

        private ChaussureRepository chausRepo;

        public TenueService(TenueRepository repo, HautRepository hautRepo, BasService basServ, ChaussureRepository chausRepo, BasRepository basRepo, HautsService hautServ)
        {
            this.repo = repo;
            this.hautRepo = hautRepo;
            this.basRepo = basRepo;
            this.chausRepo = chausRepo;
            this.basServ = basServ;
            this.hautServ = hautServ;
        }

        /// <summary>
        /// Returns all outfits
        /// </summary>
        /// <returns></returns>
        public List<Tenue> GetAllTenue()
        {
            return this.repo.GetAllTenue();
        }

        /// <summary>
        ///  Supprime toutes les tenues
        /// </summary>
        /// <returns></returns>
        public List<Tenue> DeleteAllTenue()
        {
            return this.repo.DeleteAllTenue();
        }

        /// <summary>
        /// Creates an outfit
        /// </summary>
        /// <param name="type"></param>
        /// <param name="meteo"></param>
        public Tenue ProposerTenue(string meteo, string type)
        {
            Tenue tenue = new Tenue();

            List<Haut> hauts = new List<Haut>() { };
            List<Haut> vestes = new List<Haut>() { };
            List<Bas> bas = new List<Bas>() { };

            Random random;
            int index;

            // Haut by weather
            List<Haut> hautsByMeteo = new List<Haut> { };
            hautsByMeteo = hautServ.FindHautByMeteo(meteo);
            if (hautsByMeteo.Count == 0)
            {
                hautsByMeteo = hautServ.GetAllHauts();
            }
            // Veste by weather
            List<Haut> vestesByMeteo = new List<Haut> { };
            if (meteo == EnumMeteo.frais || meteo == EnumMeteo.froid)
            {
                vestesByMeteo = hautServ.FindVesteByMeteo(meteo);
            }
            // Bas by weather
            List<Bas> basByMeteo = basServ.FindBasByMeteo(meteo);
            if (basByMeteo.Count == 0)
            {
                basByMeteo = basServ.FindAll();
            }

            // Haut By type
            List<Haut> hautsByType = new List<Haut>() { };
            hautsByType = hautServ.FilterByType(hautsByMeteo, type);
            if (hautsByType.Count == 0)
            {
                hauts = hautsByMeteo;
            }
            else
            {
                hauts = hautsByType;
            }
            // Vestes by type
            List<Haut> vestesByType = new List<Haut>() { };
            if (vestesByMeteo.Count != 0)
            {
                vestesByType = hautServ.FilterByType(vestesByMeteo, type);
                if (vestesByType.Count == 0)
                {
                    vestes = vestesByMeteo;
                }
                else
                {
                    vestes = vestesByType;
                }
            }
            // Bas by type
            List<Bas> basByType = new List<Bas>() { };
            basByType = basServ.FilterByType(basByMeteo, type);
            if (basByType.Count == 0)
            {
                bas = basByMeteo;
            }
            else
            {
                bas = basByType;
            }

            // Tenue
            random = new Random();
            index = random.Next(hauts.Count);
            tenue.hautId = (hauts[index].Id);
            tenue.haut = hautRepo.FindById(tenue.hautId);

            if (vestes.Count != 0)
            {
                random = new Random();
                index = random.Next(vestes.Count);
                tenue.vesteId = (vestes[index].Id);
                tenue.veste = hautRepo.FindById(tenue.vesteId);
            }

            if (tenue.haut.Categorie != CategorieHaut.robe)
            {
                random = new Random();
                index = random.Next(bas.Count);
                tenue.basId = (bas[index].Id);
                tenue.bas = basRepo.FindById(tenue.basId);
            }
            
            List<Tenue> tenues = repo.AddTenue(tenue);

            return tenue;
        }

        /// <summary>
        /// Returns the tenue with the given id
        /// </summary>
        /// <param name="id">tenue id</param>
        /// <returns></returns>
        public TenueDTO FindDTOById(string id)
        {
            return this.repo.FindDTOById(id);
        }


    }
}
