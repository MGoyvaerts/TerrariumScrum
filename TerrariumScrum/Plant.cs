using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Plant: Organisme
    {
        public Plant(int rij, int kolom, int levenskracht)
            : base(rij, kolom, levenskracht) 
        {
            
        }
        public Plant()
        {
            
        }
        public override int Levenskracht
        {
            get;
            set;
        }
        public override string Tostring()
        {
            return "P";
        }
    }
}