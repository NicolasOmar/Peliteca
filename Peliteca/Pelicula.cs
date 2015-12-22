using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliteca
{
    class Pelicula
    {
        public int id { set; get; }
        public string titulo { set; get; }
        public string director { set; get; }
        public List<Actor> actores { set; get; }
        public int anio { set; get; }
        public List<Pais> paises { set; get; }
        public string genero { set; get; }
        public int duracion { set; get; }
        public byte[] foto { set; get; }

        public Pelicula(Peliculas PeliculaBD, List<Actores> ActoresBD, List<Paises> PaisesBD)
        {
            this.id = PeliculaBD.idPeli;
            this.titulo = PeliculaBD.titulo;
            this.director = PeliculaBD.Directores.nomDirec + " " + PeliculaBD.Directores.apeDirec;
            this.anio = (int)PeliculaBD.anio;
            this.actores = new List<Actor>();
            foreach (Actores ActorBD in ActoresBD)
                this.actores.Add(new Actor(ActorBD));
            this.paises = new List<Pais>();
            foreach (Paises PaisBD in PaisesBD)
                this.paises.Add(new Pais(PaisBD));
            this.duracion = Convert.ToInt32(PeliculaBD.duracion);
            this.genero = PeliculaBD.Generos.genero;
            if(PeliculaBD.foto != null)
                this.foto = PeliculaBD.foto.ToArray();
        }

        public Pelicula(int pId, string pTitulo, string pDirector, List<Actor> pActores, List<Pais> pPaises, int pAnio, string pGenero, int pDuracion, byte[] pFoto)
        {
            this.id = pId;
            this.titulo = pTitulo;
            this.director = pDirector;
            this.actores = pActores;
            this.paises = pPaises;
            this.anio = pAnio;
            this.genero = pGenero;
            this.duracion = pDuracion;
            this.foto = pFoto;
        }
    }
}
