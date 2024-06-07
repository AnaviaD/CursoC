using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class billDiv
    {
        public int bonAppetit(List<int> bill, int k, int b)
        {
            int totalSum = 0, realCount = 0;
            int divSum = 0;

            for (int i = 0; i < bill.Count; i++)
            {
                realCount = realCount + bill[i];

                if (i != k)
                {
                    totalSum = totalSum + bill[i];
                }
            }

            divSum = totalSum / 2;
            realCount /= 2;

            if (divSum == b)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
            {
                return realCount - divSum;
            }

            return realCount;

        }
    }
}
