using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Interface
{
    internal interface IEquatable<T>
    {
        bool    Equals(T obj);
        int     EsIgual(int numero);
    }

    public interface IComparation01
    {
        int EsIgualCoche(int numero);
    }
}
