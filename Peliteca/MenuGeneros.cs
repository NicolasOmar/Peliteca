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
    public partial class MenuGeneros : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public MenuGeneros()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new BuscarGenero(), 0, null); }

        private void btnAdd_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new AgregarGenero(), 0, null); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null); }
    }
}
