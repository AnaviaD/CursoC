using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_02.Encapsulacion
{
    public class PointEncapsulado
    {
        public int _x { get; private set; }
        public int _y { get; private set; }  

        public void setX(int x)
        {
            if (x < 100)
                _x = x;
            else
                throw new ArgumentOutOfRangeException();
        }

        public void setY(int y)
        {
            if (y < 100)
                _y = y;
            else
                throw new ArgumentOutOfRangeException();
        }


    }
}
