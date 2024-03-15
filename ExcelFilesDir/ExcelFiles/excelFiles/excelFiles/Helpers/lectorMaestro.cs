using excelFiles.Clases;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace excelFiles.Helpers
{
    internal class lectorMaestro
    {

        public string ErrorMessageTxt = "";
        public static List<string> escribirEnLog = new List<string>();


        public DataTable ProcesoExcelM(string excelPath)
        {
            DataTable excelDTF = new DataTable();
            ErrorMessageTxt = "";
            bool isBanned = false;
            for (int i = 0; i < controlExcepciones.BannedExcel.Count; i++)
            {
                if (excelPath == controlExcepciones.BannedExcel[i])
                { isBanned = true; }
            }
            if (isBanned)
            {
            }
            else
            {
                try
                {
                    FileStream fileStream = null;
                    ExcelPackage LecExcel = null;

                    // limpieza ante todo
                    excelDTF.Clear();

                    FileInfo datos = new FileInfo(excelPath);
                    try
                    {
                        LecExcel = new ExcelPackage(datos);
                        fileStream = datos.Open(FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch (Exception)
                    {
                        controlExcepciones.BannedExcel.Add(excelPath);
                        //~$
                        ErrorMessageTxt += String.Format("El archivo no pudo leerse, Cierre el archivo para que pueda procesarse {0}", "<br />");
                        return excelDTF;
                    }

                    LecExcel.Load(fileStream);

                    //Aqui deberiamos poner un for para buscar en cada una de las hojas
                    //Aqui deberiamos poner un for para buscar en cada una de las hojas
                    //Aqui deberiamos poner un for para buscar en cada una de las hojas
                    //Aqui deberiamos poner un for para buscar en cada una de las hojas
                    //Aqui deberiamos poner un for para buscar en cada una de las hojas
                    //Aqui deberiamos poner un for para buscar en cada una de las hojas
                    //Aqui deberiamos poner un for para buscar en cada una de las hojas

                    for (int hojaExcel = 0; hojaExcel < 10; hojaExcel++)
                    {
                    InicioDelFor:
                        try
                        {
                            ExcelWorksheet worksheetTest = LecExcel.Workbook.Worksheets[hojaExcel];
                            fileStream.Dispose();
                            fileStream.Close();

                        }
                        catch (Exception)
                        {
                            hojaExcel++;
                            fileStream.Dispose();
                            fileStream.Close();
                            escribirEnLog.Add(string.Format("La hoja [ {0} ] no existe en el documento {1}", hojaExcel, excelPath));
                            goto InicioDelFor;
                        }

                        ExcelWorksheet worksheet = LecExcel.Workbook.Worksheets[hojaExcel]; // Obtener la primera hoja

                        fileStream.Dispose();
                        fileStream.Close();

                        worksheet.Cells.AutoFitColumns();

                        if (worksheet.Dimension == null)
                        {
                            ErrorMessageTxt += String.Format("La hoja esta vacía, el archivo puede estar corrupto o en la hoja incorrecta. {0}", "<br />");
                            return excelDTF;
                        }

                        //create a list to hold the column names
                        List<string> columnNames = new List<string>();

                        //needed to keep track of empty column headers
                        //int currentColumn = 1;



                        // Obtener la dimensión de la hoja de cálculo
                        int rowCount = worksheet.Dimension.Rows;
                        int columnCount = worksheet.Dimension.Columns;

                        // Agregar columnas al DataTable
                        for (int col = 1; col <= columnCount; col++)
                        {
                            DataColumn column = new DataColumn();
                            excelDTF.Columns.Add(column);
                        }

                        // Leer cada celda y agregar su valor al DataTable
                        for (int row = 1; row <= rowCount; row++)
                        {
                            DataRow dataRow = excelDTF.NewRow();

                            for (int col = 1; col <= columnCount; col++)
                            {
                                ExcelRangeBase cell = worksheet.Cells[row, col];

                                // Obtener el valor de la celda
                                object cellValue = cell.Text;

                                // Verificar si el valor de la celda no es nulo ni está vacío
                                if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                                {
                                    dataRow[col - 1] = cellValue.ToString();
                                }
                                else
                                {
                                    // Si la celda está vacía, puedes manejarla de acuerdo a tus necesidades
                                    dataRow[col - 1] = string.Empty;
                                }
                            }

                            // Agregar la fila al DataTable
                            excelDTF.Rows.Add(dataRow);
                        }

                        fileStream.Dispose();

                        return excelDTF;

                    }

                }
                catch (Exception ex)
                {
                    escribirEnLog.Add(string.Format("{0} - Error Al leer archivo {1} ", DateTime.Now, ex.ToString()));
                    throw;
                }
            }
            isBanned = false;
            return excelDTF;
        }


        public void BuscarEnTabla(DataTable tablaTest)
        {
            // Lista para almacenar objetos JSON con la posición de la celda
            List<string> objetosJson = new List<string>();

            // Recorre el DataTable posición por posición
            for (int i = 0; i < tablaTest.Rows.Count; i++)
            {
                for (int j = 0; j < tablaTest.Columns.Count; j++)
                {
                    // Obtén el texto de la celda en la posición (i, j)
                    string textoCelda = tablaTest.Rows[i][j].ToString();

                    // Llama a la función con el texto de la celda
                    string resultadoFuncion = BuscarEnHeaders(textoCelda);

                    // Verifica si la función regresó un objeto JSON no vacío
                    if (!string.IsNullOrEmpty(resultadoFuncion))
                    {
                        // Deserializa el objeto JSON y agrega la posición de la matriz
                        dynamic objetoDeserializado = JsonConvert.DeserializeObject(resultadoFuncion);
                        objetoDeserializado["posicion"] = $"({i}, {j})";

                        // Agrega el objeto JSON modificado a la lista
                        objetosJson.Add(JsonConvert.SerializeObject(objetoDeserializado));
                    }
                }
            }

        }


        public string BuscarEnHeaders(string contenidoCelda)
        {
            List<List<string>> listaSuprema = Headers.HeadList;
            Dictionary<string, object> resultDict = new Dictionary<string, object>();

            for (int i = 0; i < listaSuprema.Count; i++)
            {
                if (listaSuprema[i].Contains(contenidoCelda))
                {
                    // Encontró la palabra, agregue el índice o el nombre de la lista a un JSON
                    resultDict[contenidoCelda] = i; // Puedes usar i o el nombre de la lista, según lo que prefieras
                }
            }

            // Convierte el diccionario a JSON
            string jsonResult = JsonConvert.SerializeObject(resultDict);

            return jsonResult;
        }


        public void BuscadorHeaders(DataTable tablaTest)
        {
            //List<List<string>> headersList = new List<List<string>>();
            //List<string> jsonConfList = new List<string>();

            //List<string> dhlHeaders = Headers.DHL_H;
            //List<string> genericHeaders = Headers.DHL_H;

            //headersList.Add(dhlHeaders);
            //headersList.Add(genericHeaders);

            //try
            //{
            //    foreach (var listaCliente in headersList)
            //    {
            //        //Iniciamos el contador para saber donde inician los headers
            //        int contador = 1;

            //        //Aqui vamos a intentar localizar los headers haciendo un recorrido por cada row.
            //        foreach (DataRow row in tablaTest.Rows)
            //        {
            //            List<string> listaPosibleHeader = new List<string>();
            //            List<int> posicionesCoincidencias = new List<int>();

            //            foreach (DataColumn column in tablaTest.Columns)
            //            {
            //                //  Agregar el valor de la columna a la lista
            //                listaPosibleHeader.Add((string)row[column]);
            //            }

            //            //  Nos dice si encontro algo en la lista
            //            if (listaCliente.Intersect(listaPosibleHeader).Any())
            //            {
            //                /*
            //                Aqui vamos a evaluar las listas
            //                Iterar sobre los elementos de la lista molde
            //                */
            //                foreach (var elemento in listaCliente)
            //                {
            //                    //  Buscar la posición del elemento en la lista a evaluar
            //                    int posicionEnListaAEvaluar = listaPosibleHeader.IndexOf(elemento);

            //                    //  Agregar la posición donde se encontró la coincidencia
            //                    posicionesCoincidencias.Add(posicionEnListaAEvaluar);
            //                }

            //                //  Aqui deberiamos evaluar que cosas guardar o num de coincidencias


            //                //  Aqui guardaremos el resultado de las listas
            //                var objetoJSON = new
            //                {
            //                    matches = posicionesCoincidencias.Count(num => num != -1),
            //                    listaHeaders = listaCliente,
            //                    posiciones = posicionesCoincidencias,
            //                    inicioHead = contador
            //                };

            //                // Convertir el objeto JSON a formato string y agregarlo a la lista
            //                string json = JsonConvert.SerializeObject(objetoJSON);
            //                jsonConfList.Add(json);
            //            }
            //            //  Aqui evaluaremos que hacer con los elementos de las listas

            //        }
            //        //  Contador de header
            //        contador++;
            //    }
            //    //Aqui nos decidimos por un objeto de la lista
            //    var jsonConfObj = ObtenerDatosJson(jsonConfList);
            //    //Aqui intentaremos abrir el Json y darle valores generales a las variables que nos importan
            //    GeneralizarHeadersJson(jsonConfObj);


            //    Console.WriteLine(jsonConfList.ToString());
            //}
            //catch (Exception ex)
            //{
            //    escribirEnLog.Add(string.Format("{0} - Error Al leer archivo {1} ", DateTime.Now, ex.ToString()));
            //    throw;
            //}
        }


        public void GeneralizarHeadersJson(string JsonConfObjStr)
        {
            try
            {
                // Deserializar el objeto JSON al objeto C#
                jsonConf objetoJson = JsonConvert.DeserializeObject<jsonConf>(JsonConfObjStr);

                // Acceder a la lista de números
                List<int> listaDeNumeros = objetoJson.posiciones;
                List<string> listaDeHeaders = objetoJson.listaHeaders;

                // Ahora puedes usar la lista de números como desees
                mercanciaGenerica objetoJsonFinal = new mercanciaGenerica();

                // Iteramos sobre la lista de strings
                foreach (var (str, num) in listaDeHeaders.Zip(listaDeNumeros, (s, n) => (s, n)))
                {

                    // Comparamos cada string con diferentes condiciones
                    if (string.Equals(str, "EMBARQUE_DHL", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "Referencia del servicio", StringComparison.OrdinalIgnoreCase))
                    {
                        // Asignamos el valor al campo correspondiente del objeto JSON
                        objetoJsonFinal.ReferenciaDelServicio = num;
                    }
                    else if (string.Equals(str, "RFC del remitente", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "RFCREMITENTE", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.RFCdelRemitente = num;
                    }
                    else if (string.Equals(str, "Razón Social del Remitente", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "RSdelRemitente", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.RSdelRemitente = num;
                    }
                    else if (string.Equals(str, "CALLE", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.Calle = num;
                    }
                    else if (str == "Municipio" ||
                        string.Equals(str, "MUNICIPIO_SAT", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.Municipio = num;
                    }
                    else if (string.Equals(str, "ESTADO_SAT", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.Estado = num;
                    }
                    else if (str == "País" ||
                        string.Equals(str, "PAIS", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.Pais = num;
                    }
                    else if (str == "C.P." ||
                        string.Equals(str, "CODIGOPOSTAL", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.CP = num;
                    }
                    else if (string.Equals(str, "RFC Destinatario", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "RFCREMITENTE", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.RFCDestinatario = num;
                    }
                    else if (string.Equals(str, "Razón Social del Destinatario", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "RSdelDestinatario", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.RSdelDestinatario = num;
                    }
                    else if (string.Equals(str, "CALLE2", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.Calle2 = num;
                    }
                    else if (str == "Municipio2" ||
                        string.Equals(str, "MUNICIPIO_SAT2", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.Municipio2 = num;
                    }
                    else if (string.Equals(str, "ESTADO_SAT2", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.Estado2 = num;
                    }
                    else if (str == "País2" ||
                        string.Equals(str, "PAIS2", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.Pais2 = num;
                    }
                    else if (str == "C.P.2" ||
                        string.Equals(str, "CODIGOPOSTAL2", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.CP2 = num;
                    }
                    else if (string.Equals(str, "Peso Neto", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "PESONETOTOTAL", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.PesoNeto = num;
                    }
                    else if (string.Equals(str, "Número Total de Mercancías", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "NUMTOTALMERCANCIAS", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.NumeroTotalMercancias = num;
                    }
                    else if (string.Equals(str, "Clave del Bien Transportado", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "BIENESTRANSP", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.ClaveDelBienTransportado = num;
                    }
                    else if (string.Equals(str, "Descripción del Bien Transportado", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "DESCRIPCION", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.DescripcionDelBienTransportado = num;
                    }
                    else if (string.Equals(str, "Clave Unidad de medida", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "CLAVEUNIDAD", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.ClaveUnidadDeMedida = num;
                    }
                    else if (string.Equals(str, "MATERIALPELIGROSO", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "Material Peligroso (Sí o No)", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.MaterialPeligroso = num;
                    }
                    else if (string.Equals(str, "VALORMERCANCIA", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(str, "Valor de la Mercancía ", StringComparison.OrdinalIgnoreCase))
                    {
                        objetoJsonFinal.ValorDeLaMercancia = num;
                    }
                }

                // Convertimos el objeto JSON a formato JSON
                string json = JsonConvert.SerializeObject(objetoJson, Formatting.Indented);

                // Mostramos el objeto JSON resultante
                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                escribirEnLog.Add(string.Format("{0} - Error Al leer archivo {1} ", DateTime.Now, ex.ToString()));
                throw;
            }
        }


        public string ObtenerDatosJson(List<string> JsonObjStr)
        {
            try
            {
                // Inicializamos variables para almacenar el objeto JSON con el valor de matches más grande
                int maxMatches = int.MinValue;
                dynamic objetoJsonMaxMatches = null;

                // Iteramos sobre la lista de strings
                foreach (string jsonString in JsonObjStr)
                {
                    // Deserializamos el objeto JSON
                    dynamic objetoJson = JsonConvert.DeserializeObject(jsonString);

                    // Obtenemos el valor de matches
                    int matches = objetoJson.matches;

                    // Comparamos con el valor máximo encontrado hasta ahora
                    if (matches > maxMatches)
                    {
                        maxMatches = matches;
                        objetoJsonMaxMatches = objetoJson;
                    }
                }

                // Convertir el objeto JSON seleccionado a formato JSON
                string jsonSeleccionado = JsonConvert.SerializeObject(objetoJsonMaxMatches, Formatting.Indented);
                return jsonSeleccionado;
            }
            catch (Exception ex)
            {
                escribirEnLog.Add(string.Format("{0} - Error Al leer archivo {1} ", DateTime.Now, ex.ToString()));
                throw;
            }

            return "";
        }


        public void BuscarInicioTabla(DataTable tablaSucia)
        {

        }


        public string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, "[^a-zA-Z0-9_.]+", " ", RegexOptions.Compiled, TimeSpan.FromSeconds(1.5));
            }

            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
    }
}
