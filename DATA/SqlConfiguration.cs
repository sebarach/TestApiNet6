using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class SqlConfiguration
    {
        public SqlConfiguration(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }
    
        public string CadenaConexion { get; set; }
    }
}
