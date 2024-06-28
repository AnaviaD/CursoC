using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class catsAndMouseCCC
    {
        public string catAndMouse(int x, int y, int z)
        {

            int absX = Math.Abs(x - z);
            int absY = Math.Abs(y - z);

            if (absX > absY)
            {
                return "Cat B";
            }
            if (absY > absX)
            {
                return "Cat A";
            }
            if (absY == absX)
            {
                return "Mouse C";
            }

            return "Mouse C";
        }
    }
}
