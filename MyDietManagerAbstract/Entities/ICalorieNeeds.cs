using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDietManagerAbstract.Entities
{
    public interface ICalorieNeeds
    {
        int MaintenanceCalories { get; set; }
        int DailyCalories { get; set; }

        ICalorieNeeds GetCalorieNeeds(IDietProfile dietProfile);
    }
}
