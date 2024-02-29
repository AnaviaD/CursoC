using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.Seccion09Clases
{
    internal class Clase
    {
        public int Campo;
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //Las propiedades readonly se le puede asignar valor SOLO en el constructor
        public readonly string Identificador;

        public Clase()
        {
            Identificador = "ABCD";
            
        }
    }
}
