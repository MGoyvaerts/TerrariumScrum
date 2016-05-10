using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Carnivoor : Dier
    {

        public Carnivoor(int levenskracht, int xPos, int yPos, string letter)
            : base(levenskracht, xPos, yPos, letter)
        {

        }
        public Carnivoor Vechten(Carnivoor carnivoor1, Carnivoor carnivoor2)
        {
            //Method Vechten geeft een object carnivoor terug


            if (carnivoor1.Levenskracht < carnivoor2.Levenskracht)//Als carnivoor 1 minder levenskracht heet wordt carnivoor 2 teruggegeven
            {
                carnivoor2.Levenskracht += carnivoor1.Levenskracht;
                return carnivoor2;
            }
            else if (carnivoor1.Levenskracht > carnivoor2.Levenskracht)//Als carnivoor 2 minder levenskracht heet wordt carnivoor 1 teruggegeven
            {
                carnivoor1.Levenskracht += carnivoor2.Levenskracht;
                return carnivoor1;
            }
            else { return null; }// bij een gelijke levenskracht geeft de method Vechten null terug
        }
    }
}