// See https://aka.ms/new-console-template for more information
using CursoBasico.BigO;
using CursoBasico.POO_01.Clase_Estructura;
using CursoBasico.POO_01.ClaseAbstracta_Interfaz;
using CursoBasico.POO_02.Encapsulacion;
using CursoBasico.POO_02.Polimorfismo;
using CursoBasico.POO_03.BasicShit;
using CursoBasico.POO_04.ClasesII;
using CursoBasico.POO_04.ClasesOrientadoAObjetos;

internal class Program
{
    private static void Main(string[] args)
    {
        Point04 punto = new Point04();
        punto.X = 10;
        punto.Y = 10;

        PointStruc04 pointStruc04 = new PointStruc04();
        pointStruc04.X = 5;
        pointStruc04.Y = 5;

        SumaCoordenadas(punto);
        SumarCoordenadas(pointStruc04);

        Console.WriteLine($"Suma de coordenadas clase : x={punto.X}  y={punto.Y} ");
        Console.WriteLine($"Suma de coordenadas struct : x={pointStruc04.X}  y={pointStruc04.Y} ");
        Console.ReadKey();

    }

    public static void SumaCoordenadas(Point04 punto)
    {
        punto.X += 10;
        punto.Y += 10;
    }
    public static void SumarCoordenadas(PointStruc04 punto)
    {
        punto.X += 15;
        punto.Y += 15;
    }


}