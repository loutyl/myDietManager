namespace MyDietManagerAbstract.Abstraction.Entities
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
        ICalorieNeeds CalorieNeeds { get; set; }
        IMacronutrients Macronutrients { get; set; }
    }
}
