using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Jeans : Bas
    {
        public string style { get; set; }

        public Jeans()
        {
        }
        public Jeans(string style)
        {
            this.style = style;
        }
    }
}
