using myDietManager.Abstraction.Entities;

namespace myDietManager.IMP.POCO
{
    public class POCODietProfile : IDietProfile
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
        public ICalorieNeeds CalorieNeeds { get; set; }
        public IMacronutrients Macronutrients { get; set; }
    }
}
