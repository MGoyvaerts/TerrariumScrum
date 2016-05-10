using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public abstract class Dier:Organisme
    {
        
        public Dier(int levenskracht, int xPos, int yPos, string letter)
            : base(levenskracht, xPos, yPos, letter)
        {

        }
        public void Verplaatsen()
        {

        }
        public void Eten()
        {

        }
    }
}
