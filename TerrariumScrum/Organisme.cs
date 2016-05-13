using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public abstract class Organisme : IOrganisme
    {
        public int Levenskracht { get; set; }

        public Organisme(int rij, int kolom, int levenskracht = 0) // elk organisme ontstaat met levenskracht 0 tenzij specifiek anders vermeld
        {
            Rij = rij;
            Kolom = kolom;
        }

        public int Rij {get; set;}

        public int Kolom { get; set; }

        public bool HeeftActieGedaan { get; set; }

        public IOrganisme[,] DoeActie(IOrganisme[,] grid)
        {
            Organisme linkerplaats;
            Organisme orgRechterplaats;
            GeenOrganisme GeenOrgRechterplaats;
            linkerplaats = this;
            int rechterplaatsRij = this.Rij;
            int rechterplaatsKolom = this.Kolom + 1;
            if (grid[rechterplaatsRij,rechterplaatsKolom] is Organisme)
            {
                orgRechterplaats.Rij = rechterplaatsRij;
                orgRechterplaats.Kolom = rechterplaatsKolom;
                if (linkerplaats is Plant ) 
                {
                    
                }
                else if (linkerplaats is Herbivoor) 
                {
                    Herbivoor herbLinks = (Herbivoor)linkerplaats;
                    //if (orgRechterplaats is Herbivoor)
                    //{
                    //    herbLinks.Vrijen(grid);
                    //}
                    /*else*/ if (orgRechterplaats is Plant)
                    {  
                    herbLinks.Eten((Organisme)orgRechterplaats, grid);
                    }
                }
                else if (linkerplaats is Carnivoor)
                {
                    Carnivoor carnLinks = (Carnivoor)linkerplaats;
                    if (orgRechterplaats is Herbivoor)
                    {
                        carnLinks.Eten((Herbivoor)orgRechterplaats, grid);
                    }
                    //else if (orgRechterplaats is Carnivoor)
                    //{
                    //    carnLinks.Vechten((Carnivoor)linkerplaats, (Carnivoor)orgRechterplaats, grid);
                    //}
                }
            }
            //else
            //{
            //    Dier dierLinks = (Dier)linkerplaats;
            //    dierLinks.Verplaatsen(grid);
            //}
            linkerplaats.HeeftActieGedaan = true;
            return grid;
        }

        public virtual string Tostring()
        {
            return "";
        }
        public Organisme()
        {

        }
    }
}

