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


        public DataTable formList(List<string> jsonStrings)
        {

            List<string> REFERENCIA_DE_SERV_list_prod         = new List<string>();
            List<string> IDORIGEN_list_prod                   = new List<string>();
            List<string> RFCREMITENTE_list_prod               = new List<string>();
            List<string> CALLE_list_prod                      = new List<string>();
            List<string> MUNICIPIO_SAT_list_prod              = new List<string>();
            List<string> ESTADO_SAT_list_prod                 = new List<string>();
            List<string> PAIS_list_prod                       = new List<string>();
            List<string> CODIGOPOSTAL_list_prod               = new List<string>();
            List<string> RFCDESTINATARIO_list_prod            = new List<string>();
            List<string> CALLE2_list_prod                     = new List<string>();
            List<string> MUNICIPIO_SAT2_list_prod             = new List<string>();
            List<string> ESTADO_SAT2_list_prod                = new List<string>();
            List<string> PAIS2_list_prod                      = new List<string>();
            List<string> CODIGOPOSTAL2_list_prod              = new List<string>();
            List<string> PESONETOTOTAL_list_prod              = new List<string>();
            List<string> NUMTOTALMERCANCIAS_list_prod         = new List<string>();
            List<string> BIENESTRANSP_list_prod               = new List<string>();
            List<string> DESCRIPCION_list_prod                = new List<string>();
            List<string> CLAVEUNIDAD_list_prod                = new List<string>();
            List<string> MATERIALPELIGROSO_list_prod          = new List<string>();
            List<string> CVEMATERIALPELIGROSO_list_prod       = new List<string>();
            List<string> FRACCIONARANCELARIA_list_prod        = new List<string>();
            List<string> FRACCIONARANCELARIA2_list_prod       = new List<string>();


            // Lista de objetos deserializados
            List<MyJsonObject> objects = new List<MyJsonObject>();
            // Crear un DataTable
            DataTable dt = new DataTable();

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
                string campo = objeto.CAMPO;

                switch (campo)
                {
                    case "REFERENCIA_DE_SERV_list":
                        {
                            //El alias lo ocuparemos cuando un campo puede contener numeros y letras
                            //como en este caso, a veces son solo numeros y a veces son solo letras.
                            //Entonces depende de si queremos llamar una funcion diferente

                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                REFERENCIA_DE_SERV_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                REFERENCIA_DE_SERV_list_prod.AddRange(objeto.filas);
                            }

                        }
                        break;

                    case "RFCREMITENTE_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                RFCREMITENTE_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                RFCREMITENTE_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "CALLE_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                CALLE_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                CALLE_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "MUNICIPIO_SAT_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                MUNICIPIO_SAT_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                MUNICIPIO_SAT_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "ESTADO_SAT_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                ESTADO_SAT_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                ESTADO_SAT_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "PAIS_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                PAIS_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                PAIS_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "CODIGOPOSTAL_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                CODIGOPOSTAL_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                CODIGOPOSTAL_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "RFCDESTINATARIO_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                RFCDESTINATARIO_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                RFCDESTINATARIO_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "CALLE2_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                CALLE2_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                CALLE2_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "MUNICIPIO_SAT2_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                MUNICIPIO_SAT2_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                MUNICIPIO_SAT2_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "ESTADO_SAT2_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                ESTADO_SAT2_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                ESTADO_SAT2_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "PAIS2_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                PAIS2_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                PAIS2_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "CODIGOPOSTAL2_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                CODIGOPOSTAL2_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                CODIGOPOSTAL2_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "PESONETOTOTAL_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                PESONETOTOTAL_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                PESONETOTOTAL_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "NUMTOTALMERCANCIAS_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                NUMTOTALMERCANCIAS_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                NUMTOTALMERCANCIAS_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "BIENESTRANSP_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                BIENESTRANSP_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                BIENESTRANSP_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "DESCRIPCION_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                DESCRIPCION_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                DESCRIPCION_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                    case "CLAVEUNIDAD_list":
                        {
                            if (objeto.columnas != null && objeto.columnas.Count > 0)
                            {
                                CLAVEUNIDAD_list_prod.AddRange(objeto.columnas);
                            }
                            else if (objeto.filas != null && objeto.filas.Count > 0)
                            {
                                CLAVEUNIDAD_list_prod.AddRange(objeto.filas);
                            }
                        }
                        break;

                }
            }


            dt.Columns.Add("REFERENCIA_DE_SERV", typeof(string));
            dt.Columns.Add("IDORIGEN", typeof(string));
            dt.Columns.Add("RFCREMITENTE", typeof(string));
            dt.Columns.Add("CALLE", typeof(string));
            dt.Columns.Add("MUNICIPIO_SAT", typeof(string));
            dt.Columns.Add("ESTADO_SAT", typeof(string));
            dt.Columns.Add("PAIS", typeof(string));
            dt.Columns.Add("CODIGOPOSTAL", typeof(string));
            dt.Columns.Add("RFCDESTINATARIO", typeof(string));
            dt.Columns.Add("CALLE2", typeof(string));
            dt.Columns.Add("MUNICIPIO_SAT2", typeof(string));
            dt.Columns.Add("ESTADO_SAT2", typeof(string));
            dt.Columns.Add("PAIS2", typeof(string));
            dt.Columns.Add("CODIGOPOSTAL2", typeof(string));
            dt.Columns.Add("PESONETOTOTAL", typeof(string));
            dt.Columns.Add("NUMTOTALMERCANCIAS", typeof(string));
            dt.Columns.Add("BIENESTRANSP", typeof(string));
            dt.Columns.Add("DESCRIPCION", typeof(string));
            dt.Columns.Add("CLAVEUNIDAD", typeof(string));
            dt.Columns.Add("MATERIALPELIGROSO", typeof(string));
            dt.Columns.Add("CVEMATERIALPELIGROSO", typeof(string));
            dt.Columns.Add("FRACCIONARANCELARIA", typeof(string));
            dt.Columns.Add("FRACCIONARANCELARIA2", typeof(string));


            int maxRows = Math.Max(
                BIENESTRANSP_list_prod.Count,
                DESCRIPCION_list_prod.Count
            );


            // Agregar datos a las columnas
            for (int i = 0; i < maxRows; i++)
            {
                // Crear una nueva fila
                DataRow newRow = dt.NewRow();

                // Agregar valores a cada columna si existen en la lista, o un valor vacío si no existen
                newRow["REFERENCIA_DE_SERV"]            = i < REFERENCIA_DE_SERV_list_prod.Count ? REFERENCIA_DE_SERV_list_prod[i] : "";
                newRow["IDORIGEN"]                      = i < IDORIGEN_list_prod.Count ? IDORIGEN_list_prod[i] : "";
                newRow["RFCREMITENTE"]                  = i < RFCREMITENTE_list_prod.Count ? RFCREMITENTE_list_prod[i] : "";
                newRow["CALLE"]                         = i < CALLE_list_prod.Count ? CALLE_list_prod[i] : "";
                newRow["MUNICIPIO_SAT"]                 = i < MUNICIPIO_SAT_list_prod.Count ? MUNICIPIO_SAT_list_prod[i] : "";
                newRow["ESTADO_SAT"]                    = i < ESTADO_SAT_list_prod.Count ? ESTADO_SAT_list_prod[i] : "";
                newRow["PAIS"]                          = i < PAIS_list_prod.Count ? PAIS_list_prod[i] : "";
                newRow["CODIGOPOSTAL"]                  = i < CODIGOPOSTAL_list_prod.Count ? CODIGOPOSTAL_list_prod[i] : "";
                newRow["RFCDESTINATARIO"]               = i < RFCDESTINATARIO_list_prod.Count ? RFCDESTINATARIO_list_prod[i] : "";
                newRow["CALLE2"]                        = i < CALLE2_list_prod.Count ? CALLE2_list_prod[i] : "";
                newRow["MUNICIPIO_SAT2"]                = i < MUNICIPIO_SAT2_list_prod.Count ? MUNICIPIO_SAT2_list_prod[i] : "";
                newRow["ESTADO_SAT2"]                   = i < ESTADO_SAT2_list_prod.Count ? ESTADO_SAT2_list_prod[i] : "";
                newRow["PAIS2"]                         = i < PAIS2_list_prod.Count ? PAIS2_list_prod[i] : "";
                newRow["CODIGOPOSTAL2"]                 = i < CODIGOPOSTAL2_list_prod.Count ? CODIGOPOSTAL2_list_prod[i] : "";
                newRow["PESONETOTOTAL"]                 = i < PESONETOTOTAL_list_prod.Count ? PESONETOTOTAL_list_prod[i] : "";
                newRow["NUMTOTALMERCANCIAS"]            = i < NUMTOTALMERCANCIAS_list_prod.Count ? NUMTOTALMERCANCIAS_list_prod[i] : "";
                newRow["BIENESTRANSP"]                  = i < BIENESTRANSP_list_prod.Count ? BIENESTRANSP_list_prod[i] : "";
                newRow["DESCRIPCION"]                   = i < DESCRIPCION_list_prod.Count ? DESCRIPCION_list_prod[i] : "";
                newRow["CLAVEUNIDAD"]                   = i < CLAVEUNIDAD_list_prod.Count ? CLAVEUNIDAD_list_prod[i] : "";
                newRow["MATERIALPELIGROSO"]             = i < MATERIALPELIGROSO_list_prod.Count ? MATERIALPELIGROSO_list_prod[i] : "";
                newRow["CVEMATERIALPELIGROSO"]          = i < CVEMATERIALPELIGROSO_list_prod.Count ? CVEMATERIALPELIGROSO_list_prod[i] : "";
                newRow["FRACCIONARANCELARIA"]           = i < FRACCIONARANCELARIA_list_prod.Count ? FRACCIONARANCELARIA_list_prod[i] : "";
                newRow["FRACCIONARANCELARIA2"]          = i < FRACCIONARANCELARIA2_list_prod.Count ? FRACCIONARANCELARIA2_list_prod[i] : "";
                // Agrega el resto de columnas aquí...

                // Agregar la fila al DataTable
                dt.Rows.Add(newRow);
            }

            // Mostrar el DataTable
            //foreach (DataRow row in dt.Rows)
            //{
            //    foreach (var item in row.ItemArray)
            //    {
            //        Console.Write(item + "\t");
            //    }
            //    Console.WriteLine();
            //}

            DataTable cleanDT = new DataTable();

            cleanDT = RemoveRowsWithMostOccurrences(dt, "0VALORFALTANTE0");

            return dt;
        }


        public DataTable RemoveRowsWithMostOccurrences(DataTable dataTable, string targetString)
        {
            int targetCount = 0;

            // Contar el número de columnas en el DataTable
            int columnCount = dataTable.Columns.Count;

            // Iterar sobre las filas en orden inverso
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = dataTable.Rows[i];
                int count = 0;
                foreach (var item in row.ItemArray)
                {
                    if (item.ToString() == targetString)
                    {
                        count++;
                    }
                }
                // Si el número de ocurrencias es mayor o igual a la mitad de las columnas, se marca la fila para eliminarla
                if (count >= columnCount / 2)
                {
                    targetCount = count;
                    // Eliminar la fila
                    dataTable.Rows.RemoveAt(i);
                }
            }

            return dataTable;
        }

    }
}