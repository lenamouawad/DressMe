
using DressMe.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace DressMe.Models
{
    public enum CategorieChaussure
    {
        talon,
        plates,
        basket,
        sandales,
        bottes,
        mocassin
    }
    public class Chaussure : IVetement
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        List<Couleur> IVetement.Couleur { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Matiere Matiere { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Motifs Motifs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ImgUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Types Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public List<Couleur> Couleur;
        [JsonConverter(typeof(StringEnumConverter))]
        [BsonRepresentation(BsonType.String)]
        public CategorieChaussure categorieChaussure;
        public bool EstFavoris;

    }
}