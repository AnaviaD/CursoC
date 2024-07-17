// See https://aka.ms/new-console-template for more information
using CursoBasico.BigO;
using CursoBasico.POO_01.Clase_Estructura;
using CursoBasico.Seccion09Clases;
using CursoBasico.Seccion13MemoryString;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Point punto = new Point();
        punto.X = 10;
        punto.Y = 8;

        PointStruc puntoS = new PointStruc();
        puntoS.X = 10;
        puntoS.Y = 8;

        SumaClaseCoord(punto);
        SumaStructCoord(puntoS);

        Console.WriteLine($"Suma de coordenadas Clase X = {punto.X}:    Y = {punto.Y}");
        Console.WriteLine($"Suma de coordenadas Struct X = {puntoS.X}:    Y = {puntoS.Y}");
        Console.ReadKey();
    }

    public static void SumaClaseCoord(Point point)
    {
        point.X = point.X + 10;
        point.Y = point.Y + 10;
    }

    public static void SumaStructCoord(PointStruc point)
    {
        point.X = point.X + 10;
        point.Y = point.Y + 10;
    }
}