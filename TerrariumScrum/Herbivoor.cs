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
        public Herbivoor Vrijen()
        {
            Herbivoor nieuweHerbivoor = new Herbivoor();
            return nieuweHerbivoor;
        }
        public override string Tostring()
        {
            return "H";
        }
    }
}
