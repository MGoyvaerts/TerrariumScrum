﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Dier:Organisme
    {
        public Dier(int rij, int kolom)
            : base(rij, kolom)
        {

        }
        public Dier()
        {

        }
        
        public bool IsVerplaatst = false;
        public IOrganisme[,] Verplaatsen(IOrganisme[,] grid, Dier dier)
        {
            //de rij & kolom van het dier worden aangepast (en dat dier wordt dan terug gestuurd.)
            Random random = new Random();

            int willGetal = 0;
            grid[dier.Rij, dier.Kolom] = new GeenOrganisme(dier.Rij, dier.Kolom);

            int rij = dier.Rij;
            int kolom = dier.Kolom;

            if (!dier.IsVerplaatst)
            {
                willGetal = random.Next(1, 5);
                switch (willGetal)
                {
                    case 1:
                        if (dier.Kolom < 5)
                        {
                            if (!(grid[rij, kolom + 1] is Organisme))
                                dier.Kolom += 1;
                        }                    
                        break;
                    case 2:
                        if (dier.Kolom > 0)
                        {
                            if (!(grid[rij, kolom - 1] is Organisme))
                            {
                                dier.Kolom -= 1;
                            }
                        }
                        break;
                    case 3:
                        if (dier.Rij < 5)
                        {
                            if (!(grid[rij + 1, kolom] is Organisme))
                            {
                                dier.Rij += 1;
                            }
                        }
                        break;
                    case 4:
                        if (dier.Rij > 0)
                        {
                            if (!(grid[rij - 1, kolom] is Organisme))
                            {
                                dier.Rij -= 1;
                            }
                        }
                        break;
                }
            }





            grid[dier.Rij, dier.Kolom] = dier;

            dier.IsVerplaatst = true;
            //Console.WriteLine(willGetal);
            return grid;
        }
        public Dier Eten(Dier dier, Organisme organisme)
        {
            //geeft het dier terug met de levenskracht van het organisme dat ie gaat opeten.
            dier.Levenskracht += organisme.Levenskracht;
            return dier;
        }
    }
}
