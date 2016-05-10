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
    }
}