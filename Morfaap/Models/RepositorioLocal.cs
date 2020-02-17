using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Morfaap.Models
{
    public class RepositorioLocal : RepositorioBase,IRepositorioLocal
    {
        public RepositorioLocal(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(LocalModel ob)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO Local (Nombre,Lat,Lon,Direccion,NumCelular,IdPropietario)" +
                            $"VALUES('{ob.Nombre}','{ob.Lat}','{ob.Lon}','{ob.Direccion}','{ob.NumCelular}','{ob.IdPropietario}');";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    res = command.ExecuteNonQuery();
                    command.CommandText = "SELECT SCOPE_IDENTITY()";
                    var id = command.ExecuteScalar();
                    ob.IdPropietario = Convert.ToInt32(id);
                    connection.Close();
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LocalModel> BuscarPorNombre(string nombre)
        {
            IList<LocalModel> locales = new List<LocalModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Local l INNER JOIN Usuario u ON l.IdPropietario = u.IdUsuario WHERE l.nombre='{nombre}';";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        LocalModel local = new LocalModel()
                        { IdLocal= reader.GetInt32(0),
                          Nombre= reader.GetString(1),
                          Lat= reader.GetDecimal(2),
                          Lon= reader.GetDecimal(3),
                          Direccion = reader.GetString(4),
                          NumCelular = reader.GetString(5),
                          IdPropietario = reader.GetInt32(6),
                          Propietario = new UsuarioModel()
                          {
                             IdUsuario= reader.GetInt32(6),
                             Email = reader.GetString(7),
                             FecNac = reader.GetDateTime(8),
                             Lat = reader.GetDecimal(9),
                             Lon = reader.GetDecimal(10),
                             Direccion = reader.GetString(11),
                             NumCelular = reader.GetString(12),
                             Password = reader.GetString(13)

                          }
                        };
                        locales.Add(local);
                    }
                    connection.Close();
                }
            }
            return locales;

        }

        public int Modificacion(LocalModel ob)
        {
            throw new NotImplementedException();
        }

        public LocalModel ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LocalModel> ObtenerPorPuntuacion(int puntuacion)
        {
            IList<LocalModel> locales = new List<LocalModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Local l INNER JOIN Usuario u ON l.IdPropietario = u.IdUsuario WHERE l.Puntuacion='{puntuacion}';";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        LocalModel local = new LocalModel()
                        {
                            IdLocal = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Lat = reader.GetDecimal(2),
                            Lon = reader.GetDecimal(3),
                            Direccion = reader.GetString(4),
                            NumCelular = reader.GetString(5),
                            IdPropietario = reader.GetInt32(6),
                            Propietario = new UsuarioModel()
                            {
                                IdUsuario = reader.GetInt32(6),
                                Email = reader.GetString(7),
                                FecNac = reader.GetDateTime(8),
                                Lat = reader.GetDecimal(9),
                                Lon = reader.GetDecimal(10),
                                Direccion = reader.GetString(11),
                                NumCelular = reader.GetString(12),
                                Password = reader.GetString(13)

                            }
                        };
                        locales.Add(local);
                    }
                    connection.Close();
                }
            }
            return locales;
        }

        public IList<LocalModel> ObtenerTodos()
        {
            IList<LocalModel> locales = new List<LocalModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Local l INNER JOIN Usuario u ON l.IdPropietario = u.IdUsuario ;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        LocalModel local = new LocalModel()
                        {
                            IdLocal = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Lat = reader.GetDecimal(2),
                            Lon = reader.GetDecimal(3),
                            Direccion = reader.GetString(4),
                            NumCelular = reader.GetString(5),
                            IdPropietario = reader.GetInt32(6),
                            Propietario = new UsuarioModel()
                            {
                                IdUsuario = reader.GetInt32(6),
                                Email = reader.GetString(7),
                                FecNac = reader.GetDateTime(8),
                                Lat = reader.GetDecimal(9),
                                Lon = reader.GetDecimal(10),
                                Direccion = reader.GetString(11),
                                NumCelular = reader.GetString(12),
                                Password = reader.GetString(13)

                            }
                        };
                        locales.Add(local);
                    }
                    connection.Close();
                }
            }
            return locales;
        }
    }
}
