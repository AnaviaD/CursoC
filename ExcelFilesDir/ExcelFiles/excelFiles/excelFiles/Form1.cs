using excelFiles.Helpers;
using System.Data;

namespace excelFiles
{
    public partial class Form1 : Form
    {
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
            lectorMaestro lector = new lectorMaestro();

            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);


            string[] archivosXLSX = Array.FindAll(archivos, s => s.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase));

            // Iterar sobre los archivos .xlsx y pasar la dirección a la función lector
            foreach (string archivo in archivosXLSX)
            {
                DataTable dirtyTable = new DataTable();
                dirtyTable = lector.ProcesoExcelM(archivo);
                lector.BuscadorHeaders(dirtyTable);
            }
        }
    }
}
