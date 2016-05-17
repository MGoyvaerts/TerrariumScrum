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
            Raster raster = new Raster();
            IOrganisme[,] grid = new IOrganisme[6,6];
            Dier dier = new Dier();

            grid = raster.CreeerRaster();
            raster.Afbeelden(grid);
         
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
                    grid = raster.VolgendeDag(grid);


                    for (int i = 0; i < 6; i++)//2 iteraties om de grid te doorlopen.
                    { 
                        for (int j = 0; j < 6; j++)
                        {
                            if (grid[i, j] is Dier)//controle in het grid of het object een dier is.
                            {
                                if (j < 5)// hier worden dieren in de laatste kolom niet verplaatst. 
                                    //dit is nodig omdat de kolom naast de laatste kolom niet bestaat en ook niet gecontroleerd kan worden.
                                    //wordt hieronder wel opgelost.
                                {
                                    if (grid[i, j + 1] is GeenOrganisme)// hier wordt gecontroleerd of er rechts naast het dier iets staat.
                                        //staat er niets (GeenOrganisme) wordt het dier verplaatst anders niet.
                                    {
                                        grid = ((Dier)grid[i, j]).Verplaatsen(grid, (Dier)grid[i, j]);//verplaatsen op het object oproepen.
                                    }
                                }
                                if (j == 5)//om het dier in de laatste kolom te verplaatsen.
                                {
                                    grid = ((Dier)grid[i, j]).Verplaatsen(grid, (Dier)grid[i, j]);//verplaatsen op het object oproepen.
                                }
                            }
                        }
                    }


                    //grid isverplaatst resetten
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (grid[i, j] is Dier)
                            {
                                ((Dier)grid[i, j]).IsVerplaatst= false;
                            }
                        }
                    }

                        raster.Afbeelden(grid);
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
