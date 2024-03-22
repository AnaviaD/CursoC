using excelFiles.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace excelFiles.MLModels
{
    public class getValues
    {
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
            public int textCharsMin { get; set; }
            public int textCharsMay { get; set; }
            public int textWhiteSpaces { get; set; }
            public string label { get; set; }
        }

        public getValues()
        {
            this.CargarConexion(constantes._xServidorBD, constantes._xNombreBD, constantes._xUsuarioBD, constantes._xPassWordBD);
            this.CargarConexion2(constantes._xServidorBD2, constantes._xNombreBD2, constantes._xUsuarioBD2, constantes._xPassWordBD2);
        }

        private void CargarConexion(string _xServerName, string _xNombreBD, string _xUser, string _xPassword)
        {
            this._xConnString.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; User Id={2}; Password = {3};", new object[] { _xServerName, _xNombreBD, _xUser, _xPassword });
        }
        private void CargarConexion2(string _xServerName, string _xNombreBD, string _xUser, string _xPassword)
        {
            this._xConnString2.ConnectionString = string.Format("data source = {0}; initial catalog = {1}; User Id={2}; Password = {3};", new object[] { _xServerName, _xNombreBD, _xUser, _xPassword });
        }

        public DataTable ObtenerTabla()
        {
            DataTable dat = new DataTable();
            try
            {
                DataTable dt = new DataTable();
                string sentencia = string.Format("SELECT TOP (1000) * FROM x_FTR.dbo.TB_MERCANCIAS_CLIENTE");
                this._xConnString.Open();

                SqlDataAdapter dataAda = new SqlDataAdapter(sentencia, this._xConnString);
                dataAda.Fill(dt);

                
            }
            catch (Exception e)
            {
                escribirEnLog.Add(string.Format("{0} - Problemas al obtener catalogos los archivos." + e.Message + "VerificaMercanciasClientes", DateTime.Now));

            }
            finally
            {
                this._xConnString.Close();
            }

            return dat;
        }

        public void ObtenerColumnas(DataTable dt)
        {
            List<string> RFCREMITENTE_list = new List<string>();
            List<string> CALLE_list = new List<string>();
            List<string> MUNICIPIO_list = new List<string>();
            List<string> CP_list = new List<string>();

            // Itera sobre las filas del DataTable
            foreach (DataRow row in dt.Rows)
            {
                // Extrae los valores de las columnas específicas y los agrega a las listas correspondientes
                RFCREMITENTE_list.Add(row["RFCREMITENTE"].ToString());
                CALLE_list.Add(row["CALLE"].ToString());
                MUNICIPIO_list.Add(row["MUNICIPIO"].ToString());
                CP_list.Add(row["CP"].ToString());
            }


            //Aqui mandamos a evaluar todas las listas 

        }

        public void guardarCSV(List<MLData> registros)
        {
            
            // Ruta donde se guardará el archivo CSV
            string filePath = "data.csv";

            // Escribe los registros en el archivo CSV sin incluir los nombres de las columnas
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (MLData data in registros)
                {
                    string line = $"{data.textTotalLength},{data.textKind},{data.textNumbers},{data.textCharsMin},{data.textCharsMay},{data.textWhiteSpaces},{data.label}";
                    writer.WriteLine(line);
                }
            }

            // Mensaje de confirmación
            Console.WriteLine("Registros guardados en el archivo CSV.");
        }
    }
}
