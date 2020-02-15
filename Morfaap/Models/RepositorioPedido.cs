using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class RepositorioPedido : RepositorioBase, IRepositorioPedido
    {
        public RepositorioPedido(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(PedidoModel ob)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Pedido (Fecha,Estado,IdUsuario)" +
                            $"VALUES('{ob.Fecha}','{ob.Estado}','{ob.Usuario.IdUsuario}');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    ob.IdPedido = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int ModificarEstadoPedido(PedidoModel pedido)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Pedido SET Estado = '{pedido.Estado}' WHERE IdPedido='{pedido.IdPedido}';";
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

        public int Baja(int id)
        {
            throw new NotImplementedException();
        }

        public int Modificacion(PedidoModel ob)
        {
            throw new NotImplementedException();
        }

        public PedidoModel ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PedidoModel> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public PedidoModel ObtenerPorUsuario(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
