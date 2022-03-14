using DressMe.DTO;
using DressMe.Enumerations;
using DressMe.Exceptions;
using DressMe.Interfaces;
using DressMe.Models;
using DressMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DressMe.Services
{
    public class TenueService
    {
        private TenueRepository repo;
        private HautRepository hautRepo;
        private BasRepository basRepo;
        private BasService basServ;
        private HautsService hautServ;

        private ChaussureRepository chausRepo;

        public TenueService(TenueRepository repo, HautRepository hautRepo, BasService basServ, ChaussureRepository chausRepo, BasRepository basRepo, HautsService hautServ)
        {
            this.repo = repo;
            this.hautRepo = hautRepo;
            this.basRepo = basRepo;
            this.chausRepo = chausRepo;
            this.basServ = basServ;
            this.hautServ = hautServ;
        }

        /// <summary>
        /// Returns all outfits
        /// </summary>
        /// <returns></returns>
        public List<Tenue> GetAllTenue()
        {
            return this.repo.GetAllTenue();
        }

        /// <summary>
        ///  Supprime toutes les tenues
        /// </summary>
        /// <returns></returns>
        public List<Tenue> DeleteAllTenue()
        {
            return this.repo.DeleteAllTenue();
        }

        /// <summary>
        /// Creates an outfit
        /// </summary>
        /// <param name="type"></param>
        /// <param name="meteo"></param>
        public Tenue ProposerTenue(string meteo, string type)
        {
            Tenue tenue = new Tenue();

            List<Haut> hauts = new List<Haut>() { };
            List<Haut> vestes = new List<Haut>() { };
            List<Bas> bas = new List<Bas>() { };

            Random random;
            int index;

            // Récupérer tous les hauts convenables
            // Haut by weather
            List<Haut> hautsByMeteo = new List<Haut> { };
            hautsByMeteo = hautServ.FindHautByMeteo(meteo);
            if (hautsByMeteo.Count == 0)
            {
                hautsByMeteo = hautServ.GetAllHauts();
            }
            // Haut By type
            List<Haut> hautsByType = new List<Haut>() { };
            hautsByType = hautServ.FilterByType(hautsByMeteo, type);
            if (hautsByType.Count == 0)
            {
                hauts = hautsByMeteo;
            }
            else
            {
                hauts = hautsByType;
            }

            // Récupérer toutes les vestes convenables
            // Veste by weather
            List<Haut> vestesByMeteo = new List<Haut> { };
            if (meteo == EnumMeteo.frais || meteo == EnumMeteo.froid)
            {
                vestesByMeteo = hautServ.FindVesteByMeteo(meteo);
            }
            // Vestes by type
            List<Haut> vestesByType = new List<Haut>() { };
            if (vestesByMeteo.Count != 0)
            {
                vestesByType = hautServ.FilterByType(vestesByMeteo, type);
                if (vestesByType.Count == 0)
                {
                    vestes = vestesByMeteo;
                }
                else
                {
                    vestes = vestesByType;
                }
            }

            // Récupérer tous les bas convenables
            // Bas by weather
            List<Bas> basByMeteo = basServ.FindBasByMeteo(meteo);
            if (basByMeteo.Count == 0)
            {
                basByMeteo = basServ.FindAll();
            }
            // Bas by type
            List<Bas> basByType = new List<Bas>() { };
            basByType = basServ.FilterByType(basByMeteo, type);
            if (basByType.Count == 0)
            {
                bas = basByMeteo;
            }
            else
            {
                bas = basByType;
            }

            // Tenue
            AssocierArticles(hauts, vestes, bas);

            random = new Random();
            index = random.Next(hauts.Count);
            tenue.hautId = (hauts[index].Id);
            tenue.haut = hautRepo.FindById(tenue.hautId);

            if (vestes.Count != 0)
            {
                random = new Random();
                index = random.Next(vestes.Count);
                tenue.vesteId = (vestes[index].Id);
                tenue.veste = hautRepo.FindById(tenue.vesteId);
            }

            if (tenue.haut.Categorie != CategorieHaut.robe)
            {
                random = new Random();
                index = random.Next(bas.Count);
                tenue.basId = (bas[index].Id);
                tenue.bas = basRepo.FindById(tenue.basId);
            }
            
            List<Tenue> tenues = repo.AddTenue(tenue);

            return tenue;
        }

        public void AssocierArticles(List<Haut> hauts, List<Haut> vestes, List<Bas> bas)
        {
            // Vaut mieux faire en sorte qu'on commence par celui dont on a le moins de choix
            // Si cest la veste on fait veste -> pantalon meme couleure ou couleur classique, puis on fait haut ?
            // Si cest pantalon on fait comment ?
            // Si cest haut faut encore ajouter le pantalon...
            Random random = new Random();
            int index = random.Next(hauts.Count);

            Haut haut = hauts[index];

            bool hasMotifHaut = (haut.Motifs != Motifs.pasDeMotifs);
            bool isHautManyColors = (haut.Couleur.Count > 1);

            if (vestes.Count != 0)
            {
                List<Haut> vestesCompatibles = new List<Haut>() { };

                // Exemple : Haut: blanc, rose et jaune - Veste : une couleur parmi les trois ou une couleur classique
                if (isHautManyColors)
                {
                    foreach (Haut veste in vestes)
                    {
                        bool isVesteManyColors = (veste.Couleur.Count > 1);
                        bool hasMotifVeste = (veste.Motifs != Motifs.pasDeMotifs);
                        // Si le haut a plusieurs couleurs, la veste doit avoir une seule couleur : cette couleur peut etre une des couleurs du haut ou une couleur classique
                        if (!isVesteManyColors && hasMotifVeste != hasMotifHaut || hasMotifVeste == hasMotifHaut == false && (haut.Couleur.Contains(veste.Couleur.First()) || (IsCouleurClassique(veste.Couleur.First()))))
                        {
                            vestesCompatibles.Add(veste);
                        }
                    }
                }
                // Exemple : Haut: rouge - Veste : une couleur classique ou une veste multicolore avec du rouge dedans
                if (!isHautManyColors && !IsCouleurClassique(haut.Couleur.First()))
                {
                    foreach (Haut veste in vestes)
                    {
                        bool isVesteManyColors = (veste.Couleur.Count > 1);
                        bool hasMotifVeste = (veste.Motifs != Motifs.pasDeMotifs);

                        // Si le haut a une seule couleur pas classique je met une veste avec plusieurs couleurs contenant cette couleur ou une veste de couleur classique
                        if (hasMotifVeste != hasMotifHaut || hasMotifVeste == hasMotifHaut == false && ((!isVesteManyColors && IsCouleurClassique(veste.Couleur.First())) || (isVesteManyColors && veste.Couleur.Contains(haut.Couleur.First()))))

                            if ((!isVesteManyColors && IsCouleurClassique(veste.Couleur.First()) && hasMotifVeste != hasMotifHaut))
                            {
                                vestesCompatibles.Add(veste);
                            }
                        if (isVesteManyColors && veste.Couleur.Contains(haut.Couleur.First()) && hasMotifVeste != hasMotifHaut || hasMotifVeste == hasMotifHaut == false)
                        {
                            vestesCompatibles.Add(veste);
                        }
                    }
                }
                // Cas haut couleur classique, veste peut etre multicolore ou pas, couleures classiques ou pas.. pas besoin de traiter ce cas

            }

            //List<Bas> basCompatibles = hasMotifHaut ? bas.Where(bas => bas.Motifs == Motifs.pasDeMotifs).ToList() : bas;
        }

        public bool IsCouleurClassique(Couleur couleur)
        {
            List<Couleur> couleursClassiques = new List<Couleur>() { Couleur.noir, Couleur.blanc, Couleur.beige, Couleur.gris, Couleur.denim };
            return couleursClassiques.Contains(couleur);
        }

        /// <summary>
        /// Returns the tenue with the given id
        /// </summary>
        /// <param name="id">tenue id</param>
        /// <returns></returns>
        public TenueDTO FindDTOById(string id)
        {
            return this.repo.FindDTOById(id);
        }


    }
}
