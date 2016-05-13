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
            int huidigeRij = this.Rij;
            int huidigeKolom = this.Kolom;
            int rechterplaatsRij = this.Rij;
            int rechterplaatsKolom = this.Kolom + 1;
            if (rechterplaatsKolom < 6)
            {
                if (grid[huidigeRij, huidigeKolom] is Organisme)
                {
                    if (grid[huidigeRij, huidigeKolom] is Plant)
                    {

                    }
                    else if (grid[huidigeRij, huidigeKolom] is Herbivoor)
                    {
                        Herbivoor huidigeHerbivoor = (Herbivoor)grid[huidigeRij, huidigeKolom];
                        if (grid[rechterplaatsRij, rechterplaatsKolom] is Herbivoor)
                        {
                            huidigeHerbivoor.Vrijen(grid);
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
                        else if (grid[rechterplaatsRij, rechterplaatsKolom] is Carnivoor)
                        {
                            //huidigeCarnivoor.Vechten(huidigeCarnivoor, grid[rechterplaatsRij, rechterplaatsKolom], grid);
                        }
                    }
                }
            }
            else
            {
                if (!(grid[huidigeRij, huidigeKolom] is Plant))
                {
                    Dier huidigDier = (Dier)grid[huidigeRij, huidigeKolom];
                    //huidigDier.Verplaatsen(grid);
                }  
            }
            
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

