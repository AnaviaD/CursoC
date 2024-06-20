using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class drowBook
    {
        public int pageCount(int n, int p)
        {
            int pCount = 0, initCount = 0, endCount = 0;

            for (int i = 0; i <= n; i++)
            {
                if ((i > 1) && (i % 2 == 0))
                { pCount++; }

                if ((i > p) && (i % 2 == 0) && (p != n))
                { endCount++; }

                if (i == p)
                { initCount = pCount; }
            }

            if (initCount > endCount)
            { return endCount; }
            else
            {
                return initCount;
            }

            return initCount;
        }
    }
}
