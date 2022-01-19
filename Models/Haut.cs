using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public abstract class Haut
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public List<string> couleur { get; set; }
        public string matiere { get; set; }
        public string motifs { get; set; }
        public string imgUrl { get; set; }
        public List<string> type { get; set; }
        public string manches { get; set; }
        public List<string> coupe { get; set; }
        

        protected Haut()
        {
        }

        protected Haut(string id, List<string> couleur, string matiere, string motifs, List<string> type, string manches, List<string> coupe)
        {
            this.id = id;
            this.couleur = couleur;
            this.matiere = matiere;
            this.motifs = motifs;
            this.type = type;
            this.manches = manches;
            this.coupe = coupe;
        }
    }
}
