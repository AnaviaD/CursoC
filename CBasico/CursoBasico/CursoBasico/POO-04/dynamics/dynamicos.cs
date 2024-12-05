using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_04.dynamics
{
    public class dynamicos
    {
        //Declaramos constructores y metodos que no coinciden
        public dynamicos() { }

        public dynamicos(int i) { }

        public void metodo01(string s) { }
        public void metodo02(int ip) { }

        /*
        dynamicos d = new dynamicos();
        //Podemos observar que nos da error porque el metodo declarado no recibe 2 int
        //d.metodo01(1, 2);

        //al ser dynamic le podemos mandar cualquier burrada que no nos va a marcar error
        //esto se utiliza para cuando esperamos una llamada para la cual no estamos preparados
        dynamic dyna = new dynamicos();
        dyna.metodo01(1, 2);
        */

    }
}
