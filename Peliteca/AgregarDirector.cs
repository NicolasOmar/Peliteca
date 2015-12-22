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
    public partial class AgregarDirector : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public AgregarDirector()
        {
            InitializeComponent();
            CargarForm();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }
        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(!txtNombre.Text.Equals("")
                && !txtApellido.Text.Equals("")
                && dtpNacimiento.Value <= DateTime.Today)
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    txtNombre.Text = Sesion.NormalizarNombres(txtNombre.Text);
                    txtApellido.Text = Sesion.NormalizarNombres(txtApellido.Text);
                    if(!BuscarDirector(txtNombre.Text + " " + txtApellido.Text, DataBase.Directores.Select(D => D.nomDirec + " " + D.apeDirec).ToArray()))
                    {
                        Directores NuevoDirector = new Directores();
                        NuevoDirector.nomDirec = txtNombre.Text;
                        NuevoDirector.apeDirec = txtApellido.Text;
                        NuevoDirector.fecNac= dtpNacimiento.Value;

                        DataBase.Directores.InsertOnSubmit(NuevoDirector);
                        DataBase.SubmitChanges();
                        
                        NuevoDirector = null;
                        Sesion.ListDirec.Clear();

                        foreach (Directores D in DataBase.Directores.ToList())
                            Sesion.ListDirec.Add(new Director(D));
                        Sesion.ListDirec = Sesion.ListDirec.OrderBy(D => D.nomApe).ToList();
                        Sesion.setIntance();

                        Sesion.SetRuta(this, new MenuDirectores(), Sesion.cambio);
                    }
                    else
                    { 
                        MessageBox.Show("Ya hay un director registrado con los datos que ingreso, intentelo de nuevo con otro nombre/apellido","Error de Registro",MessageBoxButtons.OK);
                        txtNombre.Focus();
                    }
                }
            }
            else
            { 
                MessageBox.Show("Los datos ingresados estan incompletos o equivocados, intente nuevamente", "Error de Registro", MessageBoxButtons.OK);
                txtNombre.Focus();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.SetRuta(this, new MenuDirectores(), Sesion.cambio); }

        private void CargarForm()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtpNacimiento.Value = DateTime.Today;
        }

        private bool BuscarDirector(String NomApe, string[] ArrayNombres)
        {
            bool flag = false;

            foreach (string nombre in ArrayNombres)
            {
                if (NomApe.Equals(nombre) || NomApe.Equals(""))
                    flag = true;
            }

            return flag;
        }
    }
}
