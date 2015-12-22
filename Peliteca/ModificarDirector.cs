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
    public partial class ModificarDirector : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public ModificarDirector()
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
                && dtpNacido.Value < DateTime.Today)
            {
                using(DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    Directores DirectorBD = DataBase.Directores.Single(D => D.idDirec == Sesion.DirectorMod.id);

                    if (!txtNombre.Text.Equals(DirectorBD.nomDirec))
                        DirectorBD.nomDirec = Sesion.NormalizarNombres(txtNombre.Text);

                    if (!txtApellido.Text.Equals(DirectorBD.apeDirec))
                        DirectorBD.apeDirec = Sesion.NormalizarNombres(txtApellido.Text);

                    if (dtpNacido.Value != DirectorBD.fecNac)
                        DirectorBD.fecNac = dtpNacido.Value;

                    DataBase.SubmitChanges();

                    Sesion.DirectorMod = new Director(DataBase.Directores.Single(D => D.idDirec == Sesion.DirectorMod.id));
                    Sesion.AcomodarLista(Sesion.ListDirec.Cast<Object>().ToList(), (Object)Sesion.DirectorMod, "directores");

                    DirectorBD = null;
                    Sesion.setIntance();

                    MessageBox.Show("El Director ha sido modificado correctamente", "Director Modificado", MessageBoxButtons.OK);
                    Sesion.CambiarMenu(this, new VerDirector(), 0, null);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new VerDirector(), 0, null); }

        private void CargarDatos()
        {
            txtNombre.Text = Sesion.DirectorMod.nombre;
            txtApellido.Text = Sesion.DirectorMod.apellido;
            dtpNacido.Value = Sesion.DirectorMod.nacimiento;
        }
    }
}
