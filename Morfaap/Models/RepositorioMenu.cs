using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class RepositorioMenu : RepositorioBase,IRepositorio<MenuModel>
    {
        public RepositorioMenu(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(MenuModel ob)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Menu (IdLocal)" +
                            $"VALUES('{ob.IdLocal}');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    ob.IdMenu = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            throw new NotImplementedException();
        }

        public int Modificacion(MenuModel ob)
        {
            throw new NotImplementedException();
        }

        public MenuModel ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<MenuModel> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
