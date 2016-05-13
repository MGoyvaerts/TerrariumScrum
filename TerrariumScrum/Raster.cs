using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Raster
    {
        int aantalCarnivoren = 0;
        int aantalHerbivoren = 0;
        int aantalPlanten = 0;

        IOrganisme[,] grid = new IOrganisme[6,6];

        public IOrganisme[,] CreeerRaster()      //Een nieuwe raster wordt gecreeerd maar nog niet afgebeeld.
        {
            Random rnd = new Random();           
            for (int rij = 0; rij < 6; rij++)
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    int willekeurigNummer = rnd.Next(1,15); // Hiermee wordt de kans bepaald voor het invullen van een organisme
                    switch (willekeurigNummer)
                    {
                        case 1:
                            grid[rij, kolom] = new Plant(rij, kolom,rnd.Next(1,10));
                            aantalPlanten++;
                            break;
                        case 2:
                            grid[rij, kolom] = new Herbivoor(rij, kolom, rnd.Next(1, 10));
                            aantalHerbivoren++;
                            break;
                        case 3:
                            grid[rij, kolom] = new Carnivoor(rij, kolom, rnd.Next(1, 10));
                            aantalCarnivoren++;
                            break;
                        default:
                            grid[rij, kolom] = new GeenOrganisme(rij, kolom);
                            break;
                    }                    
                }
            }
            if (aantalCarnivoren == 0)
            {
                NieuwOrganismeInvullenOpRandomPlaats(new Carnivoor(0, 0,rnd.Next(1,10)), 1);
            }
            if (aantalHerbivoren == 0)
            {
                NieuwOrganismeInvullenOpRandomPlaats(new Herbivoor(0, 0,rnd.Next(1,10)), 1);
            }
            if (aantalPlanten == 0)
            {
                NieuwOrganismeInvullenOpRandomPlaats(new Plant(0, 0,rnd.Next(1,10)), 1);
            }
            return grid;
        }


        public void Afbeelden(IOrganisme[,] grid)  //Het raster wordt hier afgebeeld
        {
            for (int rij = 0; rij < 6; rij++)       
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    Console.Write(grid[rij, kolom].Tostring() + "  ");                  
                }
                Console.WriteLine();
            }
        }

        public IOrganisme[,] VolgendeDag(IOrganisme[,] grid)
        {
            foreach (Organisme organisme in grid)
            {
                organisme.DoeActie(grid);
            }
            return grid;
        }
        private void ResetIsVerplaatstNaarFalse(List<IOrganisme> organismenLijst)
        {        
            foreach (var dier in organismenLijst)
            {
                if (dier is Dier)
                {
                    ((Dier)dier).IsVerplaatst = false;
                }
            }
        }

        private void NieuwOrganismeInvullenOpRandomPlaats(Organisme organisme, int aantal)
        {
            Random rnd = new Random();
            for (int i = 0; i < aantal; i++)
            {
                int rij, kolom;

                //hier wordt een rij en kolom gegenereerd om de positie in grid in te vullen en ook de parameters van het organisme. 
                do
                {
                    rij = rnd.Next(1,6);
                    kolom = rnd.Next(1,6);
                }
                while (grid[rij,kolom] is Organisme);// er wordt gecontroleerd of er op die plaats in het grid al een organisme staat;
                //staat er al een organisme wordt een nieuwe rij en kolom gegenereerd.


                //het organisme op de grid plaatsen
                grid[rij, kolom] = organisme;

                //de parameters van het organisme worden ingevuld 
                organisme.Rij = rij;
                organisme.Kolom = kolom;               
            }
        }


        private IOrganisme Opgegeten(Organisme links, Organisme rechts)
        {
            if ((links is Carnivoor) && (rechts is Carnivoor))
            {
                Carnivoor carnivoor = new Carnivoor();
                Carnivoor cLinks = (Carnivoor)links;
                Carnivoor cRechts = (Carnivoor)rechts;
                carnivoor.Vechten(cLinks, cRechts);
                if (carnivoor.Kolom == rechts.Kolom)
                {
                    GeenOrganisme legeplaats = new GeenOrganisme(links.Rij, links.Kolom);
                }
                else if (carnivoor.Kolom == links.Kolom)
                {
                    GeenOrganisme legeplaats = new GeenOrganisme(rechts.Rij, rechts.Kolom);
                }
                else
                {
                    return null;
                }
            }
            GeenOrganisme legePlaats = new GeenOrganisme(rechts.Rij, rechts.Kolom);
            return legePlaats;            
        }
    }
}
