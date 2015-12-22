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
    public partial class ListaPeliculas : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);
        bool bandera = false;

        public ListaPeliculas()
        {
            InitializeComponent();
            CargarTabla();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new BuscarPelicula(), 0, null); }

        private void btnAdd_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new AgregarPelicula(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null); }

        private void CargarTabla()
        {
            DataTable tablaBase = new DataTable();
            tablaBase.Columns.Add(new DataColumn("Titulo"));
            tablaBase.Columns.Add(new DataColumn("Director"));
            tablaBase.Columns.Add(new DataColumn("Reparto"));
            tablaBase.Columns.Add(new DataColumn("Año"));
            tablaBase.Columns.Add(new DataColumn("Paises"));
            tablaBase.Columns.Add(new DataColumn("Genero"));
            tablaBase.Columns.Add(new DataColumn("Duracion"));
            
            foreach (Pelicula Peli in Sesion.ListPeli)
            {
                tablaBase.Rows.Add(
                    Peli.titulo,
                    Peli.director,
                    GetActores(Peli),
                    Peli.anio,
                    Peli.paises.Count,
                    Peli.genero,
                    Peli.duracion + " min.");                
            }

            dgvPeliculas.DataSource = tablaBase;
            dgvPeliculas.RowHeadersVisible = false;
            dgvPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeliculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvPeliculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    Peliculas Peli = DataBase.Peliculas.Single(P => P.titulo.Equals(Convert.ToString(dgvPeliculas.Rows[e.RowIndex].Cells[0].Value)));
                    List<PeliActor> EnlaceActores = DataBase.PeliActor.Where(PA => PA.idPeli == Peli.idPeli).ToList();
                    List<Actores> PeliActores = new List<Actores>();
                    List<PeliPais> EnlacePaises = DataBase.PeliPais.Where(PP => PP.idPeli == Peli.idPeli).ToList();
                    List<Paises> PeliPaises = new List<Paises>();

                    foreach (PeliActor Enlace in EnlaceActores)
                        PeliActores.Add(DataBase.Actores.Single(Actor => Actor.idActor == Enlace.idActor));
                    EnlaceActores = null;

                    foreach (PeliPais Enlace in EnlacePaises)
                        PeliPaises.Add(DataBase.Paises.Single(Pais => Pais.idPais == Enlace.idPais));
                    EnlacePaises = null;

                    Sesion.PeliMod = new Pelicula(Peli, PeliActores, PeliPaises);
                    PeliActores = null;
                    PeliPaises = null;
                }

                Sesion.setIntance();

                Sesion.CambiarMenu(this, new VerPelicula(), 0, null);
            }
            catch
            { }
        }

        private void ListaPeliculas_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && bandera)
            {
                Sesion = new UnicaInstancia(false);
                CargarTabla();
            }
            bandera = true;
        }

        private string GetActores(Pelicula Peli)
        {
            if(Peli.actores.Count == 1)
                return Convert.ToString(Peli.actores.Count) + " Actor";
            else
                return Convert.ToString(Peli.actores.Count) + " Actores";
        }
    }
}
