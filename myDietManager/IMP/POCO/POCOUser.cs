using System.Collections.Generic;
using MyDietManagerAbstract.Abstraction.Entities;

namespace myDietManager.IMP.POCO
{
    public class POCOUser : IUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public IEnumerable<IDietProfile> DietProfiles { get; set; }
    }
}
