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
            raster.CreeerRaster();
            raster.ControleerRaster();
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
                    Console.WriteLine("verkeerde invoer pipo!");
                    input = Console.ReadLine();
                }
            }
        }
        public void NieuwOrganisme(Organisme organisme, int aantalHerbivoren, string[,] grid)
        {
            Random rnd = new Random();
            int aantalNieuwePlanten = rnd.Next(1, 4);  //Random aantal planten toevoegen
            while (aantalNieuwePlanten != 0)
            {
                InvullenPlantenHerbivorenBijVolgendeDag(grid, organisme.ToString(), aantalNieuwePlanten);
            }
            while (aantalHerbivoren != 0)
            {
                InvullenPlantenHerbivorenBijVolgendeDag(grid, organisme.ToString(), aantalHerbivoren);
            }
        }

        private void InvullenPlantenHerbivorenBijVolgendeDag(string[,] grid, string letter, int aantal)
        {
            Random rnd = new Random();
            int rndRij = rnd.Next(0, 5);
            int rndKolom = rnd.Next(0, 5);
            if (grid[rndRij, rndKolom] == ".") //Willekeurige rij en kolom kiezen om na te gaan of deze positie leeg (.) is
            {
                grid[rndRij, rndKolom] = letter;
            }
            aantal--;
        }
    }
}
