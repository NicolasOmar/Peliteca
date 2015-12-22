using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliteca
{
    class Usuario 
    {
        public string nombre { set; get; }
        public string pass { set; get; }

        public Usuario()
        {
            nombre = "";
            pass = "";
        }

        public Usuario(string pNombre, string pPass)
        {
            nombre = pNombre;
            pass = pPass;
        }

        public Usuario(Usuarios UserBD)
        {
            nombre = UserBD.nomUser;
            pass = UserBD.passUser;
        }
    }
}
