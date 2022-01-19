using DressMe.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Bas : IVetement
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public List<string> couleur { get; set; }
        public string matiere { get; set; }
        public string motifs { get; set; }
        public List<string> type { get; set; }
        public string Taille { get; set; }
        public string imgUrl { get; set; }

        public Bas()
        {
        }
        public Bas(string id, List<string> couleur, string matiere, string motifs, List<string> type, string taille)
        {
            this.id = id;
            this.couleur = couleur;
            this.matiere = matiere;
            this.motifs = motifs;
            this.type = type;
            Taille = taille;
        }
    }
}
