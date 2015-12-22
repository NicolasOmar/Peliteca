using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliteca
{
    class Actor
    {
        public int id { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public bool sexo { set; get; }
        public DateTime nacimiento { set; get; }
        public string nomApe { set; get; }

        public Actor(Actores ActorBD)
        {
            this.id = ActorBD.idActor;
            this.nombre = ActorBD.nomActor;
            this.apellido = ActorBD.apeActor;
            this.sexo = (bool)ActorBD.sexo;
            this.nacimiento = (DateTime)ActorBD.fecNac;
            this.nomApe = ActorBD.nomActor + " " + ActorBD.apeActor;
        }

        public Actor(int pId, string pNombre, string pApellido, DateTime pNac)
        {
            this.id = pId;
            this.nombre = pNombre;
            this.apellido = pApellido;
            this.nacimiento = pNac;
        }

        public string SexoString()
        {
            if (sexo)
                return "Hombre";
            else
                return "Mujer";
        }
    }
}
