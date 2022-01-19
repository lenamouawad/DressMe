using DressMe.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Robe : IVetement
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public string manches { get; set; }
        public string fermeture { get; set; }
        public string col { get; set; }
        public string longueur { get; set; }
        public string styleRobe { get; set; }
        public string imgUrl { get; set; }
        public List<string> couleur { get; set; }
        public string matiere { get; set; }
        public string motifs { get; set; }
        public List<string> type { get; set; }

        public Robe()
        {
        }
        public Robe(string id, string manches, string fermeture, string col, string longueur, string styleRobe, string imgUrl, List<string> couleur, string matiere, string motifs, List<string> type)
        {
            this.id = id;
            this.manches = manches;
            this.fermeture = fermeture;
            this.col = col;
            this.longueur = longueur;
            this.styleRobe = styleRobe;
            this.imgUrl = imgUrl;
            this.couleur = couleur;
            this.matiere = matiere;
            this.motifs = motifs;
            this.type = type;
        }
    }
}
