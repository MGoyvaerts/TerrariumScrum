using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Dier:Organisme
    {
        public Dier(int rij, int kolom)
            : base(rij, kolom)
        {

        }
        public Dier()
        {

        }
        
        public bool IsVerplaatst = false;
        public void Verplaatsen(List<IOrganisme> organismelijst)
        {
            //de rij & kolom van het dier worden aangepast (en dat dier wordt dan terug gestuurd.)
            Random random = new Random();
            
            int willGetal = 0 ;
            willGetal = random.Next(1, 5);
            switch (willGetal)
            {
                case 1:
                    if (this.Rij < 5)
                    {
                                  this.Rij += 1;
                    }
                    
                    break;
                case 2:
                    if (this.Rij > 0)
                    {
                        this.Rij -= 1;
                    }
                    
                    break;
                case 3:
                    if (this.Kolom < 5)
                    {
                        this.Kolom += 1;
                    }
                    
                   
                    break;
                case 4:
                    if (this.Kolom > 0)
                    {
                        this.Kolom -= 1;
                    }
                    
                    break;                 
            }           
            this.IsVerplaatst = true;
            //Console.WriteLine(willGetal);
            //return this;
        }
        public IOrganisme[,] Eten(Organisme organisme, IOrganisme[,] raster)      //Het dier moet het organisme dat die gaat opeten binnenkrijgen als parameter. 
        {
            this.Levenskracht += organisme.Levenskracht;    //Het dier krijgt de levenskracht van het organisme dat die gaat opeten.
            raster[organisme.Rij, organisme.Kolom] = new GeenOrganisme(organisme.Rij, organisme.Kolom);     //Het opgegeten organisme wordt vervangen door een GeenOrganisme.
            return raster;
        }
    }
}
