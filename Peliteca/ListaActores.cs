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
    public partial class ListaActores : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public ListaActores()
        {
            InitializeComponent();
            CargarTabla();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new BuscarActor(), 0, null); }

        private void btnAdd_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new AgregarActor(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null); }

        private void CargarTabla()
        {
            DataTable tablaBase = new DataTable();
            tablaBase.Columns.Add(new DataColumn("Nombre"));
            tablaBase.Columns.Add(new DataColumn("Apellido"));
            tablaBase.Columns.Add(new DataColumn("Genero"));
            tablaBase.Columns.Add(new DataColumn("F. Nacmiento"));

            foreach(Actor Actor in Sesion.ListActor)
            {
                tablaBase.Rows.Add(
                    Actor.nombre,
                    Actor.apellido,
                    Actor.SexoString(),
                    Actor.nacimiento.Day + "/" + Actor.nacimiento.Month + "/" + Actor.nacimiento.Year);
            }

            dgvActores.DataSource = tablaBase;
            dgvActores.RowHeadersVisible = false;
            dgvActores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvActores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                { Sesion.ActorMod = new Actor(DataBase.Actores.Single(Ac => Ac.nomActor.Equals(Convert.ToString(dgvActores.Rows[e.RowIndex].Cells[0].Value)) && Ac.apeActor.Equals(Convert.ToString(dgvActores.Rows[e.RowIndex].Cells[1].Value)))); }
                Sesion.setIntance();
                Sesion.CambiarMenu(this, new VerActor(), 0, null);
            }
            catch
            { }
        }
    }
}
