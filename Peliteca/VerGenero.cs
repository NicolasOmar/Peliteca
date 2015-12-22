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
    public partial class VerGenero : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public VerGenero()
        {
            InitializeComponent();
            lblGenero.Text += Sesion.GeneroMod.genero;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtGenero_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtGenero.TextLength > 0 && !txtGenero.Text.Equals(Sesion.GeneroMod.genero))
            {
                using(DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    Generos GeneroBD = DataBase.Generos.Single(G => G.genero.Equals(Sesion.GeneroMod.genero));
                    GeneroBD.genero = Sesion.NormalizarNombres(txtGenero.Text);
                    DataBase.SubmitChanges();

                    Sesion.GeneroMod = new Genero(GeneroBD);
                    Sesion.AcomodarLista(Sesion.ListGender.Cast<Object>().ToList(), (Object)Sesion.GeneroMod, "generos");
                    Sesion.setIntance();

                    Sesion.CambiarMenu(this, new ListaGeneros(), 0, null);
                }
            }
            else
            { MessageBox.Show("No ingreso el nuevo nombre del genero o el mismo es igual al nombre que tiene actualmente", "Error de Modificacion", MessageBoxButtons.OK); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ListaGeneros(), 0, null); }
    }
}
