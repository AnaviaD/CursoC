using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.BigO
{
    public class On
    {

        public void OnExcercice1()
        {
            String[] nemo = new String[] {"nemo"};
            String[] large = new String[] {"dory", "bruce", "marlin",
            "nemo", "gill", "bloat", "niggel", "squirt", "darla", "hank"};


            foreach(string c in nemo)
            {
                Console.WriteLine(c);
            }

        }
    }
}
