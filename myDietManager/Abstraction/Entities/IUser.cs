using System.Collections.Generic;

namespace myDietManager.Abstraction.Entities
{
    public interface IUser
    {
        int UserID { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string LastName { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        string Gender { get; set; }
        string Role { get; set; }

        IEnumerable<IDietProfile> DietProfiles { get; set; }
    }
}
