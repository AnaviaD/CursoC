using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.ClaseAbstracta_Interfaz
{
    public abstract class Vehiculos
    {
        public abstract int ruedas { get; }
        public void Mover()
        {
            Console.WriteLine("Moviendo {0} ruedas", ruedas);
        }

        /*
         *  Siendo una clase tambien podemos heredar la implementacion Metodos 
         *  Una interface no puede heredar la implementacion de los metodos
         *  
            Coche       c = new Coche();
            Bicicleta   b = new Bicicleta();

            List<Vehiculos> v = new List<Vehiculos>();

            v.Add(b);
            v.Add(c);

            foreach (Vehiculos veh in v) 
            {
                veh.Mover();
            }

         */
    }
}
