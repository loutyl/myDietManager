using System.Collections.Generic;
using System.Linq;

namespace myDietManager.Model
{
    public class DietProfile
    {
        public bool IsLose { get; set; } = true;
        public bool IsGain { get; set;}
        public int DietDuration { get; set; }
        public float WeightGoal { get; set; }
        public int ActivityLevel { get; set; }
        internal CalorieNeeds CalorieNeeds { get; set; }
        internal Macronutrients Macros { get; set; }

        public DietProfile()
        {
            this.ActivityLevel = 14;
        }
    }
}
