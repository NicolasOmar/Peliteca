using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peliteca
{
    class UnicaInstancia
    {
        public static UnicaInstancia Instancia { set; get; }

        public Usuario User { set; get; }
        public Pelicula PeliMod { set; get; }
        public Director DirectorMod { set; get; }
        public Actor ActorMod { set; get; }
        public Genero GeneroMod { set; get; }
        public Pais PaisMod { set; get; }
        public List<Pelicula> ListPeli { set; get; }
        public List<Director> ListDirec { set; get; }
        public List<Actor> ListActor { set; get; }
        public List<Genero> ListGender { set; get; }
        public List<Pais> ListPais { set; get; }
        public string cambio { set; get; }

        public UnicaInstancia(bool X)
        {
            if(X)
            {
                User = null;
                PeliMod = null;
                DirectorMod = null;
                ActorMod = null;
                GeneroMod = null;
                PaisMod = null;

                ListPeli = new List<Pelicula>();
                ListDirec = new List<Director>();
                ListActor = new List<Actor>();
                ListGender = new List<Genero>();
                ListPais = new List<Pais>();
                using (DbAccessDataContext DataBase = new DbAccessDataContext())
                {
                    foreach (Directores var in DataBase.Directores.OrderBy(D => D.nomDirec).ToList())
                    { ListDirec.Add(new Director(var)); }
                    foreach (Generos var in DataBase.Generos.OrderBy(G => G.genero).ToList())
                    { ListGender.Add(new Genero(var)); }
                    foreach (Paises var in DataBase.Paises.OrderBy(P => P.pais).ToList())
                    { ListPais.Add(new Pais(var)); }
                }
                cambio = "";
            }
            else
            {
                User = Instancia.User;
                PeliMod = Instancia.PeliMod;
                DirectorMod = Instancia.DirectorMod;
                ActorMod = Instancia.ActorMod;
                GeneroMod = Instancia.GeneroMod;
                PaisMod = Instancia.PaisMod;

                ListPeli = Instancia.ListPeli;
                ListDirec = Instancia.ListDirec;
                ListActor = Instancia.ListActor;
                ListGender = Instancia.ListGender;
                ListPais = Instancia.ListPais;
                cambio = Instancia.cambio;
            }
        }

        public UnicaInstancia getIntance()
        {
            if (Instancia == null)
                Instancia = new UnicaInstancia(true);
            return Instancia;
        }

        public void setIntance()
        {
            Instancia.User = User;
            Instancia.PeliMod = PeliMod;
            Instancia.DirectorMod = DirectorMod;
            Instancia.GeneroMod = GeneroMod;
            Instancia.ActorMod = ActorMod;
            Instancia.PaisMod = PaisMod;

            Instancia.ListPeli = ListPeli;
            Instancia.ListDirec = ListDirec;
            Instancia.ListActor = ListActor;
            Instancia.ListGender = ListGender;
            Instancia.ListPais = ListPais;
            Instancia.cambio = cambio;
        }

        public void CambiarMenu(Form Viejo, Form Nuevo, Int16 Caso, string Nombre)
        {
            switch(Caso)
            {
                case 0:
                    Nuevo.Show();
                    Viejo.Dispose();
                    break;
                case 1:
                    Nuevo.Show();
                    Viejo.Hide();
                    break;
                case 2:
                    FormCollection Formularios = Application.OpenForms;
                    foreach (Form F in Formularios)
                    {
                        if (F.Name.Equals(Nombre))
                        {
                            F.Show();
                            Nuevo.Dispose();
                            break;
                        }
                    }
                    break;
            }
            
        }

        public void BloquearTeclas(KeyPressEventArgs e, string opcion)
        {
            switch (opcion)
            {
                case "letras":
                    if (char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                    break;
                case "numeros":
                    if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                        e.Handled = true;
                    break;
            }
        }

        public void SetCajas(TextBox Caja, string caso)
        {
            AutoCompleteStringCollection Nombres = new AutoCompleteStringCollection();
            string[] ArrayNombres = null;

            switch (caso)
            {
                case "directores":
                    ArrayNombres = ListDirec.Select(P => P.nomApe).ToArray();
                    break;

                case "actores":
                    using (DbAccessDataContext DataBase = new DbAccessDataContext())
                    { ArrayNombres = DataBase.Actores.Select(Ac => Ac.nomActor + " " + Ac.apeActor).ToArray(); }
                    break;

                case "paises":
                    ArrayNombres = ListPais.Select(P => P.nombre).ToArray();
                    break;
            }

            foreach (string nombre in ArrayNombres)
                Nombres.Add(nombre);
            ArrayNombres = null;
            Caja.AutoCompleteMode = AutoCompleteMode.Suggest;
            Caja.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Caja.AutoCompleteCustomSource = Nombres;
        }

        public void SetCombos(BindingSource Fuente, List<Object> Lista, ComboBox Combo, string id, string nombre, int? este)
        {
            Fuente.DataSource = Lista;
            Combo.DataSource = Fuente;
            Combo.ValueMember = id;
            Combo.DisplayMember = nombre;
            Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            if (este != null)
                Combo.SelectedValue = este;
        }

        public void AcomodarLista(List<Object> Lista, Object NuevoObjeto, String caso)
        {
            switch(caso)
            {
                case "peliculas":
                    {
                        Lista.Cast<Pelicula>().ToList();
                        var ObjetoMod = (Pelicula)NuevoObjeto;

                        foreach (Pelicula PeliBD in Lista)
                        {
                            if (PeliBD.id == ObjetoMod.id)
                            {
                                PeliBD.titulo = ObjetoMod.titulo;
                                PeliBD.director = ObjetoMod.director;
                                PeliBD.genero = ObjetoMod.genero;
                                PeliBD.anio = ObjetoMod.anio;

                                NuevoObjeto = null;
                                break;
                            }
                        }
                        break;
                    }

                case "actores":
                    {
                        Lista.Cast<Actor>().ToList();
                        var ObjetoMod = (Actor)NuevoObjeto;

                        foreach (Actor ActorBD in Lista)
                        {
                            if (ActorBD.id == ObjetoMod.id)
                            {
                                ActorBD.nombre = ObjetoMod.nombre;
                                ActorBD.apellido = ObjetoMod.apellido;
                                ActorBD.sexo = ObjetoMod.sexo;
                                ActorBD.nacimiento = ObjetoMod.nacimiento;
                                ActorBD.nomApe = ObjetoMod.nomApe;

                                NuevoObjeto = null;
                                break;
                            }
                        }
                        break;
                    }

                case "directores":
                    {
                        Lista.Cast<Director>().ToList();
                        var ObjetoMod = (Director)NuevoObjeto;

                        foreach (Director DirectorBD in Lista)
                        {
                            if (DirectorBD.id == ObjetoMod.id)
                            {
                                DirectorBD.nombre = ObjetoMod.nombre;
                                DirectorBD.apellido = ObjetoMod.apellido;
                                DirectorBD.nacimiento = ObjetoMod.nacimiento;
                                DirectorBD.nomApe = ObjetoMod.nomApe;

                                NuevoObjeto = null;
                                break;
                            }
                        }
                        break;
                    }

                case "generos":
                    {
                        Lista.Cast<Genero>().ToList();
                        var ObjetoMod = (Genero)NuevoObjeto;

                        foreach (Genero GeneroBD in Lista)
                        {
                            if (GeneroBD.id == ObjetoMod.id)
                            {
                                GeneroBD.genero = ObjetoMod.genero;

                                NuevoObjeto = null;
                                break;
                            }
                        }
                        break;
                    }

                case "paises":
                    {
                        Lista.Cast<Pais>().ToList();
                        var ObjetoMod = (Pais)NuevoObjeto;

                        foreach (Pais PaisBD in Lista)
                        {
                            if (PaisBD.id == ObjetoMod.id)
                            {
                                PaisBD.nombre = ObjetoMod.nombre;

                                NuevoObjeto = null;
                                break;
                            }
                        }
                        break;
                    }
            }
            
        }

        public void SetRuta(Form Viejo, Form Nuevo, string ruta)
        {
            if(ruta.Equals(""))
                CambiarMenu(Viejo, Nuevo, 0, "");
            else
            {
                cambio = "";
                setIntance();
                CambiarMenu(Nuevo, Viejo, 2, ruta);
            }
        }

        public string NormalizarNombres(string cadena)
        {
            List<Char> letras = cadena.ToList();

            for (int i = 0; i < letras.Count; i++)
            {
                string letra = "";

                if (!Char.IsNumber(letras[i]) && !Char.IsPunctuation(letras[i]))
                {
                    if (i == 0)
                    {
                        letra = letras[i].ToString().ToUpper();
                        letras[i] = Convert.ToChar(letra);
                    }
                    else
                        if (Char.IsWhiteSpace(letras[i]))
                        {
                            try
                            {
                                letra = letras[i - 1].ToString().ToLower();
                                letras[i - 1] = Convert.ToChar(letra);
                                letra = letras[i + 1].ToString().ToUpper();
                                letras[i + 1] = Convert.ToChar(letra);
                            }
                            catch
                            { letras.RemoveAt(i); }
                        }
                        else
                            if (Char.IsSymbol(letras[i]))
                            {
                                letra = letras[i - 1].ToString().ToUpper();
                                letras[i - 1] = Convert.ToChar(letra);
                                letra = letras[i + 1].ToString().ToUpper();
                                letras[i + 1] = Convert.ToChar(letra);
                            }
                }
            }

            cadena = new string(letras.ToArray());
            return cadena;
        }

        public void Limpiar()
        {
            PeliMod = null;
            DirectorMod = null;
            ActorMod = null;
            GeneroMod = null;
            PaisMod = null;

            ListPeli.Clear();
            ListActor.Clear();
        }
    }
}
