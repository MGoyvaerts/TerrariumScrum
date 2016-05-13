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

        //bool HeeftActieGedaan = false;

        public IOrganisme[,] DoeActie(IOrganisme[,] grid)
        {
            Organisme rechterplaats = null;
            Organisme linkerplaats = null;
            int rij = 0;
            int kolom = 0;
            while (rij < 6 && kolom <= 5)
            {
                for (rij = 0; rij < 6; rij++)
                {
                    for (kolom = 0; kolom < 6; kolom++)
                    {
                        linkerplaats = (Organisme)grid[rij, kolom];
                        rechterplaats = (Organisme)grid[rij, kolom];
                        if (rechterplaats is Organisme)
                        {
                            if (linkerplaats is Plant) // this is plant
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
                                    Carnivoor nieuweCarnivoor = new Carnivoor();
                                    nieuweCarnivoor = (Carnivoor)nieuweCarnivoor.Vechten(linkerplaats, rechterplaats);
                                    if (nieuweCarnivoor == linkerplaats)
                                    {
                                        grid[linkerplaats.Rij, linkerplaats.Kolom] = nieuweCarnivoor;
                                        grid[rechterplaats.Rij, linkerplaats.Kolom] = new GeenOrganisme();
                                    }
                                    else if(nieuweCarnivoor == rechterplaats)
                                    {
                                        grid[linkerplaats.Rij, linkerplaats.Kolom] = new GeenOrganisme();
                                        grid[rechterplaats.Rij, linkerplaats.Kolom] = nieuweCarnivoor;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Verplaatsen();
                        }
                    }
                }
            }
            

                //IOrganisme rechterplaats;
                //Organisme linkerplaats;
                //linkerplaats = this;
                //rechterplaats.Rij = this.Rij;
                //rechterplaats.Kolom = this.Kolom + 1;

                //if (rechterplaats is Organisme)
                //{
                //    if (linkerplaats is Plant) // this is plant
                //    {

                //    }
                //    else if (linkerplaats is Herbivoor) //this is Herbivoor
                //    {
                //        if (rechterplaats is Herbivoor)
                //        {
                //            //Vrijen();
                //        }
                //        else if (rechterplaats is Plant)
                //        {
                //            //Eten();
                //        }
                //    }
                //    else if (linkerplaats is Carnivoor)
                //    {
                //        if (rechterplaats is Herbivoor)
                //        {
                //            //Eten(); 
                //        }
                //        else if (rechterplaats is Carnivoor)
                //        {
                //            //Vechten();
                //        }
                //    }
                //}
                //else
                //{
                //    //Verplaatsen();
                //}
            //linkerplaats.HeeftActieGedaan = true;
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

