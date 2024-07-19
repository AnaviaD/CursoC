using CursoBasico.POO_01.Polimorfismo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.MetodosExtencion
{
    public static class MyExtencions
    {
        //Para hacer un metodo de extencion
        //necesitamos utilizar 'this'
        public static int wordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' }
                , StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int animalCount(this Animal animales)
        {
            return 2;

            //Aqui la implementacion que solo esta disponible para los objetos tipo animal
            //Gato cat = new Gato();
            //cat.animalCount();
        }


        //Aqui podemos mostrar la implementacion de el extencions methods 

        //string s = "Hola como estas Extencion methods";
        //int i = s.wordCount();


    }
}
