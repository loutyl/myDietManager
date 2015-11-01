using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using myDietManager.Class.Database;
using myDietManager.Model;

namespace myDietManager.Class.Security
{
    public class AuthentificationHandler
    {
        public User Authenticate(string username, string password)
        {
            var dbObject = new DatabaseObject();
            return dbObject.Authenticate(username, password);
        }
    }
}
