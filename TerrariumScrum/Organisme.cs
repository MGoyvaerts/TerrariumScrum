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
            IOrganisme rechterplaats = null;
            Organisme linkerplaats;
            linkerplaats = this;
            rechterplaats.Rij = this.Rij;
            rechterplaats.Kolom = this.Kolom + 1;
            
            if (rechterplaats is Organisme)
            {
                if (linkerplaats is Plant ) // this is plant
                {
                    
                }
                else if (linkerplaats is Herbivoor) //this is Herbivoor
                {
                    if (rechterplaats is Herbivoor)
                    {
                        //Vrijen();
                    }
                    else if (rechterplaats is Plant)
                    {
                        //Eten();
                    }
                }
                else if (linkerplaats is Carnivoor)
                {
                    if (rechterplaats is Herbivoor)
	                {
                        //Eten(); 
	                }
                    else if (rechterplaats is Carnivoor)
	                {
                        
                        //Vechten();
	                }
                }
            }
            else
            {
                //Verplaatsen();
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

