// See https://aka.ms/new-console-template for more information
using CursoBasico.Seccion09Clases;
using CursoBasico.Seccion13MemoryString;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Memory String \n");
        //CursoMemString Curso = new CursoMemString();
        //Curso.Run();


        Console.WriteLine("Clases \n");
        Clase clase = new Clase();
        clase.Campo = 5;
        clase.Nombre = "Juanito";
        clase.Apellido = "El chiwa";
        clase.Trabajo = "chaqueto";

        Console.WriteLine("Memory String {0}    -   {1} -   {2}\n", clase.Campo, clase.Nombre, clase.Apellido);
    }
}