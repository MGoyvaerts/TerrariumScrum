using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public abstract class Dier:Organisme
    {
        public Dier(int rij, int kolom)
            : base(rij, kolom)
        {

        }
        public Dier()
        {

        }
        public void Verplaatsen()
        {
            //de rij & kolom van het dier worden aangepast (en dat dier wordt dan terug gestuurd.)
            var random = new Random();
            int willGetal = random.Next(1, 4);
            switch (willGetal)
            {
                case 1:
                    this.Rij += 1;
                    this.Kolom += 1;
                    break;
                case 2:
                    this.Rij -= 1;
                    this.Kolom += 1;
                    break;
                case 3:
                    this.Rij += 1;
                    this.Kolom -= 1;
                    break;
                case 4:
                    this.Rij -= 1;
                    this.Kolom -= 1;
                    break;
            }
            //return this;
        }
        public Dier Eten(Dier dier, Organisme organisme)
        {
            //geeft het dier terug met de levenskracht van het organisme dat ie gaat opeten.
            dier.Levenskracht += organisme.Levenskracht;
            return dier;
        }
    }
}
