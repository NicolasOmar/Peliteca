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
    public partial class ModificarActor : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);
        BindingSource AccesoP = new BindingSource();

        public ModificarActor()
        {
            InitializeComponent();
            CargarDatos();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(!txtNombre.Text.Equals("")
                && !txtApellido.Text.Equals("")
                && (rbtHombre.Checked || rbtMujer.Checked)
                && dtpNacimiento.Value < DateTime.Today)
            {
                using (DbAccessDataContext Database = new DbAccessDataContext())
                {
                    Actores ActorBD = Database.Actores.Single(Ac => Ac.idActor == Sesion.ActorMod.id);

                    if (!txtNombre.Text.Equals(ActorBD.nomActor))
                        ActorBD.nomActor = Sesion.NormalizarNombres(txtNombre.Text);

                    if (!txtApellido.Text.Equals(ActorBD.apeActor))
                        ActorBD.apeActor = Sesion.NormalizarNombres(txtApellido.Text);

                    if (getSexo() != ActorBD.sexo)
                        ActorBD.sexo = getSexo();

                    if (dtpNacimiento.Value != ActorBD.fecNac)
                        ActorBD.fecNac = dtpNacimiento.Value;

                    Database.SubmitChanges();

                    Sesion.ActorMod = new Actor(ActorBD);
                    Sesion.AcomodarLista(Sesion.ListActor.Cast<Object>().ToList(), (Object)Sesion.ActorMod, "actores");

                    ActorBD = null;
                    Sesion.setIntance();

                    if (getSexo())
                        MessageBox.Show("El Actor ha sido modificado correctamente", "Actor Modificado", MessageBoxButtons.OK);
                    else
                        MessageBox.Show("La Actriz ha sido modificada correctamente", "Actriz Modificada", MessageBoxButtons.OK);

                    Sesion.CambiarMenu(this, new VerActor(), 0, null);
                }
            }
            else
            { MessageBox.Show("Hay datos faltantes o los mismos estan mal ingresados", "Error de Modificacion", MessageBoxButtons.OK); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new VerActor(), 0, null); }

        private bool getSexo()
        {
            if (rbtHombre.Checked)
                return true;
            else
                return false;
        }

        private void CargarDatos()
        {
            txtNombre.Text = Sesion.ActorMod.nombre;
            txtApellido.Text = Sesion.ActorMod.apellido;
            if (Sesion.ActorMod.sexo)
            {
                rbtHombre.Checked = true;
                rbtMujer.Checked = false;
            }
            else
            {
                rbtHombre.Checked = false;
                rbtMujer.Checked = true;
            }
            dtpNacimiento.Value = Sesion.ActorMod.nacimiento;
        }
    }
}
