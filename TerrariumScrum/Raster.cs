using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Raster
    {
        IOrganisme[,] raster = new IOrganisme[6, 6];
        int aantalCarnivoren = 0;
        int aantalHerbivoren = 0;
        int aantalPlanten = 0;
        
        public void CreeerRaster()      //Een nieuwe raster wordt gecreeerd maar nog niet afgebeeld.
        {
            Random rnd = new Random();      
            
            for (int rij = 0; rij < 6; rij++)
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    raster[rij, kolom] = new GeenOrganisme(rij, kolom);     //Het raster wordt eerst volledig ingevuld met een GeenOrganisme-objecten
                    int ingevuld = rnd.Next(1, 6);      //dit geeft 1/5 kans dat het raster met een organisme wordt ingevuld
                    if (ingevuld < 2)
                    {
                        int organismeSoort = rnd.Next(1, 4);
                        switch (organismeSoort)
                        {
                            case 1:
                                raster[rij, kolom] = new Plant(rij, kolom);
                                aantalPlanten++;
                                break;
                            case 2:
                                raster[rij, kolom] = new Herbivoor(rij, kolom);
                                aantalHerbivoren++;
                                break;
                            case 3:
                                raster[rij, kolom] = new Carnivoor(rij, kolom);
                                aantalCarnivoren++;
                                break;
                        }
                    }
                }
            }
        }
        
        public void ControleerRaster()      //Dit is een controle zodat elk organsisme minstens 1 maal wordt ingevuld.
        {   
            if (aantalCarnivoren == 0)      
            {
                InvullenPlantenHerbivorenBijVolgendeDag(raster, new Carnivoor(0, 0), 1);
            }
            if (aantalHerbivoren == 0)
            {
                InvullenPlantenHerbivorenBijVolgendeDag(raster, new Herbivoor(0,0), 1);
            }
            if (aantalPlanten == 0)
            {
                InvullenPlantenHerbivorenBijVolgendeDag(raster, new Plant(0, 0), 1);
            }
        }

        public void Afbeelden()         //Het raster wordt hier afgebeeld.
        {
            for (int rij = 0; rij < 6; rij++)       
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    Console.Write(raster[rij, kolom].Tostring() + "  ");                  
                }
                Console.WriteLine();
            } 
        }

        public void VolgendeDag()
        {
            for (int rij = 0; rij < 6; rij++)
            {
                for (int kolom = 0; kolom < 6; kolom++)     //We gaan hier alle plaatsen van het raster af en kijken wat voor soort organisme het is.
                {
                    if (raster[rij, kolom].GetType() == typeof(GeenOrganisme))
                    {
                        //Geef hier code in
                    }
                    else if (raster[rij, kolom].GetType() == typeof(Carnivoor))
                    {
                        //Geef hier code in
                    }
                    else if (raster[rij, kolom].GetType() == typeof(Herbivoor))
                    {
                        //Geef hier code in
                    }
                    else if (raster[rij, kolom].GetType() == typeof(Plant))
                    {
                        //Geef hier code in
                    }
                }
            } 
        }
        public void NieuwOrganisme(Organisme organisme, int aantalHerbivoren, IOrganisme[,] grid)
        {
            Random rnd = new Random();
            int aantalNieuwePlanten = rnd.Next(1, 4);  //Random aantal planten toevoegen
            while (aantalNieuwePlanten != 0)
            {
                InvullenPlantenHerbivorenBijVolgendeDag(grid, organisme, aantalNieuwePlanten);
            }
            while (aantalHerbivoren != 0)
            {
                InvullenPlantenHerbivorenBijVolgendeDag(grid, organisme, aantalHerbivoren);
            }
        }

        private void InvullenPlantenHerbivorenBijVolgendeDag(IOrganisme[,] grid, Organisme organisme, int aantal)   
        {
            Random rnd = new Random();
            for (int i = 0; i < aantal; i++)
            {
                bool randomIngevuld = false;
                while (randomIngevuld == false)
                {
                    int rndRij = rnd.Next(0, 6);
                    int rndKolom = rnd.Next(0, 6);
                    if (grid[rndRij, rndKolom].GetType() == typeof(GeenOrganisme)) //Willekeurige rij en kolom kiezen om na te gaan of deze positie leeg (.) is
                    {
                        grid[rndRij, rndKolom] = organisme;
                        randomIngevuld = true;
                    }
                }
            }
        }

        private GeenOrganisme Opgegeten(Organisme links, Organisme rechts)
        {
            GeenOrganisme legePlaats = new GeenOrganisme(rechts.Rij, rechts.Kolom);
            return legePlaats;
            //if ((links == typeof(Herbivoor)) && (rechts == typeof(Plant)))
            //{
            //    links.Levenskracht++;
            //}
            //else if((links == typeof(Carnivoor)) && (rechts == typeof(Herbivoor)))
            //{
            //    links.Levenskracht = links.Levenskracht + rechts.Levenskracht;
            //}
            //else if ((links == typeof(Carnivoor)) && (rechts == typeof(Carnivoor)))
            //{
            //   Carnivoor carnivoor = new Carnivoor();
            //   Carnivoor cLinks = (Carnivoor)links;
            //   Carnivoor cRechts = (Carnivoor)rechts;
            //   carnivoor.Vechten(cLinks, cRechts);
            //}
            
        }
    }
}
