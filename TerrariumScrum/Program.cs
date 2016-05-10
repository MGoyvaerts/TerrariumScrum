using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    class Program
    {
        static string[,] CreeerRaster()
        {
            string[,] raster = new string[6, 6];
            Random rnd = new Random();
            //int aantalCarnivoren = rnd.Next(3, 8);
            //int aantalHerbivoren = rnd.Next(3, 8);
            //int aantalPlanten = rnd.Next(3, 12);
            string Plant = "P";
            string Carnivoor = "C";
            string Herbivoor = "H";
            //Console.WriteLine(aantalCarnivoren + ", " + aantalHerbivoren + ", " + aantalPlanten);
            for (int kolom = 0; kolom < 6; kolom++)
            {
                for (int rij = 0; rij < 6; rij++)
                {
                    raster[rij, kolom] = ".";
                    int ingevuld = rnd.Next(1, 6);      //dit geeft 1/5 kans dat het raster met een organisme wordt ingevuld
                    if (ingevuld < 2)
                    {
                        int organismeSoort = rnd.Next(1, 4);
                        switch (organismeSoort)
                        {
                            case 1:
                                Plant plant = new Plant(kolom, rij, 1, "P");
                                raster[rij, kolom] = plant.Letter;
                                break;
                            case 2:
                                Herbivoor herbivoor=new Herbivoor(1, kolom, rij, "H");
                                raster[rij, kolom] = herbivoor.Letter;
                                break;
                            case 3:
                                Carnivoor carnivoor = new Carnivoor(1, kolom, rij, "C");
                                raster[rij, kolom] = carnivoor.Letter;
                                break;
                        }
                    }
                    Console.Write(raster[rij, kolom] + "  ");
                }
                Console.WriteLine();
            }
            return raster;
        }

        //static int Paren(string[,] raster)
        //{
        //    int aantal = 0;
        //    for (int i = 0; i < 6; i++)
        //    {
        //        for (int j = 0; j < 6; j++)
        //        {
        //            if (raster[i, j] == "H" && i < 5 && raster[i + 1, j] == "H")
        //            {
        //                aantal++;
        //            }
        //        }
        //    }
        //    return aantal;
        //}
        static void Main(string[] args)
        {
        }
    }
}
