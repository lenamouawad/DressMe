using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Blouse : Haut
    {
        public string col { get; set; }
        public string fermeture { get; set; }

        public Blouse()
        {
        }
        public Blouse(string col, string fermeture)
        {
            this.col = col;
            this.fermeture = fermeture;
        }
    }
}
