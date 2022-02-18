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
        public Tenue ProposerTenue(string meteo)
        {
            Tenue tenue = new Tenue();

            Random random;
            int index;

            // Haut by weather
            List<Haut> hauts = new List<Haut> { };
            hauts = hautServ.FindHautByMeteo(meteo);
            if (hauts.Count == 0)
            {
                hauts = hautServ.GetAllHauts();
            }
            // Veste by weather
            List<Haut> vestes = new List<Haut> { };
            if (meteo == EnumMeteo.frais || meteo == EnumMeteo.froid)
            {
                vestes = hautServ.FindVesteByMeteo(meteo);
            }
            // Bas by weather
            List<Bas> bas = basServ.FindBasByMeteo(meteo);
            if (bas.Count == 0)
            {
                bas = basServ.FindAll();
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

            random = new Random();
            index = random.Next(bas.Count);
            tenue.basId = (bas[index].Id);
            tenue.bas = basRepo.FindById(tenue.basId);

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
