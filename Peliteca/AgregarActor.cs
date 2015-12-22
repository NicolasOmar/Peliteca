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
    public partial class AgregarActor : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);
        bool bandera = false;

        public AgregarActor()
        {
            InitializeComponent();
            CargarDatos();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void rbtHombre_CheckedChanged(object sender, EventArgs e)
        { CambiarRegistrar(rbtHombre, true); }

        private void rbtMujer_CheckedChanged(object sender, EventArgs e)
        { CambiarRegistrar(rbtMujer, false); }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!txtNombre.Text.Equals("")
                && !txtApellido.Text.Equals("")
                && (rbtHombre.Checked || rbtMujer.Checked)
                && dtpNacimiento.Value <= DateTime.Today)
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    if (!BuscarActor(txtNombre.Text + " " + txtApellido.Text, DataBase.Actores.Select(A => A.nomActor + " " + A.apeActor).ToArray()))
                    {
                        Actores NuevoActor = new Actores();
                        NuevoActor.nomActor = Sesion.NormalizarNombres(txtNombre.Text);
                        NuevoActor.apeActor = Sesion.NormalizarNombres(txtApellido.Text);
                        if (rbtHombre.Checked)
                            NuevoActor.sexo = true;
                        else
                            NuevoActor.sexo = false;
                        NuevoActor.fecNac = dtpNacimiento.Value;

                        DataBase.Actores.InsertOnSubmit(NuevoActor);
                        DataBase.SubmitChanges();
                        
                        Sesion.ListActor.Add(new Actor(NuevoActor));
                        Sesion.setIntance();

                        NuevoActor = null;

                        Sesion.SetRuta(this, new ListaActores(), Sesion.cambio);
                    }
                    else
                    { MessageBox.Show("Ya hay un actor/actriz con el nombre y apellido que quiso ingresar, intentelo de nuevo con otro nombre/apellido", "Error de Registro", MessageBoxButtons.OK); }
                }
            }
            else
            { MessageBox.Show("Los datos ingresados estan incompletos o son erroneos, intente nuevamente", "Error de Registro", MessageBoxButtons.OK); }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.SetRuta(this, new MenuActores(), Sesion.cambio); }

        private void CambiarRegistrar(RadioButton Check, bool X)
        {
            if (X)
            {
                btnRegistrar.Text = "Registrar Actor";
                grpAdd.Text = "Datos del Nuevo Actor";
            }
            else
            {
                btnRegistrar.Text = "Registrar Actriz";
                grpAdd.Text = "Datos de la Nueva Actriz";
            }
        }

        private bool BuscarActor(String NomApe, string[] ArrayNombres)
        {
            bool flag = false;

            foreach (string nombre in ArrayNombres)
            {
                if (NomApe.Equals(nombre) || NomApe.Equals(""))
                    flag = true;
            }

            return flag;
        }
        
        private void CargarDatos()
        {
            txtNombre.Text = "";            
            txtApellido.Text = "";
            rbtHombre.Checked = false;
            rbtMujer.Checked = false;
            dtpNacimiento.Value = DateTime.Today;
            grpAdd.Text = "Datos del Nuevo Actor/Actriz";
            btnRegistrar.Text = "Registrar Actor/Actriz";
            txtNombre.Focus();
        }

        private void AgregarActor_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && bandera)
            {
                Sesion = new UnicaInstancia(false);
                txtNombre.Focus();
            }
            bandera = true;
        }
    }
}
