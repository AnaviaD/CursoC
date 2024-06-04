using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class divisibleSumPairs
    {
        public int divSum(int n, int k, List<int> ar)
        {
            int totalCount = 0;

            for (int i = 0; i < ar.Count; i++)
            {
                for (int j = 0; j < ar.Count; j++)
                {
                    if (((ar[i] + ar[j]) % k == 0) && i < j)
                        totalCount++;

                }
            }

            return totalCount;
        }
    }
}
