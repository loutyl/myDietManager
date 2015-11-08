using myDietManager.Model;

namespace myDietManager.Class
{
    public class DietCalculator
    {
        public static void FinalizeDietProfileCreation(DietProfile dietProfile)
        {
            dietProfile.CalorieNeeds = CalorieNeeds.GetProfileCalorieNeeds(dietProfile);
            dietProfile.Macros = Macronutrients.GetMacronutrientsRatios(dietProfile);
        }
    }
}
