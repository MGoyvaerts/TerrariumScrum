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
                        Console.WriteLine("\n### HET TERRARIUM KAN NIET VERDER WORDEN OPGEVULD. ###");
                        Console.WriteLine("Druk op <ENTER> om het programma te sluiten");
                        Console.ReadLine();
                        break;
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
