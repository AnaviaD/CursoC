

namespace CursoBasico.POO_02.Herencia
{
    public class Point3D : Point2D
    {
        public int _z { get; private set; }
        
        public void setZ(int z)
        {
            if (z < 100)
                _z = z;
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}
