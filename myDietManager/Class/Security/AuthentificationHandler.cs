using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using myDietManager.Model;

namespace myDietManager.Class.Security
{
    public class AuthentificationHandler
    {
        public User Authenticate(string username, string password)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;

            const string queryText = @"SELECT * FROM [User] WHERE UserName = @Username AND Password = @Password;";

            using (var connection = new SqlConnection(connectionString))
            {
                using ( var command = new SqlCommand(queryText, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using ( var reader = command.ExecuteReader() )
                    {
                        return reader.Read() ? new User
                        {
                            LastName = reader["LastName"].ToString().Trim(),
                            Name = reader["Name"].ToString().Trim(),
                            Age = (int)reader["Age"],
                            Gender = reader["Gender"].ToString().Trim()
                        } : null;
                    }
                }
            }
        }
    }
}
