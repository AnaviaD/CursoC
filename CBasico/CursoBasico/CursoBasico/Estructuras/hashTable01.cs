using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.Estructuras
{
    internal class hashTable01
    {

        public void hashTableExample() 
        {
            Hashtable hashTabla = new Hashtable();

            //Agregamos elementos
            hashTabla.Add(01, "Hola");
            hashTabla.Add(02, "Saludos");
            hashTabla.Add(03, "Bendiciones");
            hashTabla.Add(04, "C#");
            hashTabla.Add(05, "Adios");

            foreach (DictionaryEntry D in hashTabla)
            {
                Console.WriteLine("({0}, {1})", D.Key, D.Value);
            }

            Console.WriteLine(hashTabla.Count);

        }
    }
}
