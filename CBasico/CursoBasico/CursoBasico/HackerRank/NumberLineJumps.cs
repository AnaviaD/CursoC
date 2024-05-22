using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class NumberLineJumps
    {

        public string kangaroo(int x1, int v1, int x2, int v2)
        {
            int jump_k1 = x1 + v1;
            int jump_k2 = x2 + v2;

            if (jump_k1 == jump_k2)
            {
                return "YES";
            }
            else
            {
                foreach (int i in Enumerable.Range(1, 10000))
                {
                    jump_k1 = jump_k1 + v1;
                    jump_k2 = jump_k2 + v2;

                    if (jump_k1 == jump_k2)
                    {
                        return "YES";
                    }
                }
            }

            return "NO";
        
        }
    }
}
