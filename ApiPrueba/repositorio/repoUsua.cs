using componentes;
using modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositorio
{
    public class repoUsua
    {
        public IEnumerable<Usuarios> GetListUsuarios()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Users";
            List<Usuarios> result;

            using (Helpers Helper = new Helpers())
            {
                result = new List<Usuarios>();
                using (SqlDataReader dr = Helper.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var ent = new Usuarios
                        {
                            Usua = dr["user"].ToString(),
                            Pass = dr["pwd"].ToString()
                        };
                        result.Add(ent);
                    }
                }
            }

            return result;
        }
    }
}
