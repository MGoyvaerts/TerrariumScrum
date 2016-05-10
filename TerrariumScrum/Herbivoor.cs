using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Herbivoor: Organisme
    {
        public Herbivoor(int _xPositie, int _yPositie, string _letter)
        {
            this.xPositie = _xPositie;
            this.yPositie = _yPositie;
            this.Letter = _letter;
        }
        public bool Paren(int xPostitie, int yPositie) 
        {
            throw new NotImplementedException();
        }

    }
}
