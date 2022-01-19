using DressMe.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;
using MongoDB.Bson;

namespace DressMe.Models
{
    public enum Manches
    {
        courtes,
        longues,
        pasDeManches,
        asymetrique,
        bretelles
    }

    public enum CategorieHaut
    {
        robe,
        pull,
        sweat,
        tshirt,
        top,
        chemise,
        blouse,
        gilet,
        veste,
        blazer,
        manteau,
        doudoune,
        trench        
    }

    public abstract class Haut : IVetement
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public List<Couleur> Couleur { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Matiere Matiere { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Motifs Motifs { get; set; }
        public string ImgUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Types Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public CategorieHaut Categorie { get; set; }
        public string Manches { get; set; }       
        public bool EstImpermeable { get; set; }
        public bool ACapuche { get; set; }

    }


}
