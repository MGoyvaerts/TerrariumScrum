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
            string[,] terrarium = raster.CreeerRaster();
            //raster.CreeerRaster();
            raster.ControleerRaster();
            raster.Afbeelden();
            int aantal = ControleerHerbivoor(terrarium);
            Console.WriteLine(aantal);
            Console.ReadLine();
        }
    }
}
