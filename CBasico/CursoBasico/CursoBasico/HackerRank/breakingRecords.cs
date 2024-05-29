using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class breakingRecords
    {
        public List<int> breakingRecordsF(List<int> scores)
        {
            int lowestR = scores[0], higstR = scores[0], lowestC = 0, higstC = 0;
            List<int> outpL = new List<int>();
            foreach (int score in scores)
            {
                if (score < lowestR)
                {
                    lowestR = score;
                    lowestC += 1;
                }
                if (score > higstR)
                {
                    higstR = score;
                    higstC += 1;
                }
            }

            outpL.Add(higstC);
            outpL.Add(lowestC);

            return outpL;
        }
    }
}
