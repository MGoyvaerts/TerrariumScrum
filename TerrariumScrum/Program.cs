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
    }
}
