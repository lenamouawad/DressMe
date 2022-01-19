using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Tshirt : Haut
    {
        public string col { get; set; }

        public Tshirt()
        {
        }
        public Tshirt(string col)
        {
            this.col = col;
        }
    }
}
