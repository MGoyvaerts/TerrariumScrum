using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Carnivoor : Dier
    {
        public Carnivoor() { }
        public Carnivoor(int rij, int kolom)
            : base(rij, kolom)
        {

        }
        public Carnivoor Vechten(Carnivoor carnivoorLinks, Carnivoor carnivoorRechts)
        {
            //controleert welke de sterkste is 
            //telt de levenskracht van de zwakke bij de sterkste op
            //return is de sterkste carnivoor met nieuwe levenskracht
            if (carnivoorLinks.Levenskracht < carnivoorRechts.Levenskracht)
            {
                carnivoorRechts.Levenskracht += carnivoorLinks.Levenskracht;
                return carnivoorRechts;
            }
            if (carnivoorLinks.Levenskracht > carnivoorRechts.Levenskracht)
            {
                carnivoorLinks.Levenskracht += carnivoorRechts.Levenskracht;
                return carnivoorLinks;
            }
            else
            {
                return null;
            }

        }
    }
}