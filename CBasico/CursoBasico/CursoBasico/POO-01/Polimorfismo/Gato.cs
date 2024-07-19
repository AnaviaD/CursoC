using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Polimorfismo
{
    internal class Gato : Animal
    {
        public int heigt { get; set; }
        public override void HacerRuido()
        {
            Console.WriteLine("El gato hace miau");
        }
    }
}
