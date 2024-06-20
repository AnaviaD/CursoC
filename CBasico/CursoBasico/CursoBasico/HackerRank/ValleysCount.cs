using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class ValleysCount
    {

        public int countingValleys(int steps, string path)
        {
            int stepUp = 100, totalH = 0;
            bool accesP = false;

            foreach (char stp in path)
            {
                if (stp == 'D')
                {
                    stepUp--;
                }
                else
                {
                    stepUp++;
                }
                if (stepUp < 100)
                {
                    accesP = true;
                }
                if ((accesP == true) && (stepUp == 100))
                {
                    accesP = false;
                    totalH++;
                }

            }

            return totalH;
        }
    }
}
