using excelFiles.Clases;
using excelFiles.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;

namespace excelFiles.MLModels
{
    public class getValues
    {
        analizadores    filtro      = new analizadores();

        public string ErrorMessageTxt = "";

        private SqlConnection _xConnString = new SqlConnection();
        private SqlConnection _xConnString2 = new SqlConnection();

        public static List<string> escribirEnLog = new List<string>();
        string mensajeMercancia = "Referencias en este archivo desponibles para DB";


        public class MLData
        {
            public int textTotalLength { get; set; }
            public int textKind { get; set; }
            public int textNumbers { get; set; }
            public int textOnlyChar { get; set; }
            public int textCharsMin { get; set; }
            public int textCharsMay { get; set; }
            public int textWhiteSpaces { get; set; }
            public int textDotSpaces { get; set; }
            public string label { get; set; }
        }

        public getValues()
        {
            this.CargarConexion(constantes._xServidorBD, constantes._xNombreBD, constantes._xUsuarioBD, constantes._xPassWordBD);
            this.CargarConexion2(constantes._xServidorBD2, constantes._xNombreBD2, constantes._xUsuarioBD2, constantes._xPassWordBD2);
        }

        private void CargarConexion(string _xServerName, string _xNombreBD, string _xUser, string _xPassword)
        {
            this._xConnString.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; User Id={2}; Password = {3}; TrustServerCertificate=true;", new object[] { _xServerName, _xNombreBD, _xUser, _xPassword });
        }
        private void CargarConexion2(string _xServerName, string _xNombreBD, string _xUser, string _xPassword)
        {
            this._xConnString2.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; User Id={2}; Password = {3}; TrustServerCertificate=true;", new object[] { _xServerName, _xNombreBD, _xUser, _xPassword });
        }

