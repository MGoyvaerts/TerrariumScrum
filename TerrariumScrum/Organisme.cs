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
            //IOrganisme rechterplaats = new IOrganisme();
            //Organisme linkerplaats; 
            int huidigeRij = this.Rij;
            int huidigeKolom = this.Kolom;
            int rechterplaatsRij = this.Rij;
            int rechterplaatsKolom = this.Kolom + 1;
            
            if (grid[huidigeRij, huidigeKolom] is Organisme)
            {
                if (grid[huidigeRij, huidigeKolom] is Plant ) 
                {
                    
                }
                else if (grid[huidigeRij, huidigeKolom] is Herbivoor) 
                {
                    Herbivoor huidigeHerbivoor = (Herbivoor)grid[huidigeRij, huidigeKolom];
                    if (grid[rechterplaatsRij, rechterplaatsKolom] is Herbivoor)
                    {
                        //Herbivoor huidigeHerbivoor = (Herbivoor)grid[rechterplaatsRij, rechterplaatsKolom];
                        //huidigeHerbivoor.Vrijen(grid);
                    }
                    else if (grid[rechterplaatsRij, rechterplaatsKolom] is Plant)
                    {  
                    huidigeHerbivoor.Eten((Organisme)grid[rechterplaatsRij, rechterplaatsKolom], grid);
                    }
                }
                else if (grid[huidigeRij, huidigeKolom] is Carnivoor)
                {
                    Carnivoor huidigeCarnivoor = (Carnivoor)grid[huidigeRij, huidigeKolom];
                    if (grid[rechterplaatsRij, rechterplaatsKolom] is Herbivoor)
                    {
                        huidigeCarnivoor.Eten((Herbivoor)grid[rechterplaatsRij, rechterplaatsKolom], grid);
                    }
                    //else if (rechterplaats is Carnivoor)
                    //{
                    //    carnLinks.Vechten((Carnivoor)linkerplaats, (Carnivoor)rechterplaats, grid);
                    //}
                }
            }
            //else
            //{
            //    Dier dierLinks = (Dier)linkerplaats;
            //    dierLinks.Verplaatsen(grid);
            //}
            
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

