using DressMe.Exceptions;
using DressMe.Interfaces;
using DressMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Enumerations
{
    public class StringToEnumConversions
    {
        public List<Matiere> StringToMatiere(List<string> stringList)
        {
            List<Matiere> matiereList = new List<Matiere>();
            foreach (string value in stringList)
            {
                if (Enum.TryParse<Matiere>(value, out Matiere matiere))
                {
                    matiereList.Add(matiere);
                }
                else
                {
                    throw new NotFoundException($"The fabric value is not allowed");
                }

            }

            return matiereList;
        }

        public List<CategorieBas> StringToCategorieBas(List<string> stringList)
        {
            List<CategorieBas> categorieList = new List<CategorieBas>();
            foreach (string value in stringList)
            {
                if (Enum.TryParse<CategorieBas>(value, out CategorieBas categorie))
                {
                    categorieList.Add(categorie);
                }
                else
                {
                    throw new NotFoundException($"The category value is not allowed");
                }

            }

            return categorieList;
        }

        public List<CategorieHaut> StringToCategorieHaut(List<string> stringList)
        {
            List<CategorieHaut> categorieList = new List<CategorieHaut>();
            foreach (string value in stringList)
            {
                if (Enum.TryParse<CategorieHaut>(value, out CategorieHaut categorie))
                {
                    categorieList.Add(categorie);
                }
                else
                {
                    throw new NotFoundException($"The category value is not allowed");
                }

            }

            return categorieList;
        }

        public List<Manches> StringToManche(List<string> stringList)
        {
            List<Manches> mancheList = new List<Manches>();
            foreach (string value in stringList)
            {
                if (Enum.TryParse<Manches>(value, out Manches categorie))
                {
                    mancheList.Add(categorie);
                }
                else
                {
                    throw new NotFoundException($"The sleeve length value is not allowed");
                }

            }

            return mancheList;
        }
    }
}
