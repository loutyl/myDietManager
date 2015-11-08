using System;
using myDietManager.Model;

namespace myDietManager.Class
{
    [Serializable]
    public class CalorieNeeds
    {
        
        public int MaintenanceCalories { get; set; }
        public int DailyCalories { get; set; }

        public static CalorieNeeds GetProfileCalorieNeeds(DietProfile dietProfile)
        {
            var calorieNeeds = new CalorieNeeds
            {
                MaintenanceCalories = ((int) dietProfile.Weight*dietProfile.ActivityLevel)
            };
            calorieNeeds.DailyCalories = dietProfile.Goal == "Gain"
                ? (calorieNeeds.MaintenanceCalories + 250)
                : (calorieNeeds.MaintenanceCalories - 500);

            return calorieNeeds;
        }
    }
}
