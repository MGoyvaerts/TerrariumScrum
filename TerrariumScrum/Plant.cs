using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Plant: Organisme
    {
        Random rnd = new Random();
        private int levenskrachtValue;
        public override int Levenskracht { get; set; }
        public Plant(int rij, int kolom, int levenskracht)
            : base(rij, kolom, levenskracht) { }
        public Plant(){}
        public override string Tostring()
        {
            return "P";
        }
    }
}