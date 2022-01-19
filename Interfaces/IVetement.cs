using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Interfaces
{
    interface IVetement
    {
        public List<string> couleur { get; set; }
        public string matiere { get; set; }
        public string motifs { get; set; }
        public string imgUrl { get; set; }
        public List<string> type { get; set; } // a voir si on garde ca ici 
    }
}
