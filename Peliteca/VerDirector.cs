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
    public partial class VerDirector : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public VerDirector()
        {
            InitializeComponent();
            CargarDirector();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            using(DbAccessDataContext DataBase = new DbAccessDataContext())
            {
                List<Peliculas> Lista = DataBase.Peliculas.Where(P => P.idDirec == Sesion.DirectorMod.id).ToList();
                List<Paises> ListaP = new List<Paises>();
                List<Actores> ListaA = new List<Actores>();

                foreach (Peliculas PeliBD in Lista)
                {
                    List<PeliActor> EnlaceActores = DataBase.PeliActor.Where(EA => EA.idPeli == PeliBD.idPeli).ToList();
                    List<PeliPais> EnlacePaises = DataBase.PeliPais.Where(PP => PP.idPeli == PeliBD.idPeli).ToList();

                    foreach (PeliActor Enlace in EnlaceActores)
                        ListaA.Add(DataBase.Actores.Single(Actor => Actor.idActor == Enlace.idActor));
                    EnlaceActores = null;

                    foreach (PeliPais Enlace in EnlacePaises)
                        ListaP.Add(DataBase.Paises.Single(Pais => Pais.idPais == Enlace.idPais));
                    EnlacePaises.Clear();

                    Sesion.ListPeli.Add(new Pelicula(PeliBD, ListaA, ListaP));
                    ListaP.Clear();
                    ListaA.Clear();
                }
            }

            if (Sesion.ListPeli.Count > 0)
            {
                Sesion.setIntance();
                Sesion.CambiarMenu(this, new ListaPeliculas(), 0, null);
            }
            else
                MessageBox.Show(Sesion.DirectorMod.nomApe + " no dirigio ninguna de las peliculas registradas en la base de datos", "Error de Busqueda", MessageBoxButtons.OK);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ModificarDirector(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ListaDirectores(), 0, null); }

        void CargarDirector()
        {
            lblNombre.Text += Sesion.DirectorMod.nombre;
            lblApellido.Text += Sesion.DirectorMod.apellido;
            lblNacido.Text += Sesion.DirectorMod.nacimiento.Day + "/" + Sesion.DirectorMod.nacimiento.Month + "/" + Sesion.DirectorMod.nacimiento.Year;
        }
    }
}
