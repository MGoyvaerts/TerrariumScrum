using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public abstract class Organisme
    {
        public int Levenskracht { get; set; }
        public int xPositie { get; set; }
        public int yPositie { get; set; }
        public string Letter { get; set; }

        public Organisme(int levenskracht, int xPos, int yPos, string letter)
        {
            Levenskracht = levenskracht;
            xPositie = xPos;
            yPositie = yPos;
            Letter = letter;
        }
    }
}
