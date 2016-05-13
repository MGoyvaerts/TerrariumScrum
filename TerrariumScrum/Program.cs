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
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (grid[i, j] is Dier)
                            {
                                if (j < 5)
                                {
                                    if (grid[i, j + 1] is GeenOrganisme)
                                    {
                                        grid = ((Dier)grid[i, j]).Verplaatsen(grid, (Dier)grid[i, j]);
                                    }
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
