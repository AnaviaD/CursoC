using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excelFiles.Clases
{
    public class analizadores
    {
        public string ErrorMessageTxt = "";
        public static List<string> escribirEnLog = new List<string>();

        public int ContarCaracteres(string texto)
        {
            return texto.Length;
        }

        public int TipoDeCadena(string texto)
        {
            bool contieneLetras = false;
            bool contieneNumeros = false;

            foreach (char caracter in texto)
            {
                if (char.IsLetter(caracter))
                {
                    contieneLetras = true;
                }
                else if (char.IsDigit(caracter))
                {
                    contieneNumeros = true;
                }

                // Si ya encontramos ambos tipos de caracteres, podemos salir del bucle
                if (contieneLetras && contieneNumeros)
                {
                    break;
                }
            }

            if (contieneLetras && contieneNumeros)
            {
                return 2; // Contiene letras y números
            }
            else if (contieneLetras)
            {
                return 1; // Solo contiene letras
            }
            else
            {
                return 0; // Solo contiene números
            }
        }

        public int ContarDigitos(string texto)
        {
            int contador = 0;

            foreach (char caracter in texto)
            {
                if (char.IsDigit(caracter))
                {
                    contador++;
                }
            }

            return contador;
        }

        public int ContarCaracteresExcluyendoNumeros(string texto)
        {
            int contador = 0;
            foreach (char caracter in texto)
            {
                if (!char.IsDigit(caracter)) // Verifica si el caracter no es un dígito numérico
                {
                    contador++;
                }
            }
            return contador;
        }

        public int ContarLetrasMinusculas(string texto)
        {
            int contador = 0;
            foreach (char caracter in texto)
            {
                if (char.IsLower(caracter)) // Verifica si el carácter es una letra mayúscula
                {
                    contador++;
                }
            }
            return contador;
        }

        public int ContarLetrasMayusculas(string texto)
        {
            int contador = 0;
            foreach (char caracter in texto)
            {
                if (char.IsUpper(caracter)) // Verifica si el carácter es una letra mayúscula
                {
                    contador++;
                }
            }
            return contador;
        }

        public int ContarEspacios(string texto)
        {
            int contador = 0;
            foreach (char caracter in texto)
            {
                if (caracter == ' ') // Verifica si el carácter es un espacio en blanco
                {
                    contador++;
                }
            }
            return contador;
        }

        public int ContarPuntos(string texto)
        {
            int contador = 0;

            foreach (char caracter in texto)
            {
                if (caracter == '.')
                {
                    contador++;
                }
            }

            return contador;
        }

    }
}
