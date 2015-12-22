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
    public partial class ModificarUser : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public ModificarUser()
        {
            InitializeComponent();
            CargarDatos();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtPass1_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letrasNumeros"); }

        private void txtPass2_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letrasNumeros"); }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtPass1.TextLength > 0 
                && txtPass1.Text.Equals(txtPass2.Text) 
                && !txtPass1.Text.Equals(Sesion.User.pass))
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    Usuarios UserBD = DataBase.Usuarios.Single(U => U.nomUser.Equals(Sesion.User.nombre));
                    if (MessageBox.Show("Esta seguro de cambiar la contraseña de usuario de --" + Sesion.User.pass + "-- a --" + txtPass1.Text + "--?", "Confirmar Modificacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        UserBD.passUser = txtPass1.Text;
                        DataBase.SubmitChanges();

                        Sesion.User = new Usuario(UserBD);
                        Sesion.setIntance();

                        MessageBox.Show("Se ha cambiado la contraseña de acceso al sistema", "Cambio de Contraseña", MessageBoxButtons.OK);
                        Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null);
                    }
                }
            }
            else
                MessageBox.Show("No ha ingresado la nueva contraseña 2 veces o no coinciden entre si", "Error de Modificación", MessageBoxButtons.OK);

            Limpiar();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null); }

        void CargarDatos()
        {
            lblUser.Text += Sesion.User.nombre;
            lblPass.Text += Sesion.User.pass;
            txtPass1.PasswordChar = '*';
            txtPass1.MaxLength = 15;
            txtPass2.PasswordChar = '*';
            txtPass2.MaxLength = 15;
            txtPass1.Focus();
        }

        void Limpiar()
        {
            txtPass1.Clear();
            txtPass2.Clear();
            txtPass1.Focus();
        }
    }
}
