using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class RepositorioUsuario : RepositorioBase, IRepositorioUsuario
    {
        public  RepositorioUsuario(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(UsuarioModel usuario)
        {
            int res = -1;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql= $"INSERT INTO Usuario (Email,FecNac,Lat,Lon,Direccion,NumCelular,Password)"+
                            $"VALUES('{usuario.Email}','{usuario.FecNac}','{usuario.Lat}','{usuario.Lon}','{usuario.Direccion}','{usuario.NumCelular}','{usuario.Password}');";

                using(SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    usuario.IdUsuario = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Usuario WHERE IdUsuario = {id}";
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

        public int Modificacion(UsuarioModel usuario)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Usuario SET Email = '{usuario.Email}', FecNac ='{usuario.FecNac}',Lat='{usuario.Lat}',Lon='{usuario.Lon}',Direccion='{usuario.Direccion}'," +
                           $"NumCelular='{usuario.NumCelular}',Password='{usuario.Password}' WHERE IdUsuario='{usuario.IdUsuario}';";
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

        public UsuarioModel ObtenerPorEmail(string email)
        {
            UsuarioModel usuario = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Usuario WHERE Usuario.Email ='{email}';";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        usuario = new UsuarioModel()
                        {
                            IdUsuario = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FecNac = reader.GetDateTime(2),
                            Lat = reader.GetDecimal(3),
                            Lon = reader.GetDecimal(4),
                            Direccion = reader.GetString(5),
                            NumCelular = reader.GetString(6),
                            Password = reader.GetString(7)
                        };
                    }
                    connection.Close();
                }
            }
            return usuario;

        }

        public UsuarioModel BuscarPorCelular(string celular)
        {
            UsuarioModel usuario = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Usuario WHERE Usuario.NumCelular ='{celular}';";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        usuario = new UsuarioModel()
                        {
                            IdUsuario = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FecNac = reader.GetDateTime(2),
                            Lat = reader.GetDecimal(3),
                            Lon = reader.GetDecimal(4),
                            Direccion = reader.GetString(5),
                            NumCelular = reader.GetString(6),
                            Password = reader.GetString(7)
                        };
                    }
                    connection.Close();
                }
            }
            return usuario;

        }

        public UsuarioModel ObtenerPorId(int id)
        {
            UsuarioModel usuario = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Usuario WHERE Usuario.IdUsuario ='{id}';";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        usuario = new UsuarioModel()
                        {
                            IdUsuario = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FecNac = reader.GetDateTime(2),
                            Lat = reader.GetDecimal(3),
                            Lon = reader.GetDecimal(4),
                            Direccion = reader.GetString(5),
                            NumCelular = reader.GetString(6),
                            Password = reader.GetString(7)
                        };
                    }
                    connection.Close();
                }
            }
            return usuario;
        }

        public IList<UsuarioModel> ObtenerTodos()
        {
            IList<UsuarioModel> usuarios = new List<UsuarioModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Usuario;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        UsuarioModel usuario = new UsuarioModel()
                        {
                            IdUsuario = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            FecNac = reader.GetDateTime(2),
                            Lat = reader.GetDecimal(3),
                            Lon = reader.GetDecimal(4),
                            Direccion = reader.GetString(5),
                            NumCelular = reader.GetString(6),
                            Password = reader.GetString(7)
                        };
                        usuarios.Add(usuario);
                    }
                    connection.Close();
                }
            }
            return usuarios;

        }
    }
}
