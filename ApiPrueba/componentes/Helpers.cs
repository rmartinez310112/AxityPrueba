using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace componentes
{
    public class Helpers:IDisposable
    {
        public string sConexion;
        public SqlConnection cn;

        public Helpers()
        {
            sConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            cn = new SqlConnection(sConexion);

        }


        public SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            cmd.Connection = cn;
            cn.Open();

            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public void Dispose()
        {
            if (cn.State != System.Data.ConnectionState.Closed)
            {
                cn.Close();
            }

            cn.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
