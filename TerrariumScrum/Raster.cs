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
                    raster[rij, kolom] = new GeenOrganisme(rij, kolom);
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
        
        bool isIngevuld = false;            //Dit dient voor de controle ofdat een organisme is ingevuld
        public void ControleerRaster()      //Dit is een controle zodat elk organsisme minstens 1 maal wordt ingevuld.
        {   
            if (aantalCarnivoren == 0)      
            {
                isIngevuld = false;
                for (int rij = 0; rij < 6; rij++)
                {
                    if (isIngevuld == false)
                    {
                        for (int kolom = 0; kolom < 6; kolom++)
                        {
                            if (raster[rij, kolom].GetType() == typeof(GeenOrganisme))
                            {
                                raster[rij, kolom] = new Carnivoor(rij, kolom);
                                isIngevuld = true;
                                break;
                            }
                        }
                    }
                    else
                        break;
                }
            }
            if (aantalHerbivoren == 0)
            {
                isIngevuld = false;
                for (int rij = 0; rij < 6; rij++)
                {
                    if (isIngevuld == false)
                    {
                        for (int kolom = 0; kolom < 6; kolom++)
                        {
                            if (raster[rij, kolom].GetType() == typeof(GeenOrganisme))
                            {
                                raster[rij, kolom] = new Herbivoor(rij, kolom);
                                isIngevuld = true;
                                break;
                            }
                        }
                    }
                    else
                        break;
                }
            }
            if (aantalPlanten == 0)
            {
                isIngevuld = false;
                for (int rij = 0; rij < 6; rij++)
                {
                    if (isIngevuld == false)
                    {
                        for (int kolom = 0; kolom < 6; kolom++)
                        {
                            if (raster[rij, kolom].GetType() == typeof(GeenOrganisme))
                            {
                                raster[rij, kolom] = new Plant(rij, kolom);
                                isIngevuld = true;
                                break;
                            }
                        }
                    }
                    else
                        break;
                }
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
                }
            }
        }
        //public void NieuwOrganisme(Organisme organisme, int aantalHerbivoren, string[,] grid)
        //{
        //    Random rnd = new Random();
        //    int aantalNieuwePlanten = rnd.Next(1, 4);  //Random aantal planten toevoegen
        //    while (aantalNieuwePlanten != 0)
        //    {
        //        InvullenPlantenHerbivorenBijVolgendeDag(grid, organisme.ToString(), aantalNieuwePlanten);
        //    }
        //    while (aantalHerbivoren != 0)
        //    {
        //        InvullenPlantenHerbivorenBijVolgendeDag(grid, organisme.ToString(), aantalHerbivoren);
        //    }
        //}

        public int[] WillekeurigeLegePlaatsZoeken(IOrganisme[,] grid)
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
        //public Herbivoor ControleerHerbivoor(IOrganisme[,] raster)
        //{
        //    Herbivoor nieuweHerbivoor = new Herbivoor();
        //    for (int i = 0; i < 6; i++)
        //    {
        //        for (int j = 0; j < 6; j++)
        //        {
        //            if (raster[i, j].ToString() == "H" && j < 5 && raster[i, j + 1].ToString() == "H")
        //            {                       
        //                nieuweHerbivoor.Vrijen();
        //                int[] waarden = WillekeurigeLegePlaatsZoeken(raster);
        //                nieuweHerbivoor.Rij = waarden[0];
        //                nieuweHerbivoor.Kolom = waarden[1];
        //                nieuweHerbivoor.Levenskracht = 0;
        //            }
        //        }
        //    }
        //    return nieuweHerbivoor;
        //}

    }
}
