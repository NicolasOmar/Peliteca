using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliteca
{
    class Genero
    {
        public int id { set; get; }
        public string genero { set; get; }

        public Genero(Generos GeneroBD)
        {
            this.id = GeneroBD.idGen;
            this.genero = GeneroBD.genero;
        }
    }
}
