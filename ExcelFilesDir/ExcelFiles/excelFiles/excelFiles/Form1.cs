using excelFiles.Helpers;
using excelFiles.MLModels;
using System.Data;

namespace excelFiles
{
    public partial class Form1 : Form
    {
        lectorMaestro   lector      = new lectorMaestro();
        getValues       recolector  = new getValues();

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
                DataTable dirtyTable = new DataTable();
                dirtyTable = lector.ProcesoExcelM(archivo);
                lector.BuscarEnTabla(dirtyTable);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recolector.ObtenerColumnas( recolector.ObtenerTabla());
        }
    }
}
