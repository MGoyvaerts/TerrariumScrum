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

        bool HeeftActieGedaan = false;

        public Raster DoeActie(Raster grid)
        {
            IOrganisme rechterplaats;
            Organisme linkerplaats;
            linkerplaats = this;
            rechterplaats.Rij = this.Rij;
            rechterplaats.Kolom = this.Kolom + 1;
            
            if (rechterplaats is Organisme)
            {
                if (linkerplaats is Plant ) 
                {
                    
                }
                else if (linkerplaats is Herbivoor) 
                {
                    Herbivoor herbLinks = (Herbivoor)linkerplaats;
                    if (rechterplaats is Herbivoor)
                    {
                        herbLinks.Vrijen(grid);
                    }
                    else if (rechterplaats is Plant)
                    {  
                        herbLinks.Eten((Plant)rechterplaats, grid);
                    }
                }
                else if (linkerplaats is Carnivoor)
                {
                    Carnivoor carnLinks = (Carnivoor)linkerplaats;
                    if (rechterplaats is Herbivoor)
	                {
                        CarnLinks.Eten((Herbivoor)rechterplaats, grid);
	                }
                    else if (rechterplaats is Carnivoor)
	                {
		                CarnLinks.Vechten((Carnivoor)linkerplaats,(Carnivoor)rechterplaats, grid);
	                }
                }
            }
            else
            {
                Dier dierLinks = (Dier)linkerplaats;
                dierLinks.Verplaatsen(grid);
            }
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

