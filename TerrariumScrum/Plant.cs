using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    class Plant: Organisme
    {
        public Plant(int rij, int kolom)
            : base(rij, kolom) { }
        public override string Tostring()
        {
            return "P";
        }
    }
}