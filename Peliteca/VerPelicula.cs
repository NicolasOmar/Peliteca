using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peliteca
{
    public partial class VerPelicula : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public VerPelicula()
        {
            InitializeComponent();
            CargarPelicula();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ModificarPelicula(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ListaPeliculas(), 0, null); }

        private void btnPrincipal_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null); }

        void CargarPelicula()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTitulo.Text += Sesion.PeliMod.titulo;
            lblDirector.Text += Sesion.PeliMod.director;

            foreach (Actor Actor in Sesion.PeliMod.actores)
            { lblReparto.Text += System.Environment.NewLine + " + " + Actor.nombre + " " + Actor.apellido; }

            for(int i = 0; i<Sesion.PeliMod.paises.Count; i ++)
                lblPaises.Text += System.Environment.NewLine + " + " + Sesion.PeliMod.paises.ElementAt(i).nombre;

            lblGenero.Text += Sesion.PeliMod.genero;
            lblAnio.Text += Convert.ToString(Sesion.PeliMod.anio);
            lblDuracion.Text += Convert.ToSingle(Sesion.PeliMod.duracion) + " min.";

            if (Sesion.PeliMod.foto != null)
            {
                byte[] imgArray = Sesion.PeliMod.foto;
                MemoryStream memoria = new MemoryStream(imgArray);
                ptbPelicula.Image = Image.FromStream(memoria);
                ptbPelicula.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
