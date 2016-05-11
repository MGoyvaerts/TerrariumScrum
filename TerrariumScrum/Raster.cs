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
                raster[Program.organismenLijst[r].Rij, Program.organismenLijst[r].Kolom] = organisme;

                
                // Lijst met vrije plaatsen aanmaken
                //vrijePlaatsen = new List<IOrganisme>();
                //foreach (var org in Program.organismenLijst)
                //{
                //    if (org is GeenOrganisme)
                //        vrijePlaatsen.Add(org);
                //}


                //// willekeurige lege plaats opvullen met organisme
                //int r = rnd.Next(vrijePlaatsen.Count - 1);
                //IOrganisme willekeurig = vrijePlaatsen[r];
                //grid[willekeurig.Rij, willekeurig.Kolom] = organisme;
            }



            //double rasterplaats = 0;
            //List<Double> rasterplaatsLijst = new List<double>();
            //for (int i = 0; i < aantal; i++)
            //{
            //    for (double rij = 0; rij < 6; rij++)       //We gaan alle lege plaatsen in het raster (GeenOrganisme) opslaan in een lijst.
            //    {
            //        for (double kolom = 0; kolom < 6; kolom++)
            //        {
            //            if (raster[(int)rij,(int)kolom].GetType() == typeof(GeenOrganisme))
            //            {
            //                rasterplaats = rij + kolom / 10;
            //                rasterplaatsLijst.Add(rasterplaats);
            //            }
            //        }
            //    }
            //    bool randomIngevuld = false;
            //    while (randomIngevuld == false)
            //    {
            //        double randomLegePlaats = rasterplaatsLijst[rnd.Next(rasterplaatsLijst.Count() - 1)];   //We kiezen een willekeurige lege plaats uit de lijst.
            //        int rij = (int)(randomLegePlaats - randomLegePlaats % 1);
            //        int kolom = (int)((randomLegePlaats % 1.0)*10.0);
            //        grid[rij, kolom] = organisme;
            //        organisme.Rij = rij;
            //        organisme.Kolom = kolom;
            //        randomIngevuld = true;
            //    }
            //}
        }

        public void Afbeelden()         //Het raster wordt hier afgebeeld en gereturned.
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
            Random rnd = new Random();
            NieuwOrganismeInvullenOpRandomPlaats(new Plant(0, 0), 6); //rnd.Next(1,3));      //Bij elke volgende dag komen er 1-2 nieuwe planten bij.
            Herbivoor nieuweHerbivoor = new Herbivoor();
            for (int rij = 0; rij < 6; rij++)
            {
                for (int kolom = 0; kolom < 6; kolom++)     //We gaan hier alle plaatsen af.
                {
                    //if (raster[rij, kolom].GetType() == typeof(GeenOrganisme))
                    //{
                    //    //Geef hier code in
                    //}
                    //else if (raster[rij, kolom].GetType() == typeof(Carnivoor))
                    //{
                    //    //Geef hier code in
                    //}
                    if (raster[rij, kolom].GetType() == typeof(Herbivoor) && kolom < 5)
                    {
                        if (raster[rij, kolom + 1].GetType() == typeof(Herbivoor))
                        {
                            nieuweHerbivoor.Vrijen();
                            int[] waarden = WillekeurigeLegePlaatsZoeken(raster);
                            nieuweHerbivoor.Rij = waarden[0];
                            nieuweHerbivoor.Kolom = waarden[1];
                            nieuweHerbivoor.Levenskracht = 0;
                            raster[waarden[0], waarden[1]] = nieuweHerbivoor;
                        }
                    }
                    //else if (raster[rij, kolom].GetType() == typeof(Plant))
                    //{
                    //    //Geef hier code in
                    //}
                    ResetIsVerplaatstNaarFalse();
                }
            }
        }
        private void ResetIsVerplaatstNaarFalse()
        {
            List<IOrganisme> organismenLijst = new List<IOrganisme>();
            foreach (Dier dier in organismenLijst)
            {
                dier.IsVerplaatst = false;
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
