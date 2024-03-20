using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace excelFiles.Clases
{
    public class limpiezaDeDatos
    {

        public string ErrorMessageTxt = "";
        public static List<string> escribirEnLog = new List<string>();



        public bool SonTodosElementosIguales(List<string> lista)
        {
            // Comprueba si todos los elementos de la lista son iguales
            return lista.All(x => x == lista.First());
        }


        public List<string> refServDHLVerificarArray(List<string> lista)
        {
            List<string> resultados = new List<string>();

            // Expresión regular para validar los elementos
            Regex regex = new Regex(@"^\d+$");

            // Itera sobre cada elemento de la lista
            foreach (string elemento in lista)
            {
                // Verifica si el elemento cumple con la expresión regular
                if (regex.IsMatch(elemento))
                {
                    // Si cumple, agrégalo a la lista de resultados
                    resultados.Add(elemento);
                }
                else
                {
                    // Si no cumple, agrega "0VALORFALTANTE0"
                    resultados.Add("0VALORFALTANTE0");
                }
            }
            return resultados;
        }


        public List<string> rFCDHLVerificarArray(List<string> cadenas)
        {
            List<string> resultados = new List<string>();

            Regex regex = new Regex("^[A-Z]{3,4}[0-9]{6}[A-Z0-9]{3}$");

            foreach (string cadena in cadenas)
            {
                if (regex.IsMatch(cadena))
                {
                    resultados.Add(cadena);
                }
                else
                {
                    // Si no cumple, agrega "0VALORFALTANTE0"
                    resultados.Add("0VALORFALTANTE0");
                }
            }

            return resultados;
        }


        public List<string> calleDHLVerificarArray(List<string> cadenas)
        {
            // Lista para almacenar las cadenas que pasan el regex
            List<string> cadenasFiltradas = new List<string>();

            // Regex para validar las cadenas
            Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?=(?:.*\s.*){2,}).{10,}$");

            // Iterar sobre cada cadena en la lista
            foreach (string cadena in cadenas)
            {
                // Verificar si la cadena cumple con el regex
                if (regex.IsMatch(cadena))
                {
                    // Agregar la cadena a la lista de cadenas filtradas
                    cadenasFiltradas.Add(cadena);
                }
                else
                {
                    // Si no cumple, agrega "0VALORFALTANTE0"
                    cadenasFiltradas.Add("0VALORFALTANTE0");
                }
            }

            // Devolver la lista de cadenas que pasaron el regex
            return cadenasFiltradas;
        }


        public List<string> municipioDHLVerificarArray(List<string> cadenas)
        {
            //  Tambien nos sirve para pais y estado pero van a ser irrelevantes si se obtiene cp
            //  Lista para almacenar las cadenas que pasan el regex
            List<string> cadenasFiltradas = new List<string>();

            // Regex para validar las cadenas
            Regex regex = new Regex(@"^\d{1,3}$");

            // Iterar sobre cada cadena en la lista
            foreach (string cadena in cadenas)
            {
                // Verificar si la cadena cumple con el regex
                if (regex.IsMatch(cadena))
                {
                    // Agregar la cadena a la lista de cadenas filtradas
                    cadenasFiltradas.Add(cadena);
                }
                else
                {
                    // Si no cumple, agrega "0VALORFALTANTE0"
                    cadenasFiltradas.Add("0VALORFALTANTE0");
                }
            }

            // Devolver la lista de cadenas que pasaron el regex
            return cadenasFiltradas;
        }

    }
}
