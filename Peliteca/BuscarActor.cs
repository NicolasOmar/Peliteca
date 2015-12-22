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
    public partial class BuscarActor : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public BuscarActor()
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

        private void cmbGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        { HacerBusqueda(true); }

        private void btnTodos_Click(object sender, EventArgs e)
        { HacerBusqueda(false); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPrincipal(), 0, null); }

        private void HacerBusqueda(bool X)
        {
            List<Actores> Lista = new List<Actores>();
            Sesion.ListActor.Clear();
            if(X)
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    bool bandera = false;

                    if (txtNombre.TextLength > 0)
                    {
                        bandera = true;
                        Lista = DataBase.Actores.Where(Ac => Ac.nomActor.ToLower().Contains(txtNombre.Text)).ToList();
                    }

                    if (txtApellido.TextLength > 0)
                    {
                        if (bandera)
                            Lista = Lista.Where(Ac => Ac.apeActor.ToLower().Contains(txtApellido.Text.ToLower())).ToList();
                        else
                        {
                            Lista = DataBase.Actores.Where(Ac => Ac.apeActor.ToLower().Contains(txtApellido.Text.ToLower())).ToList();
                            bandera = true;
                        }
                    }

                    if (dtpNacido.Value < dtpNacido2.Value && dtpNacido2.Value <= DateTime.Today)
                    {
                        if (bandera)
                            Lista = Lista.Where(Ac => Ac.fecNac >= dtpNacido.Value && Ac.fecNac <= dtpNacido2.Value).ToList();
                        else
                        {
                            Lista = DataBase.Actores.Where(Ac => Ac.fecNac >= dtpNacido.Value && Ac.fecNac <= dtpNacido2.Value).ToList();
                            bandera = true;
                        }
                    }

                    switch (cmbGenero.SelectedIndex)
                    {
                        case -1: break;
                        case 0:
                            if (!bandera)
                            {
                                Lista = DataBase.Actores.ToList();
                                bandera = true;
                            }
                            break;
                        case 1:
                            if (bandera)
                                Lista = Lista.Where(Ac => Ac.sexo == true).ToList();
                            else
                            {
                                Lista = DataBase.Actores.Where(Ac => Ac.sexo == true).ToList();
                                bandera = true;
                            }
                            break;
                        case 2:
                            if (bandera)
                                Lista = Lista.Where(Ac => Ac.sexo == false).ToList();
                            else
                            {
                                Lista = DataBase.Actores.Where(Ac => Ac.sexo == false).ToList();
                                bandera = true;
                            }
                            break;
                    }


                    if (Lista.Count > 0)
                    {
                        foreach (Actores ActorBD in Lista)
                            Sesion.ListActor.Add(new Actor(ActorBD));

                        Sesion.setIntance();
                        Sesion.CambiarMenu(this, new ListaActores(), 0, null);
                    }
                    else
                    {
                        MessageBox.Show("No se han encontrado actores/actrices en la base de datos con los parametros que ingreso", "Error de Busqueda", MessageBoxButtons.OK);
                        txtNombre.Focus();
                    }
                }
            }
            else
            {
                using(DbAccessDataContext DataBase = new DbAccessDataContext())
                { 
                    Lista = DataBase.Actores.ToList();
                    foreach (Actores ActorBD in Lista)
                        Sesion.ListActor.Add(new Actor(ActorBD));
                }

                Sesion.setIntance();
                Sesion.CambiarMenu(this, new ListaActores(), 0, null);
            }            
        }

        void SetControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            cmbGenero.Items.Add("No Interesa");
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpNacido.Value = DateTime.Today;
            dtpNacido2.Value = DateTime.Today;
            txtNombre.Focus();
        }
    }
}
