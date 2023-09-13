using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.Seccion13MemoryString
{
    class CursoMemString
    {
        public void Run()
        {
            MemoryStream ms = new MemoryStream(150);

            var capacidad = ms.Capacity;

            var longitud = ms.Length;

            var posicion = ms.Position;

            Console.WriteLine("Capacidad del memoriString:  (bites del string)\n");
            Console.WriteLine(capacidad + "\n");
            Console.WriteLine("Longitud memoriString:       (tamaño usado)\n");
            Console.WriteLine(longitud + "\n");
            Console.WriteLine("posicion del memoriString:   (lugar donde se encuentra el bite actual)\n");
            Console.WriteLine(posicion + "\n");

            //Seek el primero es la distancia desde el punto de referencia donde quedara la nueva posicion
            //Seek indica el punto de referencia que utilizaremos
            //SeekOrigin tiene 3 valores posibles, Begin, Current y End

            //ms.Seek(0, SeekOrigin.Begin);
            //ms.Seek(10, SeekOrigin.Begin);
            //ms.Seek(-10, SeekOrigin.Begin);

            //byte[] buffer = new byte[50];

            //ms.Read(buffer, 0, 5);
            //ms.Close();

            string miInformacion = string.Empty;
            byte[] buffer = new byte[50];

            //El usuario introduce datos
            Console.WriteLine("Introduce una cadena menor a 50 caracteres");
            miInformacion = Console.ReadLine();

            ms.Write(ASCIIEncoding.ASCII.GetBytes(miInformacion), 0, miInformacion.Length);
            ms.Seek(0, SeekOrigin.Begin);
            ms.Read(buffer, 0, buffer.Length);

            Console.WriteLine("Texto Original: \n");
            Console.WriteLine(ASCIIEncoding.ASCII.GetString(buffer));

            Console.WriteLine("Ahora me posicionare 5 caracteres y leer la cadena: \n");

            //Se posiciona en la opsicion 10
            ms.Seek(10, SeekOrigin.Begin);
            //Empieza a leer desde donde dejamos el seek, hasta la posicion que decidimos abajo 0, 5
            ms.Read(buffer, 0, 5);

            Console.WriteLine(ASCIIEncoding.ASCII.GetString(buffer));

            ms.Close();


        }
    }
}
