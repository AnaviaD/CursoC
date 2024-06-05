using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.HackerRank
{
    public class migratoryBrds
    {
        public int migratoryBirds(List<int> arr)
        {
            int higerValue = 0, keyValue = 0;
            Hashtable ht = new Hashtable();

            foreach (int number in arr)
            {
                if (ht.ContainsKey(number))
                {
                    int value = (int)ht[number];

                    value += 1;

                    ht[number] = value;
                }
                else
                {
                    ht.Add(number, 1);
                }
            }

            foreach (DictionaryEntry higVal in ht)
            {
                if ((int)higVal.Value > higerValue)
                {
                    higerValue = (int)higVal.Value;
                    keyValue = (int)higVal.Key;
                }
                else if ((int)higVal.Value == higerValue)
                {
                    if ((int)higVal.Key < keyValue)
                    {
                        keyValue = (int)higVal.Key;
                    }
                }
            }

            return keyValue;
        }
    }
}
