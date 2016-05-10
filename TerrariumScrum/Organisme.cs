using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    abstract class Organisme : IOrganisme
    {
        public int Levenskracht { get; set; }

        public Organisme(int rij, int kolom, int levenskracht = 0)
        {
            Rij = rij;
            Kolom = kolom;
        }

        public int Rij {get; set;}

        public int Kolom { get; set; }

        public int[,] DoeActie()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
 	         return "P";
        }
    }
}

