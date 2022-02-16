using DressMe.DTO;
using DressMe.Enumeration;
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
        private ChaussureRepository chausRepo;

        public TenueService(TenueRepository repo, HautRepository hautRepo, BasRepository basRepo, ChaussureRepository chausRepo)
        {
            this.repo = repo;
            this.hautRepo = hautRepo;
            this.basRepo = basRepo;
            this.chausRepo = chausRepo;
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

        /// <summary>
        /// Creates an outfit
        /// </summary>
        /// <param name="type"></param>
        /// <param name="meteo"></param>
        public Tenue ProposerTenue(string meteo)
        {
            Tenue tenue = new Tenue();

            // Haut by weather

            List<Haut> hauts = new List<Haut> { };
            List <Haut> vestes = new List<Haut> { };

            if (meteo == EnumMeteo.chaud)
            {
                hauts = hautRepo.GetHautsChauds();
            }
            else if (meteo == EnumMeteo.bon)
            {
                hauts = hautRepo.GetHautsBon();
            }
            else if (meteo == EnumMeteo.frais)
            {
                hauts = hautRepo.GetHautsFrais();
                vestes = hautRepo.GetVestesFrais();             
            }
            else if (meteo == EnumMeteo.froid)
            {
                hauts = hautRepo.GetHautsFroid();
                vestes = hautRepo.GetVestesFroid();
            }

            var random = new Random();
            int index = random.Next(hauts.Count);

            tenue.hautId = (hauts[index].Id);
            tenue.haut = hautRepo.FindById(tenue.hautId);
            if (vestes.Count()>0)
            {
                index = random.Next(vestes.Count);
                tenue.vesteId = (vestes[index].Id);
                tenue.veste = hautRepo.FindById(tenue.vesteId);
            }

            List<Tenue> tenues = repo.AddTenue(tenue);

            return tenue;

        }
    }
}
