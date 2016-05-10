using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Raster
    {
        string[,] raster = new string[6, 6];
        int aantalCarnivoren = 0;
        int aantalHerbivoren = 0;
        int aantalPlanten = 0;
        string plant = "P";
        string carnivoor = "C";
        string herbivoor = "H";
        
        public void CreeerRaster()      //Een nieuwe raster wordt gecreeerd maar nog niet afgebeeld.
        {
            Random rnd = new Random();      
            
            for (int rij = 0; rij < 6; rij++)
            {
                for (int kolom = 0; kolom < 6; kolom++)
                {
                    raster[rij, kolom] = ".";
                    int ingevuld = rnd.Next(1, 6);      //dit geeft 1/5 kans dat het raster met een organisme wordt ingevuld
                    if (ingevuld < 2)
                    {
                        int organismeSoort = rnd.Next(1, 4);
                        switch (organismeSoort)
                        {
                            case 1:
                                raster[rij, kolom] = plant;
                                aantalPlanten++;
                                break;
                            case 2:
                                raster[rij, kolom] = herbivoor;
                                aantalHerbivoren++;
                                break;
                            case 3:
                                raster[rij, kolom] = carnivoor;
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
                            if (raster[rij, kolom] == ".")
                            {
                                raster[rij, kolom] = carnivoor;
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
                            if (raster[rij, kolom] == ".")
                            {
                                raster[rij, kolom] = herbivoor;
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
                            if (raster[rij, kolom] == ".")
                            {
                                raster[rij, kolom] = plant;
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
                    Console.Write(raster[rij, kolom] + "  ");
                }
                Console.WriteLine();
            } 
        }
    }
}
