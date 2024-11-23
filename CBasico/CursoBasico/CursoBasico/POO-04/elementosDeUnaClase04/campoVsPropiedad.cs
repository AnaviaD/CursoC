using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_04.elementosDeUnaClase04
{
    public class campoVsPropiedad
    {

        // Campo
        public string campo;

        // Propiedad
        private string _propiedad;
        public string Propiedad
        {
            get { return _propiedad; }
            set
            {
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

        public campoVsPropiedad()
        {
            campo = "Valor inicial del campo";
            Propiedad = "Valor inicial de la propiedad";
        }
    }
}
