using DressMe.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DressMe.DTO;

namespace DressMe.Models
{
    public class Tenue
    {

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }

        // Haut #1
        [BsonRepresentation(BsonType.ObjectId)]
        public string hautId { get; set; }
        [BsonIgnore]
        public Haut haut { get; set; }

        // Haut #2
        [BsonRepresentation(BsonType.ObjectId)]
        public string vesteId { get; set; }
        [BsonIgnore]
        public Haut veste { get; set; }

        // Bas
        [BsonRepresentation(BsonType.ObjectId)]
        public string basId { get; set; }
        [BsonIgnore]
        public Bas bas { get; set; }

        // Chaussure
        [BsonRepresentation(BsonType.ObjectId)]
        public string chaussureId { get; set; }
        [BsonIgnore]
        public Chaussure chaussure { get; set; }

        public Tenue()
        {
        }

        public Tenue(string id, string hautId, Haut haut, string vesteId, Haut veste, string basId, Bas bas, string chaussureId, Chaussure chaussure)
        {
            this.id = id;
            this.hautId = hautId;
            this.haut = haut;
            this.vesteId = vesteId;
            this.veste = veste;
            this.basId = basId;
            this.bas = bas;
            this.chaussureId = chaussureId;
            this.chaussure = chaussure;
        }

        public static implicit operator TenueDTO(Tenue tenue)
        {
            //return new TenueDTO(tenue.id, tenue.haut.ImgUrl, tenue.veste.ImgUrl, tenue.bas.ImgUrl, tenue.chaussure.ImgUrl);
            string vesteUrl;
            string basUrl;

            if (tenue.vesteId == null)
            {
                vesteUrl = "";
            }
            else
            {
                vesteUrl = tenue.veste.ImgUrl;
            }
            if (tenue.basId == null)
            {
                basUrl = "";
            }
            else
            {
                basUrl = tenue.bas.ImgUrl;
            }
            
            return new TenueDTO(tenue.id, tenue.haut.ImgUrl, vesteUrl, basUrl, "");
            
        }
    }
}
