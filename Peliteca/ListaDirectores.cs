using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peliteca
{
    public partial class ListaDirectores : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public ListaDirectores()
        {
            InitializeComponent();
            CargarTabla();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new BuscarDirector(), 0, null); }

        private void btnAdd_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new AgregarDirector(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null); }

        void CargarTabla()
        {
            DataTable tablaBase = new DataTable();
            tablaBase.Columns.Add(new DataColumn("Nombre"));
            tablaBase.Columns.Add(new DataColumn("Apellido"));
            tablaBase.Columns.Add(new DataColumn("F. Nacimiento"));

            foreach(Director Direc in Sesion.ListDirec)
            {
                tablaBase.Rows.Add(
                    Direc.nombre,
                    Direc.apellido,
                    Direc.nacimiento.Day + "/" + Direc.nacimiento.Month + "/" + Direc.nacimiento.Year);
            }

            dgvDirectores.DataSource = tablaBase;
            dgvDirectores.RowHeadersVisible = false;
            dgvDirectores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDirectores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvDirectores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                { Sesion.DirectorMod = new Director(DataBase.Directores.Single(Dir => Dir.nomDirec.Equals(Convert.ToString(dgvDirectores.Rows[e.RowIndex].Cells[0].Value)) && Dir.apeDirec.Equals(Convert.ToString(dgvDirectores.Rows[e.RowIndex].Cells[1].Value)))); }
                Sesion.setIntance();
                Sesion.CambiarMenu(this, new VerDirector(), 0, null);
            }
            catch
            { }
        }
    }
}
