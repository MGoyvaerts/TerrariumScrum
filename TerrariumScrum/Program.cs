﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    class Program
    {
        static List<IOrganisme> organismenLijst; 
        static void Main(string[] args)
        {
            Raster raster = new Raster();
            raster.CreeerRaster();
            raster.ControleerRaster();
            organismenLijst = raster.Afbeelden();

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
                    raster.VolgendeDag(organismenLijst);
                    raster.Afbeelden();
                    //hier komt methode om de dagelijkse acties uit te voeren
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Druk v en <ENTER> om naar de volgende dag te gaan");
                    Console.WriteLine("Druk s en <ENTER> om het programma te sluiten");
                    input = Console.ReadLine();
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
