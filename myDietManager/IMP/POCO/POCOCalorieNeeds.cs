using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.Abstraction.Entities;

namespace myDietManager.IMP.POCO
{
    public class POCOCalorieNeeds : ICalorieNeeds
    {
        public int MaintenanceCalories { get; set; }
        public int DailyCalories { get; set; }
    }
}
