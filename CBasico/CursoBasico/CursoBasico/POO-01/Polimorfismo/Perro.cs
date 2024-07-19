using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Polimorfismo
{
    internal class Perro : Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("El perro hace guau");
        }
    }
}
