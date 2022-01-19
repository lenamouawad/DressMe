using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace DressMe.Models
{
    public class Manteau : Haut
    {
        public bool estImpermeable  { get; set; }
        public string aCapuche { get; set; }

        public Manteau()
        {
        }

        public Manteau(bool estImpermeable, string aCapuche)
        {
            this.estImpermeable = estImpermeable;
            this.aCapuche = aCapuche;
        }
    }
}
