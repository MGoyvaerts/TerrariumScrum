using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    class Program
    {
        static void Main(string[] args)
        {
            CreeerRaster();
            Console.ReadLine();
        }
        static void CreeerRaster()
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
                    int ingevuld = rnd.Next(1, 6);      //dit geeft 1/5 kans dat het raster met een organisme wordt ingevuld.
                    if (ingevuld < 2)
                    {
                        int organismeSoort = rnd.Next(1, 4);
                        switch (organismeSoort)
                        {
                            case 1:
                                raster[rij, kolom] = Plant;
                                break;
                            case 2:
                                raster[rij, kolom] = Herbivoor;
                                break;
                            case 3:
                                raster[rij, kolom] = Carnivoor;
                                break;
                        }
                    }
                    Console.Write(raster[rij, kolom] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
