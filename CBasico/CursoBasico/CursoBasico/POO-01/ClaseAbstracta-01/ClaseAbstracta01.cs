using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.ClaseAbstracta_01
{

    //1.- No se pueden crear instancias de una clase abstracta 
    /*
        Segun entiendo, no se puede hacer esto 
        ClaseAbstracta01 clase = new ClaseAbstracta01();
        clase.algo
    */
    //El proposito de una clase abstracta es proporcionar una difinicion comun de una clase base

    public abstract class ClaseAbstracta01
    {
        public abstract int Sumar(int x, int y);
        //{
        //Esto quiere decir que definir aqui la funcion, no esta permitido
        //    return x + y;
        //}

        //El metodo virtual si se puede implementar
        public virtual int Restar(int x, int y)
        {
            return x - y;
        }

        public void noAbstracto() { }
    }
}
