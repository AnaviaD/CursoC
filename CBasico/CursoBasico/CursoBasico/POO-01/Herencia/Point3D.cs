using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Herencia
{
    internal class Point3D : Point2D, IexamplInterface
    {
        public int Z { get; set; }


        //Podemos heredar de una sola clase, y una interface
        //Aqui implementamos la propiedad de la interface
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //Esto permite utilizar las variables y propiedades de la clase base
        //Podemos hacer uso de los datos publicos y protegidos

        //Point3D poit = new Point3D();
        //poit.X = 10;
    }
}
