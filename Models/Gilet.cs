using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Gilet : Haut
    {
        public bool estImpermeable { get; set; }
        public string aCapuche { get; set; }

        public Gilet()
        {
        }

        public Gilet(bool estImpermeable, string aCapuche)
        {
            this.estImpermeable = estImpermeable;
            this.aCapuche = aCapuche;
        }
    }
}
