using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDietManagerAbstract.Entities
{
    public interface IDietProfile
    {
        int UserDietProfileID { get; set; }
        string ProfileName { get; set; }
        double Weight { get; set; }
        double Height { get; set; }
        string Goal { get; set; }
        int DietDuration { get; set; }
        int ActivityLevel { get; set; }
        double WeightGoal { get; set; }
        int UserID { get; set; }
    }
}
