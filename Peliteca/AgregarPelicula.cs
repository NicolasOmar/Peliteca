using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peliteca
{
    public partial class AgregarPelicula : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);
        Peliculas NuevaPelicula = new Peliculas();
        BindingSource AccesoD = new BindingSource();
        BindingSource AccesoG = new BindingSource();
        Image imagen = null;
        bool bandera = false;

        public AgregarPelicula()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void txtActor1_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor1); }

        private void txtActor2_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor2); }

        private void txtActor3_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor3); }

        private void txtActor4_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor4); }

        private void txtActor5_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor5); }

        private void txtActor6_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor6); }

        private void txtActor7_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor7); }

        private void txtActor8_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor8); }

        private void txtActor9_Click(object sender, EventArgs e)
        { LimpiarCajas(txtActor9); }

        private void txtPais1_Click(object sender, EventArgs e)
        { LimpiarCajas(txtPais1); }

        private void txtPais2_Click(object sender, EventArgs e)
        { LimpiarCajas(txtPais2); }

        private void txtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letrasNumeros"); }

        private void txtActor1_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtActor2_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtActor3_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtActor4_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtActor5_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtActor6_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtActor7_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtActor8_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtActor9_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtPais1_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtPais2_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "letras"); }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "numeros"); }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        { Sesion.BloquearTeclas(e, "numeros"); }

        private void ptbPelicula_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialogo = new OpenFileDialog();
            if (Dialogo.ShowDialog() == DialogResult.OK)
            {
                imagen = Image.FromFile(Dialogo.FileName);
                MemoryStream memoria = new MemoryStream();
                imagen.Save(memoria, imagen.RawFormat);
                ptbPelicula.Image = Image.FromStream(memoria);
            }
        }

        //METODO QUE RECARGA LAS LISTAS DE DONDE SE NUTREN LOS CONTROLES DEL FORMULARIO DONDE BUSCAMOS PARA HACER LA PELICULA, VENIS DE CREAR UN ACTOR NUEVO Y YA LO TENES PARA ASIGNARLO letra LA PELICULA
        private void AgregarPelicula_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && bandera)
            {
                Sesion = new UnicaInstancia(false);
                CargarDatos();
            }
            bandera = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string[] ArrayNombres = null;
            using (DbAccessDataContext DataBase = new DbAccessDataContext())
            { ArrayNombres = DataBase.Actores.Select(Act => Act.nomActor + " " + Act.apeActor).ToArray(); }
            string[] ArrayPaises = Sesion.ListPais.Select(Pais => Pais.nombre).ToArray();

            if(!txtTitulo.Equals("")
                && BuscarActorPais(txtActor1, ArrayNombres)
                && BuscarActorPais(txtActor2, ArrayNombres)
                && BuscarActorPais(txtActor3, ArrayNombres)
                && BuscarActorPais(txtActor4, ArrayNombres)
                && BuscarActorPais(txtActor5, ArrayNombres)
                && BuscarActorPais(txtActor6, ArrayNombres)
                && BuscarActorPais(txtActor7, ArrayNombres)
                && BuscarActorPais(txtActor8, ArrayNombres)
                && BuscarActorPais(txtActor9, ArrayNombres)
                && BuscarActorPais(txtPais1, ArrayPaises)
                && BuscarActorPais(txtPais2, ArrayPaises)
                && !txtAnio.Text.Equals("") 
                && Convert.ToInt32(txtAnio.Text) <= DateTime.Today.Year
                && !txtDuracion.Text.Equals(""))
            {
                using(DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    ArrayNombres = null; ArrayPaises = null;

                    NuevaPelicula.titulo = txtTitulo.Text;
                    NuevaPelicula.idDirec = Convert.ToInt16(cmbDirector.SelectedValue);
                    NuevaPelicula.idGen = Convert.ToInt16(cmbGenero.SelectedValue);
                    NuevaPelicula.anio = Convert.ToInt16(txtAnio.Text);
                    NuevaPelicula.duracion = Convert.ToByte(txtDuracion.Text);
                    if (imagen != null)
                    {
                        byte[] imgArray = (byte[]) new ImageConverter().ConvertTo(imagen, typeof(byte[]));
                        NuevaPelicula.foto = imgArray;
                    }
                    DataBase.Peliculas.InsertOnSubmit(NuevaPelicula);
                    DataBase.SubmitChanges();

                    NuevaPelicula = DataBase.Peliculas.Single(Peli => Peli.titulo.Equals(txtTitulo.Text));

                    SetRepartoPaises(txtActor1, true);
                    SetRepartoPaises(txtActor2, true);
                    SetRepartoPaises(txtActor3, true);
                    SetRepartoPaises(txtActor4, true);
                    SetRepartoPaises(txtActor5, true);
                    SetRepartoPaises(txtActor6, true);
                    SetRepartoPaises(txtActor7, true);
                    SetRepartoPaises(txtActor8, true);
                    SetRepartoPaises(txtActor9, true);
                    SetRepartoPaises(txtPais1, false);
                    SetRepartoPaises(txtPais2, false);

                    List<PeliActor> EnlaceActores = DataBase.PeliActor.Where(PA => PA.idPeli == NuevaPelicula.idPeli).ToList();
                    List<Actores> PeliActores = new List<Actores>();

                    List<PeliPais> EnlacePaises = DataBase.PeliPais.Where(PP => PP.idPeli == NuevaPelicula.idPeli).ToList();
                    List<Paises> PeliPaises = new List<Paises>();

                    foreach (PeliActor Enlace in EnlaceActores)
                        PeliActores.Add(DataBase.Actores.Single(Actor => Actor.idActor == Enlace.idActor));
                    EnlaceActores = null;

                    foreach (PeliPais Enlace in EnlacePaises)
                        PeliPaises.Add(DataBase.Paises.Single(Pais => Pais.idPais == Enlace.idPais));
                    EnlacePaises = null;
                    
                    Sesion.ListPeli.Clear();
                    Sesion.ListPeli.Add(new Pelicula(NuevaPelicula, PeliActores, PeliPaises));
                    Sesion.ListPeli = Sesion.ListPeli.OrderBy(P => P.titulo).ToList();
                    Sesion.setIntance();

                    NuevaPelicula = null;
                    PeliActores = null;
                    PeliPaises = null;
                }

                Sesion.CambiarMenu(this, new ListaPeliculas(), 0, null);
            }
            else
            { MessageBox.Show("Los datos ingresados estan incompletos o son erroneos, intente nuevamente", "Error de Registro", MessageBoxButtons.OK); }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new MenuPeliculas(), 0, null); }

        private void addDirector_Click(object sender, EventArgs e)
        {
            Sesion.cambio = "AgregarPelicula";
            Sesion.setIntance();
            Sesion.CambiarMenu(this, new AgregarDirector(), 1, null);
        }

        private void btnAddActor_Click(object sender, EventArgs e) 
        {
            Sesion.cambio = "AgregarPelicula";
            Sesion.setIntance();
            Sesion.CambiarMenu(this, new AgregarActor(), 1, null);
        }

        private void addGenero_Click(object sender, EventArgs e)
        {
            Sesion.cambio = "AgregarPelicula";
            Sesion.setIntance();
            Sesion.CambiarMenu(this, new AgregarGenero(), 1, null);
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            Sesion.cambio = "AgregarPelicula";
            Sesion.setIntance();
            Sesion.CambiarMenu(this, new AgregarPais(), 1, null);
        }

        //METODO DE CARGA PRINCIPAL DEL FORMULARIO
        private void CargarDatos()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            Sesion.SetCajas(txtActor1, "actores");
            Sesion.SetCajas(txtActor2, "actores");
            Sesion.SetCajas(txtActor3, "actores");
            Sesion.SetCajas(txtActor4, "actores");
            Sesion.SetCajas(txtActor5, "actores");
            Sesion.SetCajas(txtActor6, "actores");
            Sesion.SetCajas(txtActor7, "actores");
            Sesion.SetCajas(txtActor8, "actores");
            Sesion.SetCajas(txtActor9, "actores");
            Sesion.SetCajas(txtPais1, "paises");
            Sesion.SetCajas(txtPais2, "paises");

            Sesion.SetCombos(AccesoD, Sesion.ListDirec.Cast<Object>().ToList(), cmbDirector, "id", "nomApe", null);
            Sesion.SetCombos(AccesoG, Sesion.ListGender.Cast<Object>().ToList(), cmbGenero, "id", "genero", null);

            txtAnio.MaxLength = 4;
            txtDuracion.MaxLength = 3;
            
            ptbPelicula.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        //LIMPIAR LAS CAJAS DE TEXTO
        private void LimpiarCajas(TextBox Caja)
        {
            if (!Caja.Text.Equals(""))
                Caja.Text = "";
        }
        //BUSCO EN EL ARRAY DE NOMBRES SI EL CONTENIDO DE LA CAJA COINCIDE CON ALGUNO DE ELLOS
        private bool BuscarActorPais(TextBox Caja, string[] ArrayNombres)
        {
            bool flag = false;

            foreach (string nombre in ArrayNombres)
            {
                if (Caja.Text.Equals(nombre) || Caja.Text.Equals(""))
                    flag = true;
            }

            return flag;
        }
        //INSERTA EL ACTOR O PAIS SELECCIONADO EN LAS CASILLAS AUTOCOMPLETADAS QUE TIENEN LOS NOMBRES CORRECTOS DENTRO DE LA RELACIOIN DE LA BASE DE DATOS
        private void SetRepartoPaises(TextBox Caja, bool X)
        {
            try
            {
                if (!Caja.Text.Equals(""))
                {
                    if (X)
                    {
                        string[] nombreApe = Caja.Text.Split(' ');

                        using (DbAccessDataContext DataBase = new DbAccessDataContext())
                        {
                            Actores AddActor = new Actores();

                            switch(nombreApe.Length)
                            {
                                case 2:
                                    AddActor = DataBase.Actores.Single(Ac => Ac.nomActor.Equals(nombreApe[0]) && Ac.apeActor.Equals(nombreApe[1]));
                                    break;
                                case 3:
                                    try
                                    { AddActor = DataBase.Actores.Single(Ac => Ac.nomActor.Equals(nombreApe[0] + " " + nombreApe[1]) && Ac.apeActor.Equals(nombreApe[2])); }
                                    catch
                                    { AddActor = DataBase.Actores.Single(Ac => Ac.nomActor.Equals(nombreApe[0]) && Ac.apeActor.Equals(nombreApe[1] + " " + nombreApe[2])); }
                                    break;
                                case 4:
                                    AddActor = DataBase.Actores.Single(Ac => Ac.nomActor.Equals(nombreApe[0] + " " + nombreApe[1]) && Ac.apeActor.Equals(nombreApe[2] + " " + nombreApe[3]));
                                    break;
                            }

                            PeliActor insertar = new PeliActor();
                            insertar.idActor = AddActor.idActor;
                            insertar.idPeli = NuevaPelicula.idPeli;

                            DataBase.PeliActor.InsertOnSubmit(insertar);
                            DataBase.SubmitChanges();

                            AddActor = null;
                        }
                        nombreApe = null;
                    }
                    else
                    {
                        using (DbAccessDataContext DataBase = new DbAccessDataContext())
                        {
                            Paises AddPais = DataBase.Paises.Single(Pa => Pa.pais.Equals(Caja.Text));

                            PeliPais insertar = new PeliPais();
                            insertar.idPais = AddPais.idPais;
                            insertar.idPeli = NuevaPelicula.idPeli;

                            DataBase.PeliPais.InsertOnSubmit(insertar);
                            DataBase.SubmitChanges();
                        }
                    }
                }
            }
            catch
            { MessageBox.Show("Uno de los actores o paises que quiso registrar esta mal ingresado.", "Error de Registro", MessageBoxButtons.OK); }
        }
    }
}
