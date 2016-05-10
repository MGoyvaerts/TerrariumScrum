using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    class Program
    {
        static void CreeerRaster()
        {
            string[,] raster = new string[6, 6];
            Random rnd = new Random();
            int aantalCarnivoren = 0;
            int aantalHerbivoren = 0;
            int aantalPlanten = 0;
            string Plant = "P";
            string Carnivoor = "C";
            string Herbivoor = "H";
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
                                raster[rij, kolom] = Plant;
                                aantalPlanten++;
                                break;
                            case 2:
                                raster[rij, kolom] = Herbivoor;
                                aantalHerbivoren++;
                                break;
                            case 3:
                                //raster[rij, kolom] = Carnivoor;
                                //aantalCarnivoren++;
                                break;
                        }
                    }
                    Console.Write(raster[rij, kolom] + "  ");
                }
                Console.WriteLine();
            }
            bool isIngevuld = false;
            if (aantalCarnivoren == 0)
            {

                for (int kolom = 0; kolom < 6; kolom++)
                {
                    if (isIngevuld == false)
                    {
                        for (int rij = 0; rij < 6; rij++)
                        {
                            if (raster[rij, kolom] == ".")
                            {
                                raster[rij, kolom] = Carnivoor;
                                isIngevuld = true;
                                break;
                            }
                        }
                    }
                    else
                        break;
                }
            }
            //if (aantalHerbivoren == 0)
            //{
            //    var resultaat = Array.IndexOf(raster, ".");
            //    Console.WriteLine(resultaat);
            //}
            //if (aantalPlanten == 0)
            //{
            //    var resultaat = Array.IndexOf(raster, ".");
            //    Console.WriteLine(resultaat);
            //}
        }
        static void Main(string[] args)
        {
            CreeerRaster();
            Console.ReadLine();
        }
    }
}
