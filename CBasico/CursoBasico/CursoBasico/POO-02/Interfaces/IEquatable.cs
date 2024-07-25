using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_02.Interfaces
{
    interface IEquatable<T>
    {
        bool Equals(Task obj);

        int EsIgual(int numero);
    }
}
