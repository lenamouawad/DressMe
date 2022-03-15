using DressMe.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using DressMe.Exceptions;

namespace DressMe.Models
{
    public enum CategorieBas
    {
        pantalon,
        jeans,
        shorts,
        jupeLongue,
        jupeCourte
    }

    public class Bas : IVetement
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
        public CategorieBas Categorie { get; set; }
        public bool EstFavoris;

        public Bas()
        {
        }

        


    }
}
