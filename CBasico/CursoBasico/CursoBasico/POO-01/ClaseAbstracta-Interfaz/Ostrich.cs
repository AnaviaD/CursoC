using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.ClaseAbstracta_Interfaz
{
    //Ostrich = Avestruz
    internal class Ostrich : Bird, IRun
    {
        public Ostrich(int wing):base(wing)
        {
        }

        public int Legs { get; set; }

        public void Run()
        {
            Console.WriteLine("Corre Pajarillo");
        }
    }
}
