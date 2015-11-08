using myDietManager.Class;

namespace myDietManager.Model
{
    public class DietProfile
    {
        public int UserDietProfileID { get; set; }
        public string ProfileName { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Goal { get; set; }
        public int DietDuration { get; set; }
        public int ActivityLevel { get; set; }
        public double WeightGoal { get; set; }
        public int UserID { get; set; }
        public CalorieNeeds CalorieNeeds { get; set; }
        public Macronutrients Macros { get; set; }
    }
}

