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
    public partial class BuscarPelicula : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);
        BindingSource Acceso = new BindingSource();

        public BuscarPelicula()
        {
            InitializeComponent();
            SetControles();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(false);
            else
                Sesion.BloquearTeclas(e, "letrasNumeros");
        }

        private void txtDirector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(false);
            else
                Sesion.BloquearTeclas(e, "letras");            
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(false);
            else
                Sesion.BloquearTeclas(e, "numeros");
        }

        private void txtAnio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(false);
            else
                Sesion.BloquearTeclas(e, "numeros");
        }

        private void txtDuracion2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(false);
            else
                Sesion.BloquearTeclas(e, "numeros");
        }

        private void txtDuracion1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                HacerBusqueda(false);
            else
                Sesion.BloquearTeclas(e, "numeros");
        }

        private void btnTodas_Click(object sender, EventArgs e)
        { HacerBusqueda(true); }

        private void btnBuscar_Click(object sender, EventArgs e)
        { HacerBusqueda(false); }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPeliculas(), 0, null); }

        private void HacerBusqueda(bool X)
        {
            List<Peliculas> Lista = new List<Peliculas>();
            Sesion.ListPeli.Clear();
            if (!X)
            {
                if (BuscarCoincidencia(txtDirector, Sesion.ListDirec.Select(D => D.nomApe).ToArray()))
                {
                    using (DbAccessDataContext DataBase = new DbAccessDataContext())
                    {
                        bool bandera = false;

                        if (txtTitulo.TextLength > 0)
                        {
                            bandera = true;
                            Lista = DataBase.Peliculas.Where(P => P.titulo.ToLower().Contains(txtTitulo.Text.ToLower())).ToList();
                        }

                        if (txtDirector.TextLength > 0)
                        {
                            string[] nombreApe = txtDirector.Text.Split(' ');

                            if (bandera)
                            {
                                switch (nombreApe.Length)
                                {
                                    case 2:
                                        Lista = Lista.Where(P => P.Directores.nomDirec.Equals(nombreApe[0]) && P.Directores.apeDirec.Equals(nombreApe[1])).ToList();
                                        break;
                                    case 3:
                                        try
                                        { Lista = Lista.Where(P => P.Directores.nomDirec.Equals(nombreApe[0] + " " + nombreApe[1]) && P.Directores.apeDirec.Equals(nombreApe[2])).ToList(); }
                                        catch
                                        { Lista = Lista.Where(P => P.Directores.nomDirec.Equals(nombreApe[0]) && P.Directores.apeDirec.Equals(nombreApe[1] + " " + nombreApe[2])).ToList(); }
                                        break;
                                    case 4:
                                        Lista = Lista.Where(P => P.Directores.nomDirec.Equals(nombreApe[0] + " " + nombreApe[1]) && P.Directores.apeDirec.Equals(nombreApe[2] + " " + nombreApe[3])).ToList();
                                        break;
                                }
                            }
                            else
                            {
                                switch (nombreApe.Length)
                                {
                                    case 2:
                                        Lista = DataBase.Peliculas.Where(P => P.Directores.nomDirec.Equals(nombreApe[0]) && P.Directores.apeDirec.Equals(nombreApe[1])).ToList();
                                        break;
                                    case 3:
                                        try
                                        { Lista = DataBase.Peliculas.Where(P => P.Directores.nomDirec.Equals(nombreApe[0] + " " + nombreApe[1]) && P.Directores.apeDirec.Equals(nombreApe[2])).ToList(); }
                                        catch
                                        { Lista = DataBase.Peliculas.Where(P => P.Directores.nomDirec.Equals(nombreApe[0]) && P.Directores.apeDirec.Equals(nombreApe[1] + " " + nombreApe[2])).ToList(); }
                                        break;
                                    case 4:
                                        Lista = DataBase.Peliculas.Where(P => P.Directores.nomDirec.Equals(nombreApe[0] + " " + nombreApe[1]) && P.Directores.apeDirec.Equals(nombreApe[2] + " " + nombreApe[3])).ToList();
                                        break;
                                }
                                bandera = true;
                            }

                            nombreApe = null;
                        }

                        if ((txtAnio1.TextLength == 4 || txtAnio1.TextLength == 0)
                            && txtAnio2.TextLength == 4
                            && Convert.ToInt16(txtAnio2.Text) <= 2015)
                        {
                            if (txtAnio1.TextLength == 0)
                            {
                                if (bandera)
                                    Lista = Lista.Where(P => P.anio <= Convert.ToInt16(txtAnio2.Text)).ToList();
                                else
                                {
                                    Lista = DataBase.Peliculas.Where(P => P.anio <= Convert.ToInt16(txtAnio2.Text)).ToList();
                                    bandera = true;
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(txtAnio1.Text) < Convert.ToInt32(txtAnio2.Text))
                                {
                                    if (bandera)
                                        Lista = Lista.Where(P => P.anio >= Convert.ToInt16(txtAnio1.Text) && P.anio <= Convert.ToInt16(txtAnio2.Text)).ToList();
                                    else
                                    {
                                        Lista = DataBase.Peliculas.Where(P => P.anio >= Convert.ToInt16(txtAnio1.Text) && P.anio <= Convert.ToInt16(txtAnio2.Text)).ToList();
                                        bandera = true;
                                    }
                                }
                            }
                        }

                        if ((int)cmbGenero.SelectedValue != 10)
                        {
                            if (bandera)
                                Lista = Lista.Where(P => P.idGen == (int)cmbGenero.SelectedValue).ToList();
                            else
                            {
                                Lista = DataBase.Peliculas.Where(P => P.idGen == (int)cmbGenero.SelectedValue).ToList();
                                bandera = true;
                            }
                        }

                        if (txtDuracion.TextLength > 0)
                        {
                            if (bandera)
                                Lista = Lista.Where(P => (int)P.duracion <= Convert.ToInt16(txtDuracion.Text)).ToList();
                            else
                            {
                                Lista = DataBase.Peliculas.Where(P => (int)P.duracion <= Convert.ToInt16(txtDuracion.Text)).ToList();
                                bandera = true;
                            }
                        }

                        if (Lista.Count == 0)
                        {
                            MessageBox.Show("No se han encontrado peliculas en la BD con los datos que ingreso", "Error de Busqueda", MessageBoxButtons.OK);
                            SetControles();
                        }
                        else
                        {
                            foreach (Peliculas PeliBD in Lista)
                            {
                                List<PeliActor> EnlaceActores = DataBase.PeliActor.Where(PA => PA.idPeli == PeliBD.idPeli).ToList();
                                List<Actores> PeliActores = new List<Actores>();
                                List<PeliPais> EnlacePaises = DataBase.PeliPais.Where(PP => PP.idPeli == PeliBD.idPeli).ToList();
                                List<Paises> PeliPaises = new List<Paises>();

                                foreach (PeliActor Enlace in EnlaceActores)
                                    PeliActores.Add(DataBase.Actores.Single(Actor => Actor.idActor == Enlace.idActor));
                                EnlaceActores = null;

                                foreach (PeliPais Enlace in EnlacePaises)
                                    PeliPaises.Add(DataBase.Paises.Single(Pais => Pais.idPais == Enlace.idPais));
                                EnlacePaises = null;

                                Sesion.ListPeli.Add(new Pelicula(PeliBD, PeliActores, PeliPaises));
                                Sesion.ListPeli = Sesion.ListPeli.OrderBy(P => P.titulo).ToList();

                                PeliActores = null;
                                PeliPaises = null;
                            }

                            Sesion.setIntance();
                            Sesion.CambiarMenu(this, new ListaPeliculas(), 0, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Los datos ingresados son erroneos o no coinciden con los encontrados en la base de datos para hacer la busqueda", "Error de Busqueda", MessageBoxButtons.OK);
                    SetControles();
                }
            }
            else
            {
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    Lista = DataBase.Peliculas.ToList();

                    foreach (Peliculas PeliBD in Lista)
                    {
                        List<PeliActor> EnlaceActores = DataBase.PeliActor.Where(PA => PA.idPeli == PeliBD.idPeli).ToList();
                        List<Actores> PeliActores = new List<Actores>();
                        List<PeliPais> EnlacePaises = DataBase.PeliPais.Where(PP => PP.idPeli == PeliBD.idPeli).ToList();
                        List<Paises> PeliPaises = new List<Paises>();

                        foreach (PeliActor Enlace in EnlaceActores)
                            PeliActores.Add(DataBase.Actores.Single(Actor => Actor.idActor == Enlace.idActor));
                        EnlaceActores = null;

                        foreach (PeliPais Enlace in EnlacePaises)
                            PeliPaises.Add(DataBase.Paises.Single(Pais => Pais.idPais == Enlace.idPais));
                        EnlacePaises = null;

                        Sesion.ListPeli.Add(new Pelicula(PeliBD, PeliActores, PeliPaises));
                        Sesion.ListPeli = Sesion.ListPeli.OrderBy(P => P.titulo).ToList();

                        PeliActores = null;
                        PeliPaises = null;
                    }

                    Sesion.setIntance();
                    Sesion.CambiarMenu(this, new ListaPeliculas(), 0, null);
                }
            }
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

        private void SetControles()
        {
            txtTitulo.Text = "";
            txtDirector.Text = "";
            Sesion.SetCajas(txtDirector, "directores");
            txtAnio1.MaxLength = 4;
            txtAnio2.MaxLength = 4;
            txtDuracion.MaxLength = 3;
            Sesion.SetCombos(Acceso, Sesion.ListGender.Cast<Object>().ToList(), cmbGenero, "id", "genero", null);
            cmbGenero.SelectedValue = 10;
        }

        
    }
}
