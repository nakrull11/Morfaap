using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class RepositorioPlato : RepositorioBase, IRepositorioPlato
    {
        public RepositorioPlato(IConfiguration configuration) : base(configuration)
        {

        }
        public int Alta(PlatoModel ob)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Plato (Nombre,Categoria,Precio,Estado,IdMenu)" +
                            $"VALUES('{ob.Nombre}','{ob.Categoria}','{ob.Precio}','{ob.Estado}','{ob.Menu.IdMenu}');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    ob.IdPlato = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            throw new NotImplementedException();
        }

        public int Modificacion(PlatoModel ob)
        {
            throw new NotImplementedException();
        }

        public int ModificarEstadoPlato(PlatoModel plato)
        {
            int res = -1;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Plato SET Estado ='{plato.Estado}'  WHERE IdPlato='{plato.IdPlato}';";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return res;
        }

        public IList<PlatoModel> ObtenerPorCategoria(string categoria)
        {
            throw new NotImplementedException();
        }

        public PlatoModel ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PlatoModel> ObtenerPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public IList<PlatoModel> ObtenerPorPrecio(decimal precio)
        {
            throw new NotImplementedException();
        }

        public IList<PlatoModel> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
