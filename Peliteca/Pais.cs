using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliteca
{
    class Pais
    {
        public int id { set; get; }
        public string nombre { set; get; }

        public Pais(Paises PaisBD)
        {
            this.id = PaisBD.idPais;
            this.nombre = PaisBD.pais;
        }

        public Pais(int pId, string pNombre)
        {
            this.id = pId;
            this.nombre = pNombre;
        }
    }
}
