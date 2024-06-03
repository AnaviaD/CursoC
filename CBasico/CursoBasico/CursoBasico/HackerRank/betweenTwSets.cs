using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class betweenTwSets
    {
        public int getTotalX(List<int> a, List<int> b)
        {
            var l_start = a.Min();
            var l_end = b.Max();
            var totalSum = 0;

            for (int i = l_start; i <= l_end; i++)
            {
                if (a.isFactor(i) && b.isMultiple(i))
                {
                    totalSum += 1;
                }
            }

            return totalSum;
        }

    }

    public static class ListExtensions
    {
        public static bool isFactor(this List<int> values, int currentN)
        {
            return values.All(v => currentN % v == 0);
        }

        public static bool isMultiple(this List<int> values, int currentN)
        {
            return values.All(v => v % currentN == 0);
        }
    }
}
