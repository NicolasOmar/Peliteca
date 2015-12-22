using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peliteca
{
    public partial class AccesoSistema : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(true);

        public AccesoSistema()
        {
            InitializeComponent();
            Limpiar();
            Sesion.getIntance();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
                IngresarDatos();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        { IngresarDatos(); }

        private void btnSalir_Click(object sender, EventArgs e)
        { Application.Exit(); }

        //METODOS PARA AHORRAR CODIGO
        private void IngresarDatos()
        {
            using (DbAccessDataContext DataBase = new DbAccessDataContext())
            {
                List<Usuarios> UserList = DataBase.Usuarios.ToList();
                foreach (Usuarios UserBD in UserList)
                    Sesion.User = new Usuario(UserBD);
            }

            if (txtUser.Text.Equals(Sesion.User.nombre) && txtPass.Text.Equals(Sesion.User.pass))
            {
                MessageBox.Show("Bienvenido al sistema Papá", "Ingreso al Sistema", MessageBoxButtons.OK);
                Sesion.setIntance();
                MenuPrincipal NewMenu = new MenuPrincipal();
                NewMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("El usuario ingresado no coincide con el existente en la Base de Datos", "Error de Ingreso", MessageBoxButtons.OK);
                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtUser.Clear();
            txtPass.Clear();
            txtPass.PasswordChar = '*';
            txtUser.Focus();
        }
    }
    //Data Source=OMAR-PC\SQL-EXPRESS;Initial Catalog=Peliteca;Integrated Security=True
}
