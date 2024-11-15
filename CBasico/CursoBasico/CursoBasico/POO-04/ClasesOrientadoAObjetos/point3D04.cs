using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_04.ClasesOrientadoAObjetos
{
    public class point3D04:point04
    {
        public int z { get; private set; }

        public void setZ(int value)
        {
            if (value < 30){
                z = value;
            }else{
                throw new ArgumentOutOfRangeException();
            }
        }

        public int getZ() 
        { 
            return z; 
        }
    }
}
