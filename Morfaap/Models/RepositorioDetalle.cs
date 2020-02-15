using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class RepositorioDetalle : RepositorioBase, IRepositorioDetalle
    {
        public RepositorioDetalle(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(DetalleModel ob)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Detalle (IdPedido,IdPlato)" +
                            $"VALUES('{ob.Pedido.IdPedido}','{ob.Plato.IdPlato}');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    ob.IdDetalle = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            throw new NotImplementedException();
        }

        public int Modificacion(DetalleModel ob)
        {
            throw new NotImplementedException();
        }

        public DetalleModel ObtenerDetallePorPedido(PedidoModel pedido)
        {
            DetalleModel detalle = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Detalle,Pedido,Plato WHERE Detalle.IdPedido = '{pedido.IdPedido}' AND  Detalle.IdPLato = Plato.IdPlato;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        detalle = new DetalleModel()
                        {
                            IdDetalle = reader.GetInt32(0),
                            IdPedido = reader.GetInt32(1),
                            Pedido = new PedidoModel()
                            {
                                IdPedido = reader.GetInt32(1),
                                Fecha = reader.GetDateTime(2),
                                Estado = reader.GetString(3),
                                IdUsuario = reader.GetInt32(4),
                                
                            },
                            IdPlato = reader.GetInt32(5),
                            Plato = new PlatoModel()
                            {
                                IdPlato = reader.GetInt32(5),
                                Nombre = reader.GetString(6),
                                Categoria = reader.GetString(7),
                                Precio = reader.GetDecimal(8),
                                Estado = reader.GetString(9),
                                IdMenu = reader.GetInt32(10)
                            }
                            
                                 
                             
                        };
                    }
                    connection.Close();
                }
            }


            return detalle;

        }

        public DetalleModel ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DetalleModel> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
