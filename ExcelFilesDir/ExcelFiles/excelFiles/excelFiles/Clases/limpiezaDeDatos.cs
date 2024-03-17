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


    }
}
