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
    public partial class MenuPrincipal : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public MenuPrincipal()
        {
            InitializeComponent();
            Sesion.Limpiar();
            Sesion.setIntance();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnPeli_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPeliculas(), 0, null); }

        private void btnActor_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuActores(), 0, null); } 

        private void btnDirector_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuDirectores(), 0, null); }

        private void btnGender_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuGeneros(), 0, null); }

        private void btnPais_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPaises(), 0, null); }

        private void btnUser_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ModificarUser(), 0, null); }

        private void btnSalir_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new AccesoSistema(), 0, null); }
    }
}
