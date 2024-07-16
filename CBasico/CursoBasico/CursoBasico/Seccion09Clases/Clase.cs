
namespace CursoBasico.Seccion09Clases
{
    public class Clase
    {
        //Campo
        public int Campo;

        //Propiedad
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        private string _trabajo;

        public string Trabajo
        {
            get { return _trabajo; }
            set { _trabajo = value; }
        }

        //Las propiedades readonly se le puede asignar valor SOLO en el constructor
        public readonly string Identificador;

        public Clase()
        {
            Identificador = "ABCD";
            
        }
    }
}
