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
    public partial class MenuPaises : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public MenuPaises()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new BuscarPais(), 0, null); }

        private void btnAdd_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new AgregarPais(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null); }
    }
}
