using DressMe.Config;
using DressMe.DTO;
using DressMe.Exceptions;
using DressMe.Interfaces;
using DressMe.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Repositories
{
    public class TenueRepository
    {
        private readonly IMongoCollection<Tenue> tenues;
        private HautRepository hautRepo;
        private BasRepository basRepo;
        private ChaussureRepository chausRepo;
        public TenueRepository(IDressMeDatabaseSettings settings, HautRepository hautRepo, BasRepository basRepo, ChaussureRepository chausRepo)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            tenues = database.GetCollection<Tenue>(settings.TenueCollectionName);

            this.hautRepo = hautRepo;
            this.basRepo = basRepo;
            this.chausRepo = chausRepo;
        }

        /// <summary>
        /// Creates a top and adds it to the database
        /// </summary>
        /// <param name="tenue"></param>
        /// <returns>List of all tops</returns>
        public List<Tenue> AddTenue(Tenue tenue)
        {
            this.tenues.InsertOne(tenue);
            return this.tenues.Find(tenue => true).ToList();
        }

        /// <summary>
        /// Find screening DTO from the screening Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TenueDTO FindDTOById(string id)
        {
            // ScreeningDTO screeningdto = new ScreeningDTO();
            Tenue tenue = this.tenues.Find(tenue => true && tenue.id == id).FirstOrDefault();
            tenue.haut = this.hautRepo.FindById(tenue.hautId);
            tenue.veste = this.hautRepo.FindById(tenue.vesteId);
            tenue.bas = this.basRepo.FindById(tenue.basId);
            //tenue.chaussure = this.chausRepo.FindById(tenue.chaussureId);
            tenue.chaussure = null;

            TenueDTO tenuedto = tenue;
            return tenuedto;
        }
    }
}
