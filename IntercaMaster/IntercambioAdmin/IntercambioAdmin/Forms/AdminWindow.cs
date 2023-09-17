using IntercambioAdmin.Clases;
using IntercambioAdmin.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntercambioAdmin.Forms
{
    public partial class AdminWindow : Form
    {
        public AdminWindow()
        {
            InitializeComponent();

            //dgMain.Rows.Add("1351435", "Tablet1", "16/09/2023", "Sin respaldo");

            EquipoTerminal equipo = new EquipoTerminal();
            equipo.deviceId = "123546";
            equipo.terminalName = "Tablet Oficina";
            equipo.terminalType = "Tablet";
            equipo.terminalLastBackUp = DateTime.Now;
            equipoTerminalBindingSource.Add(equipo);

        }

        private async void btnGetAll_Click(object sender, EventArgs e)
        {
            var response = await RestHelper.GetAll();

            txtResponse.Text = response.ToString();
        }

        private void dgMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgMain.Columns[e.ColumnIndex].Name == "btnDwnload")
            {
                txtResponse.Text += "Se esta descargando la base de datos de esta unidad \n";
            }
        }
    }
}
