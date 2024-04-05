using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excelFiles.Helpers
{
    public class makingDataTable
    {
        public string ErrorMessageTxt = "";
        public static List<string> escribirEnLog = new List<string>();

        public class MyJsonObject
        {
            public string CAMPO { get; set; }
            public string ALIAS { get; set; }
            public string posicion { get; set; }
            public List<string> filas { get; set; }
            public List<string> columnas { get; set; }
        }


        public void formList(List<string> jsonStrings)
        {

            // Lista de objetos deserializados
            List<MyJsonObject> objects = new List<MyJsonObject>();
            // Crear un DataTable
            DataTable dataTable = new DataTable();

            // Deserialización de cada cadena JSON y agregado a la lista
            foreach (string jsonString in jsonStrings)
            {
                MyJsonObject obj = JsonConvert.DeserializeObject<MyJsonObject>(jsonString);
                objects.Add(obj);
            }

            // Agrupar los objetos por CAMPO
            var grupos = objects.GroupBy(o => o.CAMPO);

            // Eliminar los objects duplicados en la lista original
            foreach (var grupo in grupos)
            {
                // Obtener el objeto con más elementos en el campo filas
                // Obtener el objeto con menos elementos coincidentes en el campo filas con '0VALORFALTANTE0'
                var minFilasObj = grupo.OrderBy(o => o.filas.Count(f => f == "0VALORFALTANTE0")).FirstOrDefault();

                // Si ninguno de los objetos tiene elementos coincidentes con '0SINVALOR0' en el campo filas, seleccionar el que tenga menos elementos en columnas
                if (minFilasObj == null || minFilasObj.filas.All(f => f != "0VALORFALTANTE0"))
                {
                    minFilasObj = grupo.OrderBy(o => o.columnas.Count).FirstOrDefault();
                }

                // Eliminar todos los objects de la lista original con el mismo CAMPO
                objects.RemoveAll(o => o.CAMPO == grupo.Key);

                // Agregar el objeto con más elementos en filas de vuelta a la lista original
                objects.Add(minFilasObj);
            }

            foreach (var objeto in objects)
            {
                // Agregar una columna con el nombre del atributo CAMPO
                dataTable.Columns.Add(objeto.CAMPO, typeof(string));

                // Agregar los datos al DataTable como una nueva fila
                DataRow newRow = dataTable.NewRow();
                newRow[objeto.CAMPO] = string.Join(",", objeto.columnas);
                dataTable.Rows.Add(newRow);
            }

            // Mostrar el DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}
