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
        public IOrganisme[,] grid = new IOrganisme[6, 6];

        public void CreeerRaster()      //Een nieuwe raster wordt gecreeerd maar nog niet afgebeeld.
        {

            Random rnd = new Random();

            for (int rij = 0; rij < 6; rij++)
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    int willekeurigNummer = rnd.Next(1, 15); // Hiermee wordt de kans bepaald voor het invullen van een organisme
                    switch (willekeurigNummer)
                    {
                        case 1:
                            grid[rij, kolom] = new Plant(rij, kolom);
                            aantalPlanten++;
                            break;
                        case 2:
                            grid[rij, kolom] = new Herbivoor(rij, kolom);
                            aantalHerbivoren++;
                            break;
                        case 3:
                            grid[rij, kolom] = new Carnivoor(rij, kolom);
                            aantalCarnivoren++;
                            break;
                        default:
                            grid[rij, kolom] = new GeenOrganisme(rij, kolom);
                            break;
                    }
                }
            }
            if (aantalCarnivoren == 0)          //Dit is een controle zodat elk organsisme minstens 1 maal wordt ingevuld.
            {
                grid = NieuwOrganisme(grid, new Carnivoor(0, 0), 1);
            }
            if (aantalHerbivoren == 0)
            {
                grid = NieuwOrganisme(grid, new Herbivoor(0, 0), 1);
            }
            if (aantalPlanten == 0)
            {
                grid = NieuwOrganisme(grid, new Plant(0, 0), 1);
            }
        }

        public void Afbeelden()         //Het raster wordt hier afgebeeld
        {
            for (int rij = 0; rij < 6; rij++)       
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    Console.Write(this.grid[rij, kolom].Tostring() + "  ");                  
                }
                Console.WriteLine();
            }    
        }

        public void VolgendeDag()
        {
            Random rnd = new Random();
            grid = NieuwOrganisme(grid, new Plant(0, 0), rnd.Next(1, 3));      //Bij elke volgende dag komen er 1-2 nieuwe planten bij.


            foreach (Organisme org in this.grid)
            {
                if (org.HeeftActieGedaan == false)
                {
                    org.DoeActie(this.grid);
                    org.HeeftActieGedaan = true;
                }
            }
            
            //    //if (HeeftActieGedaan == false)
            //    //{
            //    //    org.DoeActie();
            //    //}
            //}



            
            //List<Organisme> organismeVerplaatstlijst = new List<Organisme>();
            
          //  ResetIsVerplaatstNaarFalse(organismeLijst);
            //foreach (var organisme in organismeLijst)
            //{
            //    if (organisme is Dier)
            //    {
            //        if (!((Dier)organisme).IsVerplaatst)
            //        {
            //        grid[organisme.Rij, organisme.Kolom] = new GeenOrganisme(organisme.Rij, organisme.Kolom);

            //            ((Dier)organisme).Verplaatsen(organismeLijst);
            //            grid[organisme.Rij, organisme.Kolom] = organisme;

                        
            //        }

            //    }

            //}
            //ResetIsVerplaatstNaarFalse(organismeLijst);

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

        public IOrganisme[,] NieuwOrganisme(IOrganisme[,] raster, Organisme organisme, int aantal)
        {
            double rasterplaats = 0;
            List<Double> rasterplaatsLijst = new List<double>();        //Hier komen alle lege plaatsen in te staan waar we dan een willekeurige plaats uit kunnen kiezen.
            Random rnd = new Random();

            for (int i = 0; i < aantal; i++)
            {
                for (double rij = 0; rij < 6; rij++)       //We gaan alle lege plaatsen in het raster (GeenOrganisme) opslaan in de lijst rasterplaatsLijst.
                {
                    for (double kolom = 0; kolom < 6; kolom++)
                    {
                        if (raster[(int)rij, (int)kolom] is GeenOrganisme)
                        {
                            rasterplaats = rij + (kolom / 10.0);        //De lege plaats wordt in een kommagetal omgezet (bv rij 4, kolom 3 wordt: 4,3).
                            rasterplaatsLijst.Add(rasterplaats);
                        }
                    }
                }

                if (rasterplaatsLijst.Count > 0)        //We controleren ofdat er nog lege plaatsen zijn.
                {
                    double randomLegePlaats = rasterplaatsLijst[rnd.Next(rasterplaatsLijst.Count() - 1)];   //We kiezen een willekeurige lege plaats uit de lijst.
                    int _rij = (int)(randomLegePlaats - randomLegePlaats % 1.0);
                    int _kolom = (int)Math.Round((randomLegePlaats % 1.0) * 10.0);      //Het getal moet hier afgerond worden want delen door een double geeft in sommige gevallen een zeer kleine precisiefout (bv 4 wordt 3.9999...)
                    raster[_rij, _kolom] = organisme;
                    organisme.Rij = _rij;
                    organisme.Kolom = _kolom;
                    rasterplaatsLijst.Clear();
                }
                else
                {
                    Console.WriteLine("\nHET TERRARIUM KAN NIET VERDER WORDEN OPGEVULD.");
                    break;
                }
            }
            return raster;
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
