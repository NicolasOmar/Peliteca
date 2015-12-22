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
    public partial class ListaGeneros : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public ListaGeneros()
        {
            InitializeComponent();
            CargarTabla();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ResetLista();
            Sesion.CambiarMenu(this, new BuscarGenero(), 0, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new AgregarGenero(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            ResetLista();
            Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null);
        }

        private void dgvGeneros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                { Sesion.GeneroMod = new Genero(DataBase.Generos.Single(G => G.genero.Equals(Convert.ToString(dgvGeneros.Rows[e.RowIndex].Cells[0].Value)))); }
                Sesion.setIntance();
                Sesion.CambiarMenu(this, new VerGenero(), 0, null);
            }
            catch
            { }
        }

        private void CargarTabla()
        {
            DataTable tablaBase = new DataTable();
            tablaBase.Columns.Add(new DataColumn("Género"));

            foreach(Genero Gender in Sesion.ListGender)
                tablaBase.Rows.Add(Gender.genero);

            dgvGeneros.DataSource = tablaBase;
            dgvGeneros.RowHeadersVisible = false;
            dgvGeneros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGeneros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ResetLista()
        {
            Sesion.ListGender.Clear();
            using (DbAccessDataContext DataBase = new DbAccessDataContext())
            {
                List<Generos> Lista = DataBase.Generos.OrderBy(G => G.genero).ToList();
                foreach (Generos Gender in Lista)
                    Sesion.ListGender.Add(new Genero(Gender));
            }
            Sesion.setIntance();
        }
    }
}
