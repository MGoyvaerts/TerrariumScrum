using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public interface IOrganisme
    {
        public int Rij { get; set; }
        public int Kolom { get; set; }
        int[,] DoeActie();
        string ToString();
    }
}
