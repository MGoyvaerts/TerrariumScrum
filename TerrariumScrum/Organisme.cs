using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    abstract class Organisme
    {
        public int Levenskracht { get; set; }
        public int xPositie { get; set; }
        public int yPositie { get; set; }
        public string Letter { get; set; }
    }
}
