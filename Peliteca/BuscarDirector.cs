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
    public partial class BuscarDirector : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public BuscarDirector()
        {
            InitializeComponent();
            SetControles();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(true);
            else
                Sesion.BloquearTeclas(e, "letras");
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(true);
            else
                Sesion.BloquearTeclas(e, "letras");
        }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(true);
            else
                Sesion.BloquearTeclas(e, "letras");
        }

        private void btnTodos_Click(object sender, EventArgs e)
        { HacerBusqueda(false); }

        private void btnBuscar_Click(object sender, EventArgs e)
        { HacerBusqueda(true); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuDirectores(), 0, null); }

        void HacerBusqueda(bool X)
        {
            List<Directores> Lista = new List<Directores>();
            Sesion.ListDirec.Clear();
            if(X)
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    bool bandera = false;

                    if (txtNombre.TextLength > 0)
                    {
                        bandera = true;
                        Lista = DataBase.Directores.Where(D => D.nomDirec.ToLower().Contains(txtNombre.Text.ToLower())).ToList();
                    }

                    if (txtApellido.TextLength > 0)
                    {
                        if (bandera)
                            Lista = Lista.Where(D => D.apeDirec.ToLower().Contains(txtApellido.Text.ToLower())).ToList();
                        else
                        {
                            Lista = DataBase.Directores.Where(D => D.apeDirec.ToLower().Contains(txtApellido.Text.ToLower())).ToList();
                            bandera = true;
                        }
                    }

                    if (dtpNacido1.Value < dtpNacido2.Value && dtpNacido2.Value <= DateTime.Today)
                    {
                        if (bandera)
                            Lista = Lista.Where(Ac => Ac.fecNac >= dtpNacido1.Value && Ac.fecNac <= dtpNacido2.Value).ToList();
                        else
                        {
                            Lista = DataBase.Directores.Where(Ac => Ac.fecNac >= dtpNacido1.Value && Ac.fecNac <= dtpNacido2.Value).ToList();
                            bandera = true;
                        }
                    }

                    if (Lista.Count > 0)
                    {
                        foreach (Directores DirectorBD in Lista)
                            Sesion.ListDirec.Add(new Director(DirectorBD));

                        Sesion.setIntance();
                        Sesion.CambiarMenu(this, new ListaDirectores(), 0, null);
                    }
                    else
                    {
                        MessageBox.Show("No se han encontrado directores en la base de datos con los parametros que ingreso", "Error de Busqueda", MessageBoxButtons.OK);
                        txtNombre.Focus();
                    }      
                }
            }
            else
            {
                using(DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    Lista = DataBase.Directores.ToList();
                    foreach (Directores DirectorBD in Lista)
                        Sesion.ListDirec.Add(new Director(DirectorBD));
                }

                Sesion.setIntance();
                Sesion.CambiarMenu(this, new ListaDirectores(), 0, null);
            }
        }

        void SetControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtpNacido1.Value = DateTime.Today;
            dtpNacido2.Value = DateTime.Today;
            txtNombre.Focus();
        }

        private bool BuscarCoincidencia(TextBox Caja, string[] ArrayNombres)
        {
            bool flag = false;

            foreach (string nombre in ArrayNombres)
            {
                if (Caja.Text.Equals(nombre) || Caja.Text.Equals(""))
                    flag = true;
            }

            return flag;
        }
    }
}
