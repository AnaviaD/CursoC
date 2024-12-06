using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_04.Enumerados
{

    //Sirven para no harcodear valores
   enum ColorE
    {
        Rojo,
        Verde,
        Azul
    }

    enum Aligment : sbyte
    {
        Left = -1,
        Center = 0,
        Right = 1,
    }


    /*
    static void PrintColor(ColorE color)
    {
        switch (color) 
        {
            case ColorE.Rojo:
                Console.WriteLine("Rojo");
                break;
            case ColorE.Verde:
                Console.WriteLine("Verde");
                break;
            case ColorE.Azul:
                Console.WriteLine("Azul");
                break;
            default:
                Console.WriteLine("def");
                break;
        }
    }

      private static void Main(string[] args)
    {
        //Podemos obtener objeto y propiedad
        ColorE c = ColorE.Rojo;
        PrintColor(c);
        PrintColor(ColorE.Azul);
        PrintColor(ColorE.Verde);

        //Nos deberia regresar el index del emnum
        int i = (int)ColorE.Azul;
        Console.WriteLine(i);
        //Tambien nos deberia regresar el index enum
        ColorE c2 = (ColorE)2;
        Console.WriteLine(c2);

        var alineacion = Aligment.Left;
        Console.WriteLine(alineacion);


    }

     */
}
