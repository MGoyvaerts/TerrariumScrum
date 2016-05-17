using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public abstract class Organisme : IOrganisme
    {

        abstract public int Levenskracht { get; set; }

        public Organisme(int rij, int kolom, int levenskracht) // elk organisme ontstaat met levenskracht 0 tenzij specifiek anders vermeld
        {
            Rij = rij;
            Kolom = kolom;
            Levenskracht = levenskracht;
        }

        public int Rij {get; set;}

        public int Kolom { get; set; }

        bool HeeftActieGedaan = false;

        public IOrganisme[,] DoeActie(IOrganisme[,] grid)
        {
            IOrganisme rechterplaats;
            Organisme linkerplaats;
            linkerplaats = this;
            rechterplaats.Rij = this.Rij;
            rechterplaats.Kolom = this.Kolom + 1;

            if (rechterplaats is Organisme)
            {
                if (linkerplaats is Plant) // this is plant
                {
                    if (grid[huidigeRij, huidigeKolom] is Plant)
                    {

                    }
                    else if (grid[huidigeRij, huidigeKolom] is Herbivoor)
                    {
                        Herbivoor huidigeHerbivoor = (Herbivoor)grid[huidigeRij, huidigeKolom];
                        if (grid[rechterplaatsRij, rechterplaatsKolom] is Herbivoor)
                        {
                            Vrijen();
                        }
                        else if (grid[rechterplaatsRij, rechterplaatsKolom] is Plant)
                        {
                            Eten();
                        }
                    }
                    else if (grid[huidigeRij, huidigeKolom] is Carnivoor)
                    {
                        Carnivoor huidigeCarnivoor = (Carnivoor)grid[huidigeRij, huidigeKolom];
                        if (grid[rechterplaatsRij, rechterplaatsKolom] is Herbivoor)
                        {
                            Eten();
                        }
                        else if (grid[rechterplaatsRij, rechterplaatsKolom] is Carnivoor)
                        {
                            Vechten();
                        }
                    }
                }
                else
                {
                    Verplaatsen();
                }
                linkerplaats.HeeftActieGedaan = true;
                return grid;
            }
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

