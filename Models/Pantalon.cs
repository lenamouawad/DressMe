using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Pantalon : Bas
    {
        public string style { get; set; }

        public Pantalon()
        {
        }
        public Pantalon(string style)
        {
            this.style = style;
        }
    }
}
