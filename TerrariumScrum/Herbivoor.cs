using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Herbivoor : Dier
    {
        public Herbivoor(int rij, int kolom)
            : base(rij, kolom)
        {

        }
        public Herbivoor()
        {

        }
        public Herbivoor Vrijen(List<IOrganisme>organismeLijst)
        {                      
            List<IOrganisme> herbivoren = new List<IOrganisme>();
            List<IOrganisme> leegOrganisme = new List<IOrganisme>();
            List<IOrganisme> nieuweOrganismeLijst = new List<IOrganisme>();
            Herbivoor nieuweHerbivoor = new Herbivoor();
            Random random = new Random();
            for (int i = 0; i < organismeLijst.Count(); i++)
            {
                if (organismeLijst[i].GetType() == typeof(Herbivoor))
                {
                    herbivoren.Add(organismeLijst[i]);
                }
                if (organismeLijst[i].GetType() == typeof(GeenOrganisme))
                {
                    leegOrganisme.Add(organismeLijst[i]);
                }
            }
            int aantal = leegOrganisme.Count();
            int index = random.Next(0, aantal);
            for (int i = 0; i < herbivoren.Count() - 1; i++)
            {
                if (herbivoren[i].Rij == herbivoren[i + 1].Rij && herbivoren[i].Kolom == (herbivoren[i + 1].Kolom - 1))
                {
                    nieuweHerbivoor.Rij = leegOrganisme[index].Rij;
                    nieuweHerbivoor.Kolom = leegOrganisme[index].Kolom;
                    nieuweHerbivoor.Levenskracht = 0;                   
                }
            }
            //for (int i = 0; i < organismeLijst.Count(); i++)
            //{
            //    if (organismeLijst[i].Rij == leegOrganisme[index].Rij && organismeLijst[i].Kolom == leegOrganisme[index].Kolom)
            //    {
            //        organismeLijst[i] = nieuweHerbivoor;
            //    }
            //}
            return nieuweHerbivoor;
        }
        public override string Tostring()
        {
            return "H";
        }
    }
}
