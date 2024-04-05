using excelFiles.Helpers;
using excelFiles.MLModels;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace excelFiles
{
    public partial class Form1 : Form
    {
        lectorMaestro lector = new lectorMaestro();
        makingDataTable makingDataTable = new makingDataTable();
        getValues recolector = new getValues();
        engineML MLEng = new engineML();
        useModelEngine engineML = new useModelEngine();

        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {

            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);


            string[] archivosXLSX = Array.FindAll(archivos, s => s.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase));

            // Iterar sobre los archivos .xlsx y pasar la dirección a la función lector
            foreach (string archivo in archivosXLSX)
            {
                List<string> objetosJson = new List<string>();
                DataTable dirtyTable = new DataTable();
                DataTable cleanTable = new DataTable();

                dirtyTable = lector.ProcesoExcelM(archivo);

                objetosJson = lector.BuscarEnTabla(dirtyTable);

                if (objetosJson.IsNullOrEmpty()) { }
                else
                {
                    cleanTable = makingDataTable.formList(objetosJson);
                }

                dtOutput.DataSource = cleanTable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recolector.ObtenerColumnas(recolector.ObtenerTabla());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MLEng.startEngine();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            lblResult.Text = engineML.startPrediction(txtPredict.Text);
        }

        private void dtOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
