using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Herbivoor : Dier
    {
        public Herbivoor(int rij, int kolom)
            : base(rij, kolom)
        {

        }
        public Herbivoor()
        {

        }
        public IOrganisme[,] Vrijen(IOrganisme[,] grid)
        {
            Herbivoor nieuweHerbivoor = new Herbivoor();
            Raster raster = new Raster();
            grid = raster.NieuwOrganisme(grid, nieuweHerbivoor, 1);
            return grid;
        }

        public override string Tostring()
        {
            return "H";
        }
    }
}
