using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class RepositorioComentario : RepositorioBase , IRepositorioComentario
    {
        public RepositorioComentario(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(ComentarioModel ob)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Comentario (IdUsuario,IdLocal,Comentario,Puntuacion)" +
                            $"VALUES('{ob.IdUsuario}','{ob.IdLocal}','{ob.Comentario}','{ob.Puntuacion}');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    ob.IdUsuario = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            throw new NotImplementedException();
        }

        public int Modificacion(ComentarioModel ob)
        {
            throw new NotImplementedException();
        }

        public IList<ComentarioModel> ObtenerComentarioPorLocal(LocalModel local)
        {
            throw new NotImplementedException();
        }

        public IList<ComentarioModel> ObtenerComentarioPorPuntuacion(int puntuacion)
        {
            throw new NotImplementedException();
        }

        public IList<ComentarioModel> ObtenerComentarioPorUsuario(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public ComentarioModel ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ComentarioModel> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
