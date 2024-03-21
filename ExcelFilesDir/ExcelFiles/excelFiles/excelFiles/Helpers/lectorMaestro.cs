using excelFiles.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            for (int rows = 0; rows < tablaTest.Rows.Count; rows++)
            {
                for (int cols = 0; cols < tablaTest.Columns.Count; cols++)
                {
                    // Obtén el texto de la celda en la posición (i, j)
                    string textoCelda = tablaTest.Rows[rows][cols].ToString();

                    // Llama a la función con el texto de la celda
                    string resultadoFuncion = BuscarEnHeaders(textoCelda);

                    // Verifica si la función regresó un objeto JSON no vacío
                    if (!string.IsNullOrEmpty(resultadoFuncion) && resultadoFuncion != "{}")
                    {
                        // Obtener contenido de la fila actual como lista de strings
                        List<string> filaActual         = ObtenerFilaComoLista(tablaTest, rows, cols);
                        // Obtener contenido de la columna actual como lista de strings
                        List<string> columnaActual      = ObtenerColumnaComoLista(tablaTest, cols, rows);                        



                        // Deserializa el objeto JSON y agrega la posición de la matriz
                        dynamic objetoDeserializado = JsonConvert.DeserializeObject(resultadoFuncion);
                        objetoDeserializado["posicion"]         = $"({rows}, {cols})";

                        // Llamar a la función que maneja la fila actual
                        objetoDeserializado["filas"]            = JArray.FromObject(LimpiarLista(filaActual, resultadoFuncion));

                        // Llamar a la función que maneja la columna actual
                        objetoDeserializado["columnas"]         = JArray.FromObject(LimpiarLista(columnaActual, resultadoFuncion));

                        // Agrega el objeto JSON modificado a la lista
                        objetosJson.Add(JsonConvert.SerializeObject(objetoDeserializado));
                    }
                }
            }
        }


        // Función para obtener el contenido de una fila del DataTable como lista de strings
        private List<string> ObtenerFilaComoLista(DataTable tabla, int indiceFila, int col)
        {
            List<string> fila = new List<string>();
            int indice = 0;
            foreach (DataColumn columna in tabla.Columns)
            {
                if (indice >= col)
                {
                    fila.Add(tabla.Rows[indiceFila][columna.ColumnName].ToString());
                }

                indice++;
            }
            return fila;
        }

        // Función para obtener el contenido de una columna del DataTable como lista de strings
        private List<string> ObtenerColumnaComoLista(DataTable tabla, int indiceColumna, int row)
        {
            List<string> columna = new List<string>();
            int indice = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                if (indice >= row)
                {
                    columna.Add(fila[indiceColumna].ToString());
                }
                indice++;
            }
            return columna;
        }


        // Función para manejar la fila actual
        private List<string> LimpiarLista(List<string> lista, string nombreElemento)
        {
            limpiezaDeDatos mrCleaner = new limpiezaDeDatos();

            List<string> listaVacia = new List<string>();

            // Aqui vamos a poner un switch, obtendremos el nombre de la caracteristica y
            // le pasaremos diferentes regex para corroborar si es un elemento del que dice ser


            // Deserializa el JSON a un objeto
            dynamic objetoDeserializado = JsonConvert.DeserializeObject(nombreElemento);

            string campo = objetoDeserializado.CAMPO.ToString();
            string alias = objetoDeserializado.ALIAS.ToString();

            switch (campo)
            {
                case "REFERENCIA_DE_SERV_list":
                    {
                        //El alias lo ocuparemos cuando un campo puede contener numeros y letras
                        //como en este caso, a veces son solo numeros y a veces son solo letras.
                        //Entonces depende de si queremos llamar una funcion diferente

                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.refServDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.refServDHLVerificarArray(lista);
                        }

                    }
                    break;

                case "RFCREMITENTE_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.rFCDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.rFCDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "CALLE_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.calleDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.calleDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "MUNICIPIO_SAT_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.municipioDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.municipioDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "ESTADO_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.estadoDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.estadoDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "PAIS_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.estadoDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.estadoDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "CODIGOPOSTAL_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.cpDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.cpDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "RFCDESTINATARIO_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.rFCDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.rFCDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "CALLE2_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.calleDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.calleDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "MUNICIPIO_SAT2_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.municipioDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.municipioDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "ESTADO_SAT2_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.estadoDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.estadoDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "PAIS2_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.estadoDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.estadoDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "CODIGOPOSTAL2_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.cpDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.cpDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "PESONETOTOTAL_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.SoloNumeros(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.SoloNumeros(lista);
                        }
                    }
                    break;

                case "NUMTOTALMERCANCIAS_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.SoloNumeros(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.SoloNumeros(lista);
                        }
                    }
                    break;

                case "BIENESTRANSP_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.codigoMercanciaDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.codigoMercanciaDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "DESCRIPCION_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.descripcionMercDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.descripcionMercDHLVerificarArray(lista);
                        }
                    }
                    break;

                case "CLAVEUNIDAD_list":
                    {
                        if (mrCleaner.SonTodosElementosIguales(mrCleaner.claveUnidadDHLVerificarArray(lista)))
                        {
                            return listaVacia;
                        }
                        else
                        {
                            return mrCleaner.claveUnidadDHLVerificarArray(lista);
                        }
                    }
                    break;

            }

            return listaVacia;

        }


              
        public string BuscarEnHeaders(string contenidoCelda)
        {
            List<List<string>> listaSuprema = Headers.HeadList;
            Dictionary<string, object> resultDict = new Dictionary<string, object>();

            // Utiliza un bucle foreach para iterar sobre cada lista en listaSuprema
            foreach (var lista in listaSuprema)
            {
                // Verifica si la lista contiene el contenido de la celda
                if (lista.Contains(contenidoCelda))
                {
                    // Encontró la palabra, agrega el índice o el nombre de la lista al JSON
                    resultDict["CAMPO"] = lista[0].ToString();
                    resultDict["ALIAS"] = contenidoCelda;
                    break; // Termina el bucle una vez que se encuentra el contenido

                }
            }

            // Convierte el diccionario a JSON
            string jsonResult = JsonConvert.SerializeObject(resultDict);

            return jsonResult;
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
