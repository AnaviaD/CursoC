using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.ClaseAbstracta_Interfaz
{
    internal interface IRun
    {
        int Legs { get; set; }

        void Run();
    }
}
