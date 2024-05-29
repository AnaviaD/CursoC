using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class chocoBar
    {
        public int birthday(List<int> s, int d, int m)
        {
            var numberOfWays = 0;
            for (int i = 0; i < s.Count; i++)
            {
                var sum = 0;
                for (int j = i; j < m + i; j++)
                    if (j < s.Count)
                        sum += s[j];

                if (sum == d)
                    numberOfWays++;
            }
            return numberOfWays;
        }
    }
}
