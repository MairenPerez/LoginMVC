using Login.Models;
using Microsoft.Data.SqlClient;

namespace Login.DAL
{
    public class UsuarioDAL
    {
        private string _connectionString = "Server=85.208.21.117,54321;" +
               "Database=MairenLogin;" +
               "User Id=sa;" +
               "Password=Sql#123456789;" +
               "TrustServerCertificate=True;";

        // Otener un usuario por UserName y Contraseña
        public Usuario GetUsuarioLogin(string userName, string passwordUser)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"SELECT * FROM Usuario 
                                                WHERE UserName = @UserName AND PasswordUser = @PasswordUser", connection);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@PasswordUser", passwordUser);

                // Abrimos conexión con la BBDD
                connection.Open();
                using(var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            IdUsuario = (int)reader["IdUsuario"],
                            UserName = (string)reader["UserName"],
                            PasswordUser = (string)reader["PasswordUser"],
                            Apellido = (string)reader["Apellido"],
                            Email = reader["Email"] as String,
                            FechaNacimiento = reader["FechaNacimiento"] as DateTime?,
                            Telefono = reader["Telefono"] as String,
                            Direccion = reader["Direccion"] as String,
                            Ciudad = reader["Ciudad"] as String,
                            Estado = reader["Estado"] as String,
                            CodigoPostal = reader["CodigoPostal"] as String,
                            FechaRegistro = reader["FechaRegistro"] as DateTime?,
                            Activo = reader["Activo"] as bool?
                        };
                    }
                    return null;
                }
            }
        }
    }
}
