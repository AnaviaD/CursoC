using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.ClaseAbstracta_Interfaz
{
    public class Bicicleta : Vehiculos
    {
        private int _ruedas = 2;

        public override int ruedas 
        {
            get { return _ruedas; }
        }
    }
}
