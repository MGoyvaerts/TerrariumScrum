using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    class Plant: Organisme
    {
        public Plant(int xPos, int yPos, int levenskracht, string letter)
            : base(xPos, yPos, levenskracht, letter)
        {
            Levenskracht = 1;
        }
    }
}