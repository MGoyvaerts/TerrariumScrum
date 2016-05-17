using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    class Program
    {
        public static bool terrariumVolledigGevuld = false;
        static void Main(string[] args)
        {
            Raster raster = new Raster();
            IOrganisme[,] grid = new IOrganisme[6,6];
            

            raster.CreeerRaster();
            raster.Afbeelden();
         
                // Hier komt de fase waarbij de gebruiker de keuze krijgt om naar de volgende dag te gaan of om te stoppen
                // Dit kan eventueel nog in een aparte method geschreven worden
                Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Druk v en <ENTER> om naar de volgende dag te gaan");
            Console.WriteLine("Druk s en <ENTER> om het programma te sluiten");
            var input = Console.ReadLine();
            while (input != "s")
            {
                if (input == "v")
                {

                    if (terrariumVolledigGevuld == false)
                    {
                        raster.VolgendeDag();

                        raster.Afbeelden();

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Druk v en <ENTER> om naar de volgende dag te gaan");
                        Console.WriteLine("Druk s en <ENTER> om het programma te sluiten");
                        input = Console.ReadLine(); 
                    }
                    else
                    {
                        Console.WriteLine("HET TERRARIUM KAN NIET VERDER WORDEN OPGEVULD.");
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Druk v en <ENTER> om naar de volgende dag te gaan");
                    Console.WriteLine("Druk s en <ENTER> om het programma te sluiten");
                    input = Console.ReadLine();
                }
            }
        }
    }
}
