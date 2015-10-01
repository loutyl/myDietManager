namespace myDietManager.Model
{
    public class DietCalculator
    {
        public CalorieNeeds CreateUserCalorieNeeds(User newUser)
        {
            return new CalorieNeeds();
        }

        public Macronutrients CreateUserMacroRatio(int userDailyCalories)
        {
            return new Macronutrients();
        }
    }
}
