using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Clase_Estructura
{
    internal class Clase
    {
        //Cuerpo de clase
        //Constantes
        //Metodos
        //Propiedades
        //Eventos
        //Indizadores
        //Operadores
        //Constructores
        //Destructores
        //Tipos

        /*  Constantes*/
        const int iva = 7;

        public int Importe { get; private set; }

        public int CalcularImporte(int importe)
        {
            return importe + (importe * iva);
        }

        /*  Campos o propiedades    */
        //Campo
        public int campo;

        //Propiedad 
        private string _propiedad;
        public string Propiedad
        {
            //Aqui esta el {    get;    set;    }
            get { return _propiedad; }
            set
            {
                //Podemos controlar cuando se le asigna un valor y no depender de un simple =
                // Lógica adicional, por ejemplo, validación
                if (!string.IsNullOrEmpty(value))
                {
                    _propiedad = value;
                }
                else
                {
                    throw new ArgumentException("El valor no puede ser nulo o vacío.");
                }
            }
        }

        /*
            Resumen de Diferencias
            Encapsulación:          Las propiedades permiten una mejor encapsulación que los campos.
            Control de Acceso:      Las propiedades permiten controlar el acceso a los datos mediante la lógica en los métodos get y set.
            Flexibilidad:           Las propiedades pueden implementar lógica adicional que los campos no pueden.
        */

    }
}
