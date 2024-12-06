using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.Asincrona
{
    public class PrintMessageAsync
    {

        public async Task asyncCall()
        {
            await methodPrintAsync();
        }

        public async Task methodPrintAsync()
        {
            Console.Out.WriteLineAsync("Inicio");
            await Task.Delay(1000);
            Console.Out.WriteLineAsync("Printear Message \n");
        }
    }
}
