using System.Collections.Generic;

namespace myDietManager.Model
{
    public class DietProfile
    {
        public bool IsLose { get; set; } = true;
        public bool IsGain { get; set;}
        public int DietDuration { get; set; }
        public float WeightGoal { get; set; }
        public int ActivityLevel { get; set; } = 14;
        internal CalorieNeeds CalorieNeeds { get; set; }
        internal Macronutrients Macros { get; set; }

        public List<float> GetMacroRatios()
        {
            //Carbs - Protein - Fat
            return this.IsLose ? new List<float>() {0.4f, 0.4f, 0.2f} : new List<float>() {0.5f, 0.3f, 0.2f};
        }

    }
}
