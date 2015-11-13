using System.Collections.Generic;

namespace myDietManager.Model
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }

        public List<DietProfile> DietProfiles { get; set; }

    }
}
