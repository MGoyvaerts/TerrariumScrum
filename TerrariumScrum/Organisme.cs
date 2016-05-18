using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public abstract class Organisme : IOrganisme
    {
        public abstract int Levenskracht { get; set; }

        public Organisme(int rij, int kolom, int levenskracht) // elk organisme ontstaat met levenskracht 0 tenzij specifiek anders vermeld
        {
            Rij = rij;
            Kolom = kolom;
            Levenskracht = levenskracht;
        }

        public int Rij { get; set; }

        public int Kolom { get; set; }

        public bool HeeftActieGedaan { get; set; }

        public IOrganisme[,] DoeActie(IOrganisme[,] grid)
        {
            int lengteRij = grid.GetLength(0);
            int lengteKolom = grid.Length / grid.GetLength(0);
            int huidigeRij = this.Rij;
            int huidigeKolom = this.Kolom;
            int rechterplaatsRij = this.Rij;
            int rechterplaatsKolom = this.Kolom + 1;
            if (rechterplaatsKolom < lengteKolom)
            {
                if (grid[huidigeRij, huidigeKolom] is Organisme) // this is plant
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
                            huidigeHerbivoor.HeeftActieGedaan = true;
                        }
                        else if (grid[rechterplaatsRij, rechterplaatsKolom] is Plant)
                        {
                            huidigeHerbivoor.Eten((Organisme)grid[rechterplaatsRij, rechterplaatsKolom], grid);
                            huidigeHerbivoor.HeeftActieGedaan = true;
                        }
                    }
                    else if (grid[huidigeRij, huidigeKolom] is Carnivoor)
                    {
                        Carnivoor huidigeCarnivoor = (Carnivoor)grid[huidigeRij, huidigeKolom];
                        if (grid[rechterplaatsRij, rechterplaatsKolom] is Herbivoor)
                        {
                            huidigeCarnivoor.Eten((Herbivoor)grid[rechterplaatsRij, rechterplaatsKolom], grid);
                            huidigeCarnivoor.HeeftActieGedaan = true;
                        }
                        else if (grid[rechterplaatsRij, rechterplaatsKolom] is Carnivoor)
                        {
                                Carnivoor nieuweCarnivoor = new Carnivoor();
                                Carnivoor links = (Carnivoor)grid[huidigeRij, huidigeKolom];
                                Carnivoor rechts = (Carnivoor)grid[rechterplaatsRij, rechterplaatsKolom];
                                nieuweCarnivoor = (Carnivoor)nieuweCarnivoor.Vechten(links, rechts);
                                if (nieuweCarnivoor == null)
                                {
                                    grid[huidigeRij, huidigeKolom] = links;
                                    grid[rechterplaatsRij, rechterplaatsKolom] = rechts;
                                }
                                else if (nieuweCarnivoor.Kolom == links.Kolom)
                                {
                                    grid[huidigeRij, huidigeKolom] = nieuweCarnivoor;
                                    grid[rechterplaatsRij, rechterplaatsKolom] = new GeenOrganisme();
                                }
                                else if (nieuweCarnivoor.Kolom == rechts.Kolom)
                                {
                                    grid[huidigeRij, huidigeKolom] = new GeenOrganisme();
                                    grid[rechterplaatsRij, rechterplaatsKolom] = nieuweCarnivoor;
                                }
                            huidigeCarnivoor.HeeftActieGedaan = true;
                        }
                    }

                    //****Verplaatsen****///
                }
            }
            else
            {
                if (!(grid[huidigeRij, huidigeKolom] is Plant))
                {
                    Dier huidigDier = (Dier)grid[huidigeRij, huidigeKolom];
                }
            }
            if (grid[huidigeRij, huidigeKolom] is Dier && ((Organisme)grid[huidigeRij, huidigeKolom]).HeeftActieGedaan == false)//controle in het grid of het object een dier is.
            {
                if (huidigeKolom < lengteKolom-1)// hier worden dieren in de laatste kolom niet verplaatst. 
                //dit is nodig omdat de kolom naast de laatste kolom niet bestaat en ook niet gecontroleerd kan worden.
                //wordt hieronder wel opgelost.
                {
                    if (grid[huidigeRij, huidigeKolom + 1] is GeenOrganisme)// hier wordt gecontroleerd of er rechts naast het dier iets staat.
                    //staat er niets (GeenOrganisme) wordt het dier verplaatst anders niet.
                    {
                        grid = ((Dier)grid[huidigeRij, huidigeKolom]).Verplaatsen(grid, (Dier)grid[huidigeRij, huidigeKolom]);//verplaatsen op het object oproepen.
                    }
                }
                if (huidigeKolom == lengteKolom-1)//om het dier in de laatste kolom te verplaatsen.
                {
                    grid = ((Dier)grid[huidigeRij, huidigeKolom]).Verplaatsen(grid, (Dier)grid[huidigeRij, huidigeKolom]);//verplaatsen op het object oproepen.
                }
            }
            for (int i = 0; i < lengteRij; i++)
            {
                for (int j = 0; j < lengteKolom; j++)
                {
                    if (grid[i, j] is Dier)
                    {
                        ((Dier)grid[i, j]).IsVerplaatst = false;
                    }
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


