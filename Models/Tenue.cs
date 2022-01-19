using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Models
{
    public class Tenue
    {
         public List<Haut> haut {get; set;}
         public Bas bas {get;set;}
         public Robe robe {get; set;}
    }
}
