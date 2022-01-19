using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Jupe : Bas
    {
        public string style { get; set; }
        public string longueur { get; set; }
        public string fermeture { get; set; }

        public Jupe()
        {
        }
        public Jupe(string style, string longueur, string fermeture)
        {
            this.style = style;
            this.longueur = longueur;
            this.fermeture = fermeture;
        }
    }
}
