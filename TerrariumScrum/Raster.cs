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
                    int willekeurigNummer = rnd.Next(1,15); // Hiermee wordt de kans bepaald voor het invullen van een organisme
                    switch (willekeurigNummer)
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
                        default:
                            raster[rij, kolom] = new GeenOrganisme(rij, kolom);
                            break;
                    }
                    Program.organismenLijst.Add(raster[rij, kolom]);
                }
            }
            if (aantalCarnivoren == 0)
            {
                NieuwOrganismeInvullenOpRandomPlaats(new Carnivoor(0, 0), 1);
            }
            if (aantalHerbivoren == 0)
            {
                NieuwOrganismeInvullenOpRandomPlaats(new Herbivoor(0, 0), 1);
            }
            if (aantalPlanten == 0)
            {
                NieuwOrganismeInvullenOpRandomPlaats(new Plant(0, 0), 1);
            }
        }

        
        
        //public void ControleerRaster()      //Dit is een controle zodat elk organsisme minstens 1 maal wordt ingevuld.
        //{   
        //    if (aantalCarnivoren == 0)      
        //    {
        //        NieuwOrganismeInvullenOpRandomPlaats(raster, new Carnivoor(0, 0), 1);
        //    }
        //    if (aantalHerbivoren == 0)
        //    {
        //        NieuwOrganismeInvullenOpRandomPlaats(raster, new Herbivoor(0, 0), 1);
        //    }
        //    if (aantalPlanten == 0)
        //    {
        //        NieuwOrganismeInvullenOpRandomPlaats(raster, new Plant(0, 0), 1);
        //    }
        //}

        public void Afbeelden()         //Het raster wordt hier afgebeeld
        {
            for (int rij = 0; rij < 6; rij++)       
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    Console.Write(raster[rij, kolom].Tostring() + "  ");                  
                }
                Console.WriteLine();
            }

    
            //List<IOrganisme> organismenLijst = new List<IOrganisme>(); 
            //for (int rij = 0; rij < 6; rij++)       
            //{
            //    for (int kolom = 0; kolom < 6; kolom++)
            //    {
            //        organismenLijst.Add(raster[rij, kolom]);
            //        Console.Write(raster[rij, kolom].Tostring() + "  ");                  
            //    }
            //    Console.WriteLine();
            //}
            //return organismenLijst;
        }

        public void VolgendeDag()
        {
            Random rnd = new Random();
            NieuwOrganismeInvullenOpRandomPlaats(new Plant(0, 0), rnd.Next(1,3));      //Bij elke volgende dag komen er 1-2 nieuwe planten bij.
            





            List<IOrganisme> organismeLijst = Program.organismenLijst;
            
            List<Organisme> organismeVerplaatstlijst = new List<Organisme>();
            
          //  ResetIsVerplaatstNaarFalse(organismeLijst);
            foreach (var organisme in organismeLijst)
            {
                if (organisme is Dier)
                {
                    if (!((Dier)organisme).IsVerplaatst)
                    {
                    raster[organisme.Rij, organisme.Kolom] = new GeenOrganisme(organisme.Rij, organisme.Kolom);

                        ((Dier)organisme).Verplaatsen(organismeLijst);
                        raster[organisme.Rij, organisme.Kolom] = organisme;

                        
                    }

                }

            }
            ResetIsVerplaatstNaarFalse(organismeLijst);



            Herbivoor nieuweHerbivoor = new Herbivoor();
            nieuweHerbivoor = nieuweHerbivoor.Vrijen(organismeLijst);
            for (int i = 0; i < organismeLijst.Count(); i++)
            {
                if (organismeLijst[i].Rij == nieuweHerbivoor.Rij && organismeLijst[i].Kolom == nieuweHerbivoor.Kolom)
                {
                    organismeLijst[i] = nieuweHerbivoor;
                }
            }
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
        public int[] WillekeurigeLegePlaatsZoeken(IOrganisme[,] grid)       //Hebben we deze method nog nodig?
        {
            Random rnd = new Random();
            int rndRij = rnd.Next(0, 5);
            int rndKolom = rnd.Next(0, 5);
            while (grid[rndRij, rndKolom].GetType() != typeof(GeenOrganisme))
            {
                rndRij = rnd.Next(0, 5);
                rndKolom = rnd.Next(0, 5);
            }
            int rij = rndRij;
            int kolom = rndKolom;//Willekeurige rij en kolom kiezen om na te gaan of deze positie leeg (.) is
            int[] waarden = { rij, kolom };
            return waarden;
        }

        private void NieuwOrganismeInvullenOpRandomPlaats(Organisme organisme, int aantal)
        {
            Random rnd = new Random();

            for (int i = 0; i < aantal; i++)
            {
                int r;
                do
                {
                    r = rnd.Next(Program.organismenLijst.Count - 1);
                }
                while (Program.organismenLijst[r] is Organisme);

                Program.organismenLijst[r] = organisme;
                organisme.Rij = Program.organismenLijst[r].Rij;
                organisme.Kolom = Program.organismenLijst[r].Kolom;
                raster[Program.organismenLijst[r].Rij, Program.organismenLijst[r].Kolom] = organisme;
            }

            //double rasterplaats = 0;
            //List<Double> rasterplaatsLijst = new List<double>();

            //for (int i = 0; i < aantal; i++)
            //{
            //    for (double rij = 0; rij < 6; rij++)       //We gaan alle lege plaatsen in het raster (GeenOrganisme) opslaan in een lijst.
            //    {
            //        for (double kolom = 0; kolom < 6; kolom++)
            //        {
            //            if (raster[(int)rij, (int)kolom].GetType() == typeof(GeenOrganisme))
            //            {
            //                rasterplaats = rij + kolom / 10.0;
            //                rasterplaatsLijst.Add(rasterplaats);
            //            }
            //        }
            //    }

            //    if (rasterplaatsLijst.Count > 0)
            //    {
            //        double randomLegePlaats = rasterplaatsLijst[rnd.Next(rasterplaatsLijst.Count() - 1)];   //We kiezen een willekeurige lege plaats uit de lijst.
            //        int _rij = (int)(randomLegePlaats - randomLegePlaats % 1.0);
            //        int _kolom = (int)Math.Round((randomLegePlaats % 1.0) * 10.0);
            //        grid[_rij, _kolom] = organisme;
            //        organisme.Rij = _rij;
            //        organisme.Kolom = _kolom;
            //        rasterplaatsLijst.Clear();
            //    }
            //    else
            //    {
            //        Console.WriteLine("\nHET TERRARIUM KAN NIET VERDER WORDEN OPGEVULD.");
            //        break;
            //    }
            //}
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
