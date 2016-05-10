using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Herbivoor : Dier
    {
        public Herbivoor(int levenskracht, int xPos, int yPos, string letter)
            : base(levenskracht, xPos, yPos, letter)
        {

        }
        public Herbivoor()
        {

        }
        //public int Paren(string[,]raster)
        //{
        //    int aantal = 0;
        //    for (int i = 0; i < 6; i++)
        //    {
        //        for (int j = 0; j < 6; j++)
        //        {
        //            if (raster[i, j] == "H" && j < 5)
        //            {
        //                if (raster[i, j + 1] == "H")
        //                {
        //                    aantal++;
        //                }
        //            }
        //        }
        //    }
        //    return aantal;
        //}
        public Herbivoor Paren(string[,] raster)
        {
            Herbivoor nieuweHerbivoor = new Herbivoor();
            return nieuweHerbivoor;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (raster[i, j] == "H" && i < 5 && raster[i + 1, j] == "H")
                    {
                        nieuweHerbivoor = new Herbivoor();
                    }
                }
            }
        }

    }
}
