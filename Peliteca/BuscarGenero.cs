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
    public partial class BuscarGenero : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public BuscarGenero()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnBuscar_Click(this, e);
            else
                Sesion.BloquearTeclas(e, "letras");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtGenero.TextLength == 0)
            {
                MessageBox.Show("No ha escrito ninguna letra o palabra con que realizar la busqueda de generos", "Error de Busqueda", MessageBoxButtons.OK);
                txtGenero.Clear();
                txtGenero.Focus();
            }
            else
                HacerBusqueda(true);
        }

        private void btnTodos_Click(object sender, EventArgs e)
        { HacerBusqueda(false); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuGeneros(), 0, null); }        

        private void HacerBusqueda(bool X)
        {
            if(X)
            {
                
                Sesion.ListGender = Sesion.ListGender.Where(G => G.genero.ToLower().Contains(txtGenero.Text.ToLower())).ToList();
                if (Sesion.ListGender.Count > 0)
                {
                    Sesion.setIntance();
                    Sesion.CambiarMenu(this, new ListaGeneros(), 0, null);
                }
                else
                {
                    MessageBox.Show("No se ha encontrado ningun genero en la base de datos", "Error de Busqueda", MessageBoxButtons.OK);
                    txtGenero.Clear();
                    txtGenero.Focus();
                }
            }
            else
                Sesion.CambiarMenu(this, new ListaGeneros(), 0, null);
        }
    }
}
