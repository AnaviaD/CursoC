using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.ClaseAbstracta_01
{

    //Tenemos que heredar de la clase abstracta
    public abstract class Clase : ClaseAbstracta01
    {
        public override int Sumar(int x, int y)
        {
            return x + y;
        }

        public abstract override int Restar(int x, int y);
    }
}
