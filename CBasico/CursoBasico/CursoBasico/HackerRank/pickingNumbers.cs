using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class pickingNumbers
    {
        public int pickingNumbersFunc(List<int> a)
        {
            List<int> subArrayA, banList = new List<int>();
            Hashtable repeatT = new Hashtable();
            int maxA = 0, maxB = 0;

            foreach (int numb in a)
            {
                if (!banList.Contains(numb))
                {
                    int countF = 0;
                    for (int i = 0; i < a.Count; i++)
                    {
                        if (a[i] == numb)
                        {
                            countF++;

                            if (!banList.Contains(a[i]))
                                banList.Add(a[i]);

                        }
                    }
                    repeatT.Add(numb, countF);

                }
            }



            return 4;

        }
    }
}
