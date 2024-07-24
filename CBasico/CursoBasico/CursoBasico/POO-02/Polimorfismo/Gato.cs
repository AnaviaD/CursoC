using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_02.Polimorfismo
{
    public class Gato : Animal
    {
        public override void HacerRuido()
        {
            Console.WriteLine("El gato hace miauuuu");
        }
    }
}
