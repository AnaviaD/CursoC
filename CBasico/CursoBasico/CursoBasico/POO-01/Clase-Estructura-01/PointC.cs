using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Clase_Estructura
{

    /*
     * La diferencia entre una estructura y una clase 
     * La clase es por valor y las estructuras son por referencia
     * Las estructuras no guardan informacion memoria
     * Los cambios de la estructura se pierden al terminar de ejecutarse
     */

    public class PointC
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    //Program
    //{
    //    Point punto = new Point();
    //    punto.X = 10;
    //    punto.Y = 8;

    //    PointStruc puntoS = new PointStruc();
    //    puntoS.X = 10;
    //    puntoS.Y = 8;

    //    SumaClaseCoord(punto);
    //    SumaStructCoord(puntoS);

    //    Console.WriteLine($"Suma de coordenadas Clase X = {punto.X}:    Y = {punto.Y}");
    //    Console.WriteLine($"Suma de coordenadas Struct X = {puntoS.X}:    Y = {puntoS.Y}");
    //    Console.ReadKey();
    //}

    //public static void SumaClaseCoord(Point point)
    //{
    //    point.X = point.X + 10;
    //    point.Y = point.Y + 10;
    //}

    //public static void SumaStructCoord(PointStruc point)
    //{
    //    point.X = point.X + 10;
    //    point.Y = point.Y + 10;
    //}
}
