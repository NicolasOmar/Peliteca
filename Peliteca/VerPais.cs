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
    public partial class VerPais : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public VerPais()
        {
            InitializeComponent();
            lblPais.Text += Sesion.PaisMod.nombre;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtGenero_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtPais.TextLength > 0 && !txtPais.Text.Equals(Sesion.PaisMod.nombre))
            {
                using(DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    Paises PaisBD = DataBase.Paises.Single(P => P.pais.Equals(Sesion.PaisMod.nombre));
                    PaisBD.pais = Sesion.NormalizarNombres(txtPais.Text);
                    DataBase.SubmitChanges();

                    Sesion.PaisMod = new Pais(PaisBD);
                    Sesion.AcomodarLista(Sesion.ListPais.Cast<Object>().ToList(), (Object)Sesion.PaisMod, "paises");
                    Sesion.setIntance();

                    Sesion.CambiarMenu(this, new ListaPaises(), 0, null);
                }
            }
            else
            { MessageBox.Show("No ingreso el nuevo nombre del pais o el mismo es igual al nombre que tiene actualmente", "Error de Modificacion", MessageBoxButtons.OK); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new ListaPaises(), 0, null); }
    }
}