        public DataTable ObtenerTabla()
        {
            DataTable dt = new DataTable();
            try
            {
                string connectionString = string.Format("data source = SRVFTRDB1; initial catalog = X_FTR; User Id=sa; Password = mxsis86%1021&js; TrustServerCertificate=true;");

                string sentencia = "SELECT TOP 1000 * " +
"FROM ( " +
"    SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn " +
"    FROM [x_FTR].[dbo].[TB_MERCANCIAS_CLIENTE] " +
"    WHERE CHARINDEX('.', Calle) > 0 " +
") AS CalleConPunto " +
"WHERE rn <= 1000 " +
" " +
"UNION ALL " +
" " +
"SELECT TOP 1000 * " +
"FROM ( " +
"    SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn " +
"    FROM [x_FTR].[dbo].[TB_MERCANCIAS_CLIENTE] " +
"    WHERE Calle IN ( " +
"        SELECT Calle " +
"        FROM [x_FTR].[dbo].[TB_MERCANCIAS_CLIENTE] " +
"        GROUP BY Calle " +
"        HAVING COUNT(*) = 1 " +
"    ) " +
") AS CalleUnica " +
"WHERE rn <= 1000 " +
" " +
"UNION ALL " +
" " +
"SELECT TOP 1000 * " +
"FROM ( " +
"    SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn " +
"    FROM [x_FTR].[dbo].[TB_MERCANCIAS_CLIENTE] " +
"    WHERE CHARINDEX('.', RSdelRemitente) > 0 " +
") AS RSdelRemitenteConPunto " +
"WHERE rn <= 1000 " +
" " +
"UNION ALL " +
" " +
"SELECT TOP 1000 * " +
"FROM ( " +
"    SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS rn " +
"    FROM [x_FTR].[dbo].[TB_MERCANCIAS_CLIENTE] " +
"    WHERE RSdelRemitente IN ( " +
"        SELECT RSdelRemitente " +
"        FROM [x_FTR].[dbo].[TB_MERCANCIAS_CLIENTE] " +
"        GROUP BY RSdelRemitente " +
"        HAVING COUNT(*) = 1 " +
"    ) " +
") AS RSdelRemitenteUnico " +
"WHERE rn <= 1000;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sentencia, connection))
                    {
                        // Establece el tiempo de espera de la consulta en 10 minutos (600 segundos)
                        command.CommandTimeout = 600; // 600 segundos = 10 minutos

                        connection.Open();
                        SqlDataAdapter dataAda = new SqlDataAdapter(command);
                        dataAda.Fill(dt);
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                escribirEnLog.Add(string.Format("{0} - Problemas al obtener catálogos de los archivos. {1}", DateTime.Now, e.Message));
            }
            finally
            {
                this._xConnString.Close();
            }

            return dt;
        }

        public void ObtenerColumnas(DataTable dt)
        {
            List<string> RFC_list                           = new List<string>();
            List<string> RAZONSOCIAL_list                   = new List<string>();
            List<string> CALLE_list                         = new List<string>();
            List<string> MUNICIPIO_list                     = new List<string>();
            List<string> ESTADO_list                        = new List<string>();
            List<string> CP_list                            = new List<string>();
            List<string> CLAVEDBIENTRASNP_list              = new List<string>();
            List<string> CLAVEUNIDADMEDIDA_list             = new List<string>();
            List<string> DESCRIPCIONDELBIENTRASNP_list      = new List<string>();
            List<string> FRACCIONARANC_list                 = new List<string>();

            List<MLData> FINAL_DATA                         = new List<MLData>();

            // Itera sobre las filas del DataTable
            foreach (DataRow row in dt.Rows)
            {
                // Extrae los valores de las columnas específicas y los agrega a las listas correspondientes
                
                //  Remitente
                RFC_list.Add(                           row["RFCdelRemitente"].ToString());
                RAZONSOCIAL_list.Add(                   row["RSdelRemitente"].ToString());
                CALLE_list.Add(                         row["Calle"].ToString());
                MUNICIPIO_list.Add(                     row["Municipio"].ToString());
                ESTADO_list.Add(                        row["Estado"].ToString());
                CP_list.Add(                            row["CP"].ToString());
                
                //Destinatario
                RFC_list.Add(                           row["RFCDestinatario"].ToString());
                RAZONSOCIAL_list.Add(                   row["RSdelDestinatario"].ToString());
                CALLE_list.Add(                         row["Calle2"].ToString());
                MUNICIPIO_list.Add(                     row["Municipio2"].ToString());
                ESTADO_list.Add(                        row["Estado2"].ToString());
                CP_list.Add(                            row["CP2"].ToString());

                //Mercancia
                CLAVEDBIENTRASNP_list.Add(              row["ClaveDelBienTransportado"].ToString());
                CLAVEUNIDADMEDIDA_list.Add(             row["ClaveUnidadDeMedida"].ToString());
                DESCRIPCIONDELBIENTRASNP_list.Add(      row["DescripcionDelBienTransportado"].ToString());
                FRACCIONARANC_list.Add(                 row["FraccionArancelaria"].ToString());
            }

            //Aqui mandamos a evaluar todas las listas 
            //  Obtener RFC
            foreach(var rfc in RFC_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength         = filtro.ContarCaracteres(rfc),
                    textKind                = filtro.TipoDeCadena(rfc),
                    textNumbers             = filtro.ContarDigitos(rfc),
                    textOnlyChar            = filtro.ContarCaracteresExcluyendoNumeros(rfc),
                    textCharsMin            = filtro.ContarLetrasMinusculas(rfc),
                    textCharsMay            = filtro.ContarLetrasMayusculas(rfc),
                    textWhiteSpaces         = filtro.ContarEspacios(rfc),
                    textDotSpaces           = filtro.ContarPuntos(rfc),
                    label = "RFC"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            //Obtener Razon social
            foreach (var rs in RAZONSOCIAL_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(rs),
                    textKind = filtro.TipoDeCadena(rs),
                    textNumbers = filtro.ContarDigitos(rs),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(rs),
                    textCharsMin = filtro.ContarLetrasMinusculas(rs),
                    textCharsMay = filtro.ContarLetrasMayusculas(rs),
                    textWhiteSpaces = filtro.ContarEspacios(rs),
                    textDotSpaces = filtro.ContarPuntos(rs),
                    label = "RS"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            //Obtenemos Calle
            foreach (var c1 in CALLE_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(c1),
                    textKind = filtro.TipoDeCadena(c1),
                    textNumbers = filtro.ContarDigitos(c1),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(c1),
                    textCharsMin = filtro.ContarLetrasMinusculas(c1),
                    textCharsMay = filtro.ContarLetrasMayusculas(c1),
                    textWhiteSpaces = filtro.ContarEspacios(c1),
                    textDotSpaces = filtro.ContarPuntos(c1),
                    label = "CALLE"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            //Obtenemos Municipio
            foreach (var m1 in MUNICIPIO_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(m1),
                    textKind = filtro.TipoDeCadena(m1),
                    textNumbers = filtro.ContarDigitos(m1),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(m1),
                    textCharsMin = filtro.ContarLetrasMinusculas(m1),
                    textCharsMay = filtro.ContarLetrasMayusculas(m1),
                    textWhiteSpaces = filtro.ContarEspacios(m1),
                    textDotSpaces = filtro.ContarPuntos(m1),
                    label = "MUNICIPIO"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            //Obtenemos Estado
            foreach (var m1 in ESTADO_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(m1),
                    textKind = filtro.TipoDeCadena(m1),
                    textNumbers = filtro.ContarDigitos(m1),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(m1),
                    textCharsMin = filtro.ContarLetrasMinusculas(m1),
                    textCharsMay = filtro.ContarLetrasMayusculas(m1),
                    textWhiteSpaces = filtro.ContarEspacios(m1),
                    textDotSpaces = filtro.ContarPuntos(m1),
                    label = "ESTADO"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            //Obtenemos CP
            foreach (var cp in CP_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(cp),
                    textKind = filtro.TipoDeCadena(cp),
                    textNumbers = filtro.ContarDigitos(cp),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(cp),
                    textCharsMin = filtro.ContarLetrasMinusculas(cp),
                    textCharsMay = filtro.ContarLetrasMayusculas(cp),
                    textWhiteSpaces = filtro.ContarEspacios(cp),
                    textDotSpaces = filtro.ContarPuntos(cp),
                    label = "CP"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            //Obtenemos Clave del bien transportado
            foreach (var clave in CLAVEDBIENTRASNP_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(clave),
                    textKind = filtro.TipoDeCadena(clave),
                    textNumbers = filtro.ContarDigitos(clave),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(clave),
                    textCharsMin = filtro.ContarLetrasMinusculas(clave),
                    textCharsMay = filtro.ContarLetrasMayusculas(clave),
                    textWhiteSpaces = filtro.ContarEspacios(clave),
                    textDotSpaces = filtro.ContarPuntos(clave),
                    label = "CLAVEBIENTRASNPORTADO"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            //Obtenemos clave unidad de medida
            foreach (var claveU in CLAVEUNIDADMEDIDA_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(claveU),
                    textKind = filtro.TipoDeCadena(claveU),
                    textNumbers = filtro.ContarDigitos(claveU),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(claveU),
                    textCharsMin = filtro.ContarLetrasMinusculas(claveU),
                    textCharsMay = filtro.ContarLetrasMayusculas(claveU),
                    textWhiteSpaces = filtro.ContarEspacios(claveU),
                    textDotSpaces = filtro.ContarPuntos(claveU),
                    label = "CLAVEMEDIDA"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            //  Obtenemos Descripcion
            foreach (var descr in DESCRIPCIONDELBIENTRASNP_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(descr),
                    textKind = filtro.TipoDeCadena(descr),
                    textNumbers = filtro.ContarDigitos(descr),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(descr),
                    textCharsMin = filtro.ContarLetrasMinusculas(descr),
                    textCharsMay = filtro.ContarLetrasMayusculas(descr),
                    textWhiteSpaces = filtro.ContarEspacios(descr),
                    textDotSpaces = filtro.ContarPuntos(descr),
                    label = "DESCRIPCION"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }


            //  Obtenemos Fraccion aranc
            foreach (var frac in FRACCIONARANC_list)
            {
                MLData newData = new MLData
                {
                    textTotalLength = filtro.ContarCaracteres(frac),
                    textKind = filtro.TipoDeCadena(frac),
                    textNumbers = filtro.ContarDigitos(frac),
                    textOnlyChar = filtro.ContarCaracteresExcluyendoNumeros(frac),
                    textCharsMin = filtro.ContarLetrasMinusculas(frac),
                    textCharsMay = filtro.ContarLetrasMayusculas(frac),
                    textWhiteSpaces = filtro.ContarEspacios(frac),
                    textDotSpaces = filtro.ContarPuntos(frac),
                    label = "FRACCIONARAN"
                };

                // Agregar el nuevo objeto a la lista FINAL_DATA
                FINAL_DATA.Add(newData);
            }

            guardarCSV(FINAL_DATA);

        }

        public void guardarCSV(List<MLData> registros)
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "data.csv");

            // Escribe los registros en el archivo CSV sin incluir los nombres de las columnas
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (MLData data in registros)
                {
                    string line = 
                        $"{data.textTotalLength}," +
                        $"{data.textKind}," +
                        $"{data.textNumbers}," +
                        $"{data.textOnlyChar}," +
                        $"{data.textCharsMin}," +
                        $"{data.textCharsMay}," +
                        $"{data.textWhiteSpaces}," +
                        $"{data.textDotSpaces}," +
                        $"{data.label}";

                    writer.WriteLine(line);
                }
            }

            // Mensaje de confirmación
            Console.WriteLine("Registros guardados en el archivo CSV.");
        }
    }
}
