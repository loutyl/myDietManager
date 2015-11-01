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
