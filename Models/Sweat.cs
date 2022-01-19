using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Sweat : Haut
    {
        public string col { get; set; }
        public string fermeture { get; set; }

        public Sweat()
        {
        }
        public Sweat(string col, string fermeture)
        {
            this.col = col;
            this.fermeture = fermeture;
        }
    }
}
