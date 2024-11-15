using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_04.ClasesOrientadoAObjetos
{
    public class point04
    {
        //private int x;
        //private int y;

        public int x { get; private set; }
        public int y { get; private set; }

        public void SetX(int value)
        {
            if (value < 100){
                this.x = value;
            }else{
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SetY(int value)
        {
            if (value < 100)
            {
                this.y = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int GetX()
        {
            return x;
        }

        public int GetY() 
        {
            return y;
        }
    }
}
