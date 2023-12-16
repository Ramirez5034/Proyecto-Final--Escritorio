using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProjectBD_RIOJAS
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=LAPTOP-SQPIJ8SS;DATABASE=SchoolServices;integrated security=true");
            cn.Open();
            return cn;
        }
    }
}
