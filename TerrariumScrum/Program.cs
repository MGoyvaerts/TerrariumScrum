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
            Raster terrarium = new Raster();
            terrarium.CreeerRaster();
            terrarium.ControleerRaster();
            terrarium.Afbeelden();
            Console.ReadLine();
        }

        static int ControleerHerbivoor(Raster raster)
        {
            var terrarium = raster;
            int aantal = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (terrarium[i, j] == "H" && i < 5 && raster[i + 1, j] == "H")
                    {
                        nieuweHerbivoor = new Herbivoor();
                    }
                }
            }
            return aantal;
        }
    }
}
