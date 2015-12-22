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
    public partial class AgregarGenero : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);

        public AgregarGenero()
        {
            InitializeComponent();
            CargarForm();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtGenero_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(!txtGenero.Text.Equals(""))
            {
                txtGenero.Text = Sesion.NormalizarNombres(txtGenero.Text);
                using(DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    if(!BuscarGenero(txtGenero, Sesion.ListGender.Select(G => G.genero).ToArray()))
                    {
                        Generos NuevoGenero = new Generos();
                        NuevoGenero.genero = txtGenero.Text;
                        
                        DataBase.Generos.InsertOnSubmit(NuevoGenero);                        
                        DataBase.SubmitChanges();

                        NuevoGenero = null;
                        Sesion.ListGender.Clear();

                        foreach (Generos G in DataBase.Generos.ToList())
                            Sesion.ListGender.Add(new Genero(G));
                        Sesion.ListGender = Sesion.ListGender.OrderBy(G => G.genero).ToList();
                        Sesion.setIntance();

                        MessageBox.Show("Genero Registrado Exitosamente", "Genero Registrado", MessageBoxButtons.OK);

                        Sesion.SetRuta(this, new MenuGeneros(), Sesion.cambio);
                    }
                    else
                    { 
                        MessageBox.Show("Ya hay un genero registrado con los datos que ingreso, intentelo de nuevo con otro nombre", "Error de Registro", MessageBoxButtons.OK);
                        CargarForm();
                    }
                }
            }
            else
            {
                MessageBox.Show("No ingreso ningun nombre para el nuevo genero", "Error de Registro", MessageBoxButtons.OK);
                CargarForm();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.SetRuta(this, new MenuGeneros(), Sesion.cambio); }

        private void CargarForm()
        {
            txtGenero.Text = "";
            txtGenero.Focus();
        }

        private bool BuscarGenero(TextBox Caja, string[] ArrayNombres)
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
