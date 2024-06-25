using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class electronicsShop
    {
        public int getMoneySpent(int[] keyboards, int[] drives, int b)
        {

            List<int> posibleAns = new List<int>();

            foreach (int keyB in keyboards)
            {
                foreach (int driv in drives)
                {
                    if ((keyB + driv) == b)
                    { return keyB + driv; }
                    if ((keyB + driv) <= b)
                    {
                        posibleAns.Add(keyB + driv);
                    }
                }
            }

            if (posibleAns.Any())
            {
                return posibleAns.Max();
            }
            else
            {
                return -1;
            }
        }
    }
}
