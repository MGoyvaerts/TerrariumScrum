using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public interface IOrganisme
    {
        int Rij { get; set; }
        int Kolom { get; set; }

        //int[,] DoeActie();
        string Tostring();
    }
}
