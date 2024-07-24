using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Delegado
{

    public delegate void Del(string mensaje);

    internal class Delegados
    {

        public void startUpProgram()
        {
            //Instanciamos el delegado
            Del handler = DelegateMethod;

            //Llamamos al delegado
            handler("Hola mundo ");

            


        }


        public void DelegateMethod(string mensaje)
        {

        }
    }
}
