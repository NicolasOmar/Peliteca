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
    public partial class BuscarPais : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public BuscarPais()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnBuscar_Click(this, e);
            else
                Sesion.BloquearTeclas(e, "letras");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtPais.TextLength == 0)            
            {
                MessageBox.Show("No ha escrito ninguna letra o palabra con que realizar la busqueda de paises", "Error de Busqueda", MessageBoxButtons.OK);
                txtPais.Clear();
                txtPais.Focus();
            }
            else
                HacerBusqueda(true);
        }

        private void btnTodos_Click(object sender, EventArgs e)
        { HacerBusqueda(false); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPaises(), 0, null); }

        

        private void HacerBusqueda(bool X)
        {
            if (X)
            {

                Sesion.ListPais = Sesion.ListPais.Where(P => P.nombre.ToLower().Contains(txtPais.Text.ToLower())).ToList();
                if(Sesion.ListPais.Count > 0)
                {
                    Sesion.setIntance();
                    Sesion.CambiarMenu(this, new ListaPaises(), 0, null);
                }
                else
                {
                    MessageBox.Show("No ha escrito ninguna letra o palabra con que realizar la busqueda de paises", "Error de Busqueda", MessageBoxButtons.OK);
                    txtPais.Clear();
                    txtPais.Focus();
                }
            }
            else
                Sesion.CambiarMenu(this, new ListaPaises(), 0, null);
        }
    }
}
