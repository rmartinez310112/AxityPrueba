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
    public class repoProducts
    {
        public IEnumerable<Productos> GetListProductos()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Products";
            List<Productos> result;

            using (Helpers Helper = new Helpers())
            {
                result = new List<Productos>();
                using (SqlDataReader dr = Helper.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var ent = new Productos
                        {
                            id = Convert.ToInt16(dr["id"]),
                            name = dr["Name"].ToString(),
                            Sku = dr["Sku"].ToString(),
                            description = dr["Description"].ToString()
                        };
                        result.Add(ent);
                    }
                }
            }
            return result.ToList();
        }
    }
}
