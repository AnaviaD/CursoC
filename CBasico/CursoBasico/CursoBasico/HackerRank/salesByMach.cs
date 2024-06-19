using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class salesByMach
    {
        public int sockMerchant(int n, List<int> ar)
        {
            List<int> pairsHold = new List<int>();
            int totalPairs = 0;

            foreach (int sock in ar)
            {
                if (pairsHold.Contains(sock))
                {
                    totalPairs++;
                    pairsHold.Remove(sock);
                }
                else
                {
                    pairsHold.Add(sock);
                }
            }

            return totalPairs;
        }
    }
}
