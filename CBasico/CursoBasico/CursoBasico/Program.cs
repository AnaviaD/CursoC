// See https://aka.ms/new-console-template for more information
using CursoBasico.Seccion13MemoryString;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Memory String \n");
        CursoMemString Curso = new CursoMemString();
        Curso.Run();
    }
}