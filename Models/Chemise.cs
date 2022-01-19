using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Chemise : Haut
    {
        public string col { get; set; }
        public string fermeture { get; set; }
        public Chemise()
        {
        }

        public Chemise(string col, string fermeture)
        {
            this.col = col;
            this.fermeture = fermeture;
        }
    }
}
