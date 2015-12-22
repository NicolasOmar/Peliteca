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
    public partial class AgregarPais : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public AgregarPais()
        {
            InitializeComponent();
            CargarForm();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(!txtPais.Text.Equals(""))
            {
                txtPais.Text = Sesion.NormalizarNombres(txtPais.Text);
                using(DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    if(!BuscarPais(txtPais,Sesion.ListPais.Select(P => P.nombre).ToArray()))
                    {
                        Paises NuevoPais = new Paises();
                        NuevoPais.pais = txtPais.Text;

                        DataBase.Paises.InsertOnSubmit(NuevoPais);
                        DataBase.SubmitChanges();

                        NuevoPais = null;
                        Sesion.ListPais.Clear();

                        foreach (Paises P in DataBase.Paises.ToList())
                            Sesion.ListPais.Add(new Pais(P));
                        Sesion.ListPais = Sesion.ListPais.OrderBy(P => P.nombre).ToList();
                        Sesion.setIntance();

                        MessageBox.Show("Pais Registrado Exitosamente", "Pais Registrado", MessageBoxButtons.OK);

                        Sesion.SetRuta(this, new MenuPaises(), Sesion.cambio);
                    }
                    else
                    {
                        MessageBox.Show("Ya hay un pais registrado con los datos que ingreso, intentelo de nuevo con otro nombre", "Error de Registro", MessageBoxButtons.OK);
                        CargarForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("No ingreso ningun nombre para el nuevo pais", "Error de Registro", MessageBoxButtons.OK);
                txtPais.Focus();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.SetRuta(this, new MenuPaises(), Sesion.cambio); }

        private void CargarForm()
        {
            txtPais.Text = "";
            txtPais.Focus();
        }

        private bool BuscarPais(TextBox Caja, string[] ArrayNombres)
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
