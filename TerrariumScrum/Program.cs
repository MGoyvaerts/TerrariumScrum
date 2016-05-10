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
            Console.ReadLine();
        }
        public void NieuwOrganisme(Organisme organisme, int aantalHerbivoren, string[,] grid)
        {
            Random rnd = new Random();
            int aantalNieuwePlanten = rnd.Next(1, 4);  //Random aantal planten toevoegen
            while (aantalNieuwePlanten != 0)
            {
                InvullenPlantenHerbivorenBijVolgendeDag(grid, organisme.Letter, aantalNieuwePlanten);
            }
            while (aantalHerbivoren != 0)
            {
                InvullenPlantenHerbivorenBijVolgendeDag(grid, organisme.Letter, aantalHerbivoren);
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
