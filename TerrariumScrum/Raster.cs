﻿using System;
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
                NieuwOrganismeInvullenOpRandomPlaats(raster, new Carnivoor(0, 0), 1);
            }
            if (aantalHerbivoren == 0)
            {
                NieuwOrganismeInvullenOpRandomPlaats(raster, new Herbivoor(0, 0), 1);
            }
            if (aantalPlanten == 0)
            {
                NieuwOrganismeInvullenOpRandomPlaats(raster, new Plant(0, 0), 1);
            }
        }

        public List<IOrganisme> Afbeelden()         //Het raster wordt hier afgebeeld en gereturned.
        {
            List<IOrganisme> organismenLijst = new List<IOrganisme>();
            for (int rij = 0; rij < 6; rij++)
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    organismenLijst.Add(raster[rij, kolom]);
                    Console.Write(raster[rij, kolom].Tostring() + "  ");
                }
                Console.WriteLine();
            }
            return organismenLijst;
        }

        public List<IOrganisme> VolgendeDag(List<IOrganisme>organismeLijst)
        {
            Herbivoor nieuweHerbivoor = new Herbivoor();
            nieuweHerbivoor = nieuweHerbivoor.Vrijen(organismeLijst);
            for (int i = 0; i < organismeLijst.Count(); i++)
            {
                if (organismeLijst[i].Rij == nieuweHerbivoor.Rij && organismeLijst[i].Kolom == nieuweHerbivoor.Kolom)
                {
                    organismeLijst[i] = nieuweHerbivoor;
                }
            }
            //Random rnd = new Random();
            //NieuwOrganismeInvullenOpRandomPlaats(raster, new Plant(0, 0), 6); //rnd.Next(1,3));      //Bij elke volgende dag komen er 1-2 nieuwe planten bij.
            
            //IOrganisme[,] grid = new IOrganisme[6, 6];
            //for (int rij = 0; rij < 6; rij++)
            //{
            //    for (int kolom = 0; kolom < 6; kolom++)     //We gaan hier alle plaatsen af.
            //    {
            //        //if (raster[rij, kolom].GetType() == typeof(GeenOrganisme))
            //        //{
            //        //    //Geef hier code in
            //        //}
            //        //else if (raster[rij, kolom].GetType() == typeof(Carnivoor))
            //        //{
            //        //    //Geef hier code in
            //        //}
            //        for (int i = 0; i < organismeLijst.Count(); i++)
            //        {

            //        }
            //            if (raster[rij, kolom].GetType() == typeof(Herbivoor) && kolom < 5)
            //            {
            //                if (raster[rij, kolom + 1].GetType() == typeof(Herbivoor))
            //                {
            //                    nieuweHerbivoor = nieuweHerbivoor.Vrijen(organismeLijst);
            //                    organismeLijst(nieuweHerbivoor);
            //                }
            //                if (raster[rij, kolom + 1].GetType() == typeof(Plant))
            //                {
            //                    Opgegeten((Organisme)raster[rij, kolom], (Organisme)raster[rij, kolom + 1]);
            //                }

            //            }
            //        //else if (raster[rij, kolom].GetType() == typeof(Plant))
            //        //{
            //        //    //Geef hier code in
            //        //}
            //    }
            //}
            return organismeLijst;
        }
        
        
        private void NieuwOrganismeInvullenOpRandomPlaats(IOrganisme[,] grid, Organisme organisme, int aantal)
        {
            Random rnd = new Random();
            double rasterplaats = 0;
            List<Double> rasterplaatsLijst = new List<double>();
            for (int i = 0; i < aantal; i++)
            {
                for (double rij = 0; rij < 6; rij++)       //We gaan alle lege plaatsen in het raster (GeenOrganisme) opslaan in een lijst.
                {
                    for (double kolom = 0; kolom < 6; kolom++)
                    {
                        if (raster[(int)rij,(int)kolom].GetType() == typeof(GeenOrganisme))
                        {
                            rasterplaats = rij + kolom / 10;
                            rasterplaatsLijst.Add(rasterplaats);
                        }
                    }
                }
                bool randomIngevuld = false;
                while (randomIngevuld == false)
                {
                    double randomLegePlaats = rasterplaatsLijst[rnd.Next(rasterplaatsLijst.Count() - 1)];   //We kiezen een willekeurige lege plaats uit de lijst.
                    int rij = (int)(randomLegePlaats - randomLegePlaats % 1);
                    int kolom = (int)((randomLegePlaats % 1.0)*10.0);
                    grid[rij, kolom] = organisme;
                    organisme.Rij = rij;
                    organisme.Kolom = kolom;
                    randomIngevuld = true;
                }
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
            else
            {
                if ((links is Herbivoor) && (rechts is Plant))
                {
                    links.Levenskracht += rechts.Levenskracht;
                    raster[rechts.Rij, rechts.Kolom] = new GeenOrganisme(rechts.Rij, rechts.Kolom);
                }
            }
            GeenOrganisme legePlaats = new GeenOrganisme(rechts.Rij, rechts.Kolom);
            return legePlaats;            
        }
    }
}
