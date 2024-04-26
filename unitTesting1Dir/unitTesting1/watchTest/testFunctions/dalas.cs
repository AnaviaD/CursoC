using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testFunctions
{
    public class dalas
    {
        public void speak()
        {
            // Generar un número aleatorio del 1 al 3
            Random random = new Random();
            int randomNumber = random.Next(1, 4);

            // Seleccionar la función a ejecutar según el número aleatorio
            switch (randomNumber)
            {
                case 1:
                    meMetoConTuFisico();
                    break;
                case 2:
                    meMetoConTuIq();
                    break;
                case 3:
                    teDeseoAlgo();
                    break;
                default:
                    Console.WriteLine("Número aleatorio fuera de rango.");
                    break;
            }
        }

        // Definir las funciones externas
        public void meMetoConTuFisico()
        {
            List<string> strings = new List<string>
            {
                "Hola eres Hermos@",
                "Quieres un trio?",
                "escoria infrahumana",
                "PUTOS CERDOS",
                "안녕하세요"
            };

            // Generar un número aleatorio entre 0 y el número de elementos en la lista
            Random random = new Random();
            int randomNumber = random.Next(0, strings.Count);

            // Seleccionar el string aleatorio de la lista
            string selectedString = strings[randomNumber];

            // Imprimir el string seleccionado en la consola
            Console.WriteLine("me Meto con tu Fisico:   " + selectedString);
        }

        public void meMetoConTuIq()
        {
            List<string> strings = new List<string>
            {
                "Payasina",
                "Quien crea esto es que no tiene 2 dedos de frente",
                "gentuza",
                "gillipollas",
                "cuando haces examen Iq sale en negativo",
                "안녕하세요"
            };

            // Generar un número aleatorio entre 0 y el número de elementos en la lista
            Random random = new Random();
            int randomNumber = random.Next(0, strings.Count);

            // Seleccionar el string aleatorio de la lista
            string selectedString = strings[randomNumber];

            // Imprimir el string seleccionado en la consola
            Console.WriteLine("me Meto con tu Iq:   " + selectedString);
        }

        public void teDeseoAlgo()
        {
            List<string> strings = new List<string>
            {
                "te degoyo",
                "Dime donde vives",
                "payasina",
                "te quiero oler el pelo",
                "quieres hacer una locura?",
                "안녕하세요"
            };

            // Generar un número aleatorio entre 0 y el número de elementos en la lista
            Random random = new Random();
            int randomNumber = random.Next(0, strings.Count);

            // Seleccionar el string aleatorio de la lista
            string selectedString = strings[randomNumber];

            // Imprimir el string seleccionado en la consola
            Console.WriteLine("te deseo algo bonito:    " + selectedString);
        }

    }
}
