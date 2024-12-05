using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_04.MetodosDelegados
{
    internal class metodosDelegados
    {


        //public class Program
        //{
        //    //Declaramos el metodo delegado
        //    public delegate void Del(string message);

        //    private static void Main(string[] args)
        //    {
        //        //Instantiate the delegate
        //        Del handler = DelegateMethod;

        //        //Call the delegate
        //        handler("Hello World");

        //        //Delegado con callback
        //        MethodWithCallback(1, 2, handler);

        //        //Instanciamos el objeto que contiene los metodos para delegar
        //        MethodClass obj = new MethodClass();
        //        Del d1 = obj.Method1;
        //        Del d2 = obj.Method2;
        //        Del d3 = DelegateMethod;

        //        //Aqui asignamos el orden de los metodos delegados
        //        Del allMethodsDelegate = d1 + d2;
        //        allMethodsDelegate += d3;

        //        allMethodsDelegate("Llamando en orden");

        //    }

        //    public static void DelegateMethod(string message)
        //    {
        //        Console.WriteLine(message);
        //    }

        //    public static void MethodWithCallback(int param1, int param2, Del callback)
        //    {
        //        callback("The number is: " + (param1 + param2).ToString());
        //    }

        //    public class MethodClass
        //    {
        //        public void Method1(string message)
        //        {
        //            Console.WriteLine(message);
        //        }

        //        public void Method2(string message)
        //        {
        //            Console.WriteLine(message);
        //        }
        //    }
        //}
    }
}
