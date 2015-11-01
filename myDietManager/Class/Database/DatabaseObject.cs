using System.Configuration;
using System.Data.SqlClient;
using myDietManager.Model;

namespace myDietManager.Class.Database
{
    public class DatabaseObject
    {
        private readonly SqlConnection _dbConnection;
        public string DatabaseQuery { get; set; }

        public DatabaseObject()
        {
            this._dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
        }

        public User Authenticate(string username, string password)
        {
            this.DatabaseQuery = @"SELECT * FROM [User] WHERE UserName = @Username AND Password = @Password;";

            using ( var command = new SqlCommand(this.DatabaseQuery, this._dbConnection) )
            {
                this._dbConnection.Open();
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                using ( var reader = command.ExecuteReader() )
                {
                    return reader.Read() ? new User
                    {
                        LastName = reader["lastname"].ToString().Trim(),
                        Name = reader["name"].ToString().Trim(),
                        Age = (int)reader["age"],
                        Gender = reader["gender"].ToString().Trim()
                    } : null;
                }
            }
        }
    }
}
