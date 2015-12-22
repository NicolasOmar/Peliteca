using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliteca
{
    class Director
    {
        public int id { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public DateTime nacimiento { set; get; }
        public string nomApe { get; set; }

        public Director(Directores DirectorBD)
        {
            this.id = DirectorBD.idDirec;
            this.nombre = DirectorBD.nomDirec;
            this.apellido = DirectorBD.apeDirec;
            this.nacimiento = (DateTime)DirectorBD.fecNac;
            this.nomApe = DirectorBD.nomDirec + " " + DirectorBD.apeDirec;
        }

        public Director(int pId, string pNombre, string pApellido, DateTime pNac)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.apellido = pApellido;
            this.nacimiento = pNac;
        }
    }
}
