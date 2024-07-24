using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_02.ClaseAbstracta
{
    public abstract class ClaseAbstracta
    {
        public abstract int Sumar(int i, int j);

        //Metodo virtual
        public virtual int Restar(int i, int j)
        {
            return i - j;
        }
    }
}
