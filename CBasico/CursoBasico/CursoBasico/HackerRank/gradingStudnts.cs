using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class gradingStudnts
    {
        public List<int> gradingStudents(List<int> grades)
        {
            List<int> endList = new List<int>();

            foreach (int grade in grades)
            {
                endList.Add(gradeProcess(grade));
            }

            return endList;
        }

        public int gradeProcess(int target)
        {
            if (target % 5 == 0 || target < 38)
            {
                return target;
            }
            else
            {
                for (int ft = target + 1; ft <= target + 10; ft++)
                {
                    //Revisamos si es que se puede redondear
                    if (((ft - target) < 3) && (ft % 5 == 0))
                    {
                        return ft;
                    }
                    if ((target + 2) == ft)
                    {
                        return target;
                    }
                }
            }

            return target;
        }
    }
}
