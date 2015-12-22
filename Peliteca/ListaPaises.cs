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
    public partial class ListaPaises : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public ListaPaises()
        {
            InitializeComponent();
            CargarTabla();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ResetLista();
            Sesion.CambiarMenu(this, new BuscarPais(), 0, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new AgregarPais(), 0, null); }

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
                { Sesion.PaisMod = new Pais(DataBase.Paises.Single(P => P.pais.Equals(Convert.ToString(dgvPaises.Rows[e.RowIndex].Cells[0].Value)))); }
                Sesion.setIntance();
                Sesion.CambiarMenu(this, new VerPais(), 0, null);
            }
            catch
            { }
        }

        private void CargarTabla()
        {
            DataTable tablaBase = new DataTable();
            tablaBase.Columns.Add(new DataColumn("Pais"));

            foreach(Pais Pais in Sesion.ListPais)
                tablaBase.Rows.Add(Pais.nombre);

            dgvPaises.DataSource = tablaBase;
            dgvPaises.RowHeadersVisible = false;
            dgvPaises.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaises.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ResetLista()
        {
            Sesion.ListPais.Clear();
            using(DbAccessDataContext DataBase = new DbAccessDataContext())
            {
                List<Paises> Lista = DataBase.Paises.OrderBy(P => P.pais).ToList();
                foreach (Paises Pais in Lista)
                    Sesion.ListPais.Add(new Pais(Pais));
            }
            Sesion.setIntance();
        }
    }
}
