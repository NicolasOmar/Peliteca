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
    public partial class VerActor : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public VerActor()
        {
            InitializeComponent();
            CargarActor();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ModificarActor(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ListaActores(), 0, null); }

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            using (DbAccessDataContext DataBase = new DbAccessDataContext())
            {
                List<PeliActor> ListaPA = DataBase.PeliActor.Where(PA => PA.idActor == Sesion.ActorMod.id).ToList();
                List<PeliPais> EnlacePaises = new List<PeliPais>();
                List<Paises> ListaP = new List<Paises>();
                List<Actores> ListaA = new List<Actores>();

                foreach (PeliActor PA in ListaPA)
                {
                    Peliculas PeliBD = DataBase.Peliculas.Single(P => P.idPeli == PA.idPeli);

                    List<PeliActor> EnlaceActores = DataBase.PeliActor.Where(EA => EA.idPeli == PeliBD.idPeli).ToList();
                    EnlacePaises = DataBase.PeliPais.Where(PP => PP.idPeli == PeliBD.idPeli).ToList();

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
                MessageBox.Show(Sesion.ActorMod.nomApe + " no formo parte del reparto de ninguna de las peliculas registradas en la base de datos", "Error de Busqueda", MessageBoxButtons.OK);
        }

        private void CargarActor()
        {
            if (Sesion.ActorMod.sexo)
                grpActor.Text = "Datos del Actor:";
            else
                grpActor.Text = "Datos de la Actriz:";
            lblNombre.Text += Sesion.ActorMod.nombre;
            lblApellido.Text += Sesion.ActorMod.apellido;
            lblSexo.Text += Sesion.ActorMod.SexoString();
            lblNacimiento.Text += Sesion.ActorMod.nacimiento.Day + "/" + Sesion.ActorMod.nacimiento.Month + "/" + Sesion.ActorMod.nacimiento.Year;
        }
    }
}
