
using DressMe.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DressMe.Models
{
    public enum Manches
    {
        courtes,
        longues,
        pasDeManches,
        asymetriques,
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
    public class Haut : IVetement
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [JsonProperty("Couleur", ItemConverterType = typeof(StringEnumConverter))]
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
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public Manches Manches { get; set; }
        public bool EstImpermeable { get; set; }
        public bool ACapuche { get; set; }

    }
}
