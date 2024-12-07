using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.Asincrona
{
    public class SecondExcerAsync
    {

        public async Task<string> PrintFirstText()
        {
            Console.Out.WriteLineAsync("Inicializamos primera funcion");

            await Task.Delay(2000);

            Console.Out.WriteLineAsync("Terminamos primer proceso pero esperamos");

            return "Finaliza primer metodo";
        }


        public async Task<string> PrintSecondText()
        {
            Console.Out.WriteLineAsync("Inicia el segundo funcion");

            await Task.Delay(2000);

            Console.Out.WriteLineAsync("Terminamos segundo proceso pero esperamos");

            return "Terminamos el segundo metodo";
        }
    }
}
