using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.Asincrona
{
    public class AsyncWithErrorClass1
    {
        public async Task<string> callMethodTry()
        {

            Console.Out.WriteLineAsync("Iniciando el proceso");

            await Task.Delay(3000);

            throw new Exception("Encontramos un error 156846 ");

            return "finalizado";

        }
    }
}
