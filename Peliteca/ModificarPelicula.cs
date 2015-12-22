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
    public partial class ModificarPelicula : Form
    {
        UnicaInstancia Sesion = new UnicaInstancia(false);
        BindingSource AccesoD = new BindingSource();
        BindingSource AccesoG = new BindingSource();
        Image imagen = null;
        bool bandera = false;

        public ModificarPelicula()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void txtActor1_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor1, true); }

        private void txtActor2_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor2, true); }

        private void txtActor3_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor3, true); }

        private void txtActor4_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor4, true); }

        private void txtActor5_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor5, true); }

        private void txtActor6_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor6, true); }

        private void txtActor7_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor7, true); }

        private void txtActor8_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor8, true); }

        private void txtActor9_Click(object sender, EventArgs e)
        { CambiarActorPais(txtActor9, true); }

        private void txtPais1_Click(object sender, EventArgs e)
        { CambiarActorPais(txtPais1, false); }

        private void txtPais2_Click(object sender, EventArgs e)
        { CambiarActorPais(txtPais2, false); }

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string[] ArrayNombres = null;
            using (DbAccessDataContext DataBase = new DbAccessDataContext())
            { ArrayNombres = DataBase.Actores.Select(A => A.nomActor + " " + A.apeActor).ToArray(); }
            string[] ArrayPaises = Sesion.ListPais.Select(Pais => Pais.nombre).ToArray();

            if (!txtTitulo.Text.Equals("")
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
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    Peliculas PeliculaBD = DataBase.Peliculas.Single(Pel => Pel.idPeli == Sesion.PeliMod.id);

                    List<PeliActor> EnlaceActores = DataBase.PeliActor.Where(PA => PA.idPeli == Sesion.PeliMod.id).ToList();
                    DataBase.PeliActor.DeleteAllOnSubmit(EnlaceActores);
                    List<PeliPais> EnlacePaises = DataBase.PeliPais.Where(PP => PP.idPeli == Sesion.PeliMod.id).ToList();
                    DataBase.PeliPais.DeleteAllOnSubmit(EnlacePaises);
                    DataBase.SubmitChanges();

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

                    if (!txtTitulo.Text.Equals(PeliculaBD.titulo) && !txtTitulo.Text.Equals(""))
                        PeliculaBD.titulo = txtTitulo.Text;

                    if (Convert.ToInt16(cmbDirector.SelectedValue) != PeliculaBD.idDirec)
                        PeliculaBD.idDirec = Convert.ToInt16(cmbDirector.SelectedValue);

                    if (Convert.ToInt16(cmbGeneros.SelectedValue) != PeliculaBD.idGen)
                        PeliculaBD.idGen = Convert.ToInt16(cmbGeneros.SelectedValue);

                    if (Convert.ToInt16(txtAnio.Text) != PeliculaBD.anio)
                        PeliculaBD.anio = Convert.ToInt16(txtAnio.Text);

                    if (Convert.ToByte(txtDuracion.Text) != PeliculaBD.duracion)
                        PeliculaBD.duracion = Convert.ToByte(txtDuracion.Text);

                    byte[] imgArray = null;

                    if(imagen != null)
                        imgArray = (byte[])new ImageConverter().ConvertTo(imagen, typeof(byte[]));

                    if (PeliculaBD.foto != null)
                    {
                        if (imgArray != null && !imgArray.Equals(PeliculaBD.foto))
                            PeliculaBD.foto = imgArray;
                    }
                    else
                    {
                        if (imgArray != null)
                            PeliculaBD.foto = imgArray;
                    }

                    DataBase.SubmitChanges();

                    PeliculaBD = DataBase.Peliculas.Single(Pel => Pel.idPeli == Sesion.PeliMod.id);

                    EnlaceActores = DataBase.PeliActor.Where(PA => PA.idPeli == PeliculaBD.idPeli).ToList();
                    List<Actores> PeliActores = new List<Actores>();

                    EnlacePaises = DataBase.PeliPais.Where(PP => PP.idPeli == PeliculaBD.idPeli).ToList();
                    List<Paises> PeliPaises = new List<Paises>();

                    foreach (PeliActor Enlace in EnlaceActores)
                        PeliActores.Add(DataBase.Actores.Single(Actor => Actor.idActor == Enlace.idActor));
                    EnlaceActores = null;

                    foreach (PeliPais Enlace in EnlacePaises)
                        PeliPaises.Add(DataBase.Paises.Single(Pais => Pais.idPais == Enlace.idPais));
                    EnlacePaises = null;

                    Sesion.PeliMod = new Pelicula(PeliculaBD, PeliActores, PeliPaises);
                    Sesion.AcomodarLista(Sesion.ListPeli.Cast<Object>().ToList(), (Object)Sesion.PeliMod, "peliculas");

                    Sesion.DirectorMod = null;
                    Sesion.GeneroMod = null;
                    PeliculaBD = null;
                    EnlaceActores = null;
                    PeliActores = null;
                    EnlacePaises = null;
                    PeliPaises = null;

                    Sesion.setIntance();

                    MessageBox.Show("La pelicula ha sido modificada correctamente", "Pelicula Modificada", MessageBoxButtons.OK);
                    Sesion.CambiarMenu(this, new VerPelicula(), 0, null);
                }
            }
            else 
            {
                MessageBox.Show("Los datos que ha querido modificar son erroneos o no coinciden con los encontrados en la base de datos", "Error de Modificacion", MessageBoxButtons.OK);
                CargarDatos();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { Sesion.CambiarMenu(this, new VerPelicula(), 0, null); }

        private void btnDirector_Click(object sender, EventArgs e)
        {
            Sesion.cambio = "ModificarPelicula";
            Sesion.setIntance();
            Sesion.CambiarMenu(this, new AgregarDirector(), 1, null);
        }

        private void btnActor_Click(object sender, EventArgs e)
        {
            Sesion.cambio = "ModificarPelicula";
            Sesion.setIntance();
            Sesion.CambiarMenu(this, new AgregarActor(), 1, null);
        }

        private void btnGenero_Click(object sender, EventArgs e)
        {
            Sesion.cambio = "ModificarPelicula";
            Sesion.setIntance();
            Sesion.CambiarMenu(this, new AgregarGenero(), 1, null);
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            Sesion.cambio = "ModificarPelicula";
            Sesion.setIntance();
            Sesion.CambiarMenu(this, new AgregarPais(), 1, null);
        }

        private void CargarDatos()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            txtTitulo.Text = Sesion.PeliMod.titulo;

            using (DbAccessDataContext DataBase = new DbAccessDataContext())
            {
                if (Sesion.DirectorMod == null)
                {
                    string[] nombreApe = Sesion.PeliMod.director.Split(' ');
                    switch (nombreApe.Length)
                    {
                        case 2:
                            Sesion.DirectorMod = new Director(DataBase.Directores.Single(Dir => Dir.nomDirec.Equals(nombreApe[0]) && Dir.apeDirec.Equals(nombreApe[1])));
                            break;
                        case 3:
                            try
                            { Sesion.DirectorMod = new Director(DataBase.Directores.Single(Dir => Dir.nomDirec.Equals(nombreApe[0] + " " + nombreApe[1]) && Dir.apeDirec.Equals(nombreApe[2]))); }
                            catch
                            { Sesion.DirectorMod = new Director(DataBase.Directores.Single(Dir => Dir.nomDirec.Equals(nombreApe[0]) && Dir.apeDirec.Equals(nombreApe[1] + " " +nombreApe[2]))); }                            
                            break;
                        case 4:
                            Sesion.DirectorMod = new Director(DataBase.Directores.Single(Dir => Dir.nomDirec.Equals(nombreApe[0] + " " + nombreApe[1]) && Dir.apeDirec.Equals(nombreApe[2] + " " + nombreApe[3])));
                            break;
                    }

                    nombreApe = null;
                }

                if (Sesion.ListActor.Count == 0)
                {
                    List<PeliActor> EnlaceActores = DataBase.PeliActor.Where(PA => PA.idPeli == Sesion.PeliMod.id).ToList();
                    List<Actores> PeliActores = new List<Actores>();

                    foreach (PeliActor Enlace in EnlaceActores)
                        PeliActores.Add(DataBase.Actores.Single(Actor => Actor.idActor == Enlace.idActor));
                    EnlaceActores = null;

                    if (Sesion.ListActor.Count > 0)
                        Sesion.ListActor.Clear();

                    foreach (Actores Actor in PeliActores)
                        Sesion.ListActor.Add(new Actor(Actor));
                    PeliActores = null;
                }

                if (Sesion.GeneroMod == null)
                    Sesion.GeneroMod = new Genero(DataBase.Generos.Single(Gen => Gen.genero.Equals(Sesion.PeliMod.genero)));
            }

            Sesion.SetCombos(AccesoD, Sesion.ListDirec.Cast<Object>().ToList(), cmbDirector, "id", "nomApe", Sesion.DirectorMod.id);

            LimpiarCajas();
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
            

            foreach (Actor Actor in Sesion.ListActor)
            {
                foreach (Control C in panelReparto.Controls)
                {
                    TextBox Caja = (TextBox)C;
                    if (Caja.Text.Equals(""))
                    {
                        Caja.Text = Actor.nomApe;
                        break;
                    }
                }
            }

            foreach (Pais Pais in Sesion.PeliMod.paises)
            {
                foreach (Control C in panelPaises.Controls)
                {
                    TextBox Caja = (TextBox)C;
                    if (Caja.Text.Equals(""))
                    {
                        Caja.Text = Pais.nombre;
                        break;
                    }
                }
            }

            Sesion.SetCombos(AccesoG, Sesion.ListGender.Cast<Object>().ToList(), cmbGeneros, "id", "genero", Sesion.GeneroMod.id);

            txtAnio.Text = Convert.ToString(Sesion.PeliMod.anio);
            txtDuracion.Text = Convert.ToString(Sesion.PeliMod.duracion);
            txtAnio.MaxLength = 4;
            txtDuracion.MaxLength = 3;

            ptbPelicula.SizeMode = PictureBoxSizeMode.StretchImage;
            if (Sesion.PeliMod.foto != null)
            {
                byte[] imgArray = Sesion.PeliMod.foto;
                MemoryStream memoria = new MemoryStream(imgArray);
                ptbPelicula.Image = Image.FromStream(memoria);
            }
        }

        private void CambiarActorPais(TextBox Caja, bool X)
        {
            if (X)
            {
                if (!Caja.Text.Equals(""))
                {
                    if (MessageBox.Show("Desea buscar un actor distinto a " + Caja.Text + "?", "Cambiar Actor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { Caja.Text = ""; }
                }
            }
            else
            {
                if (!Caja.Text.Equals(""))
                {
                    if (MessageBox.Show("Desea buscar un pais distinto a " + Caja.Text + "?", "Cambiar Pais", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    { Caja.Text = ""; }
                }
            }
        }

        private void SetRepartoPaises(TextBox Caja, bool X)
        {
            if (!Caja.Text.Equals(""))
            {
                if (X)
                {
                    string[] nombreApe = Caja.Text.Split(' ');

                    using (DbAccessDataContext DataBase = new DbAccessDataContext())
                    {
                        Actores AddActor = DataBase.Actores.Single(Ac => Ac.nomActor.Equals(nombreApe[0]) && Ac.apeActor.Equals(nombreApe[1]));

                        PeliActor insertar = new PeliActor();
                        insertar.idActor = AddActor.idActor;
                        insertar.idPeli = Sesion.PeliMod.id;

                        DataBase.PeliActor.InsertOnSubmit(insertar);
                        DataBase.SubmitChanges();
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
                        insertar.idPeli = Sesion.PeliMod.id;

                        DataBase.PeliPais.InsertOnSubmit(insertar);
                        DataBase.SubmitChanges();
                    }
                }
            }
        }

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

        private void LimpiarCajas()
        {
            foreach (Actor Actor in Sesion.ListActor)
            {
                foreach (Control C in panelReparto.Controls)
                    C.Text = "";
            }

            foreach (Pais Pais in Sesion.PeliMod.paises)
            {
                foreach (Control C in panelPaises.Controls)
                    C.Text = "";
            }
        }

        private void ModificarPelicula_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && bandera)
            {
                Sesion = new UnicaInstancia(false);
                CargarDatos();
            }
            bandera = true;
        }

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
    }
}
