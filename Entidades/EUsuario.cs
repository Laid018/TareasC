using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class EUsuario
    {

        public int id { get; set; }
        public string nick { get; set; }
        public string clave { get; set; }

        
    }
}
