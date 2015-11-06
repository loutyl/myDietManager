using System;
using myDietManager.Model;

namespace myDietManager.Class
{
    [Serializable]
    public class CalorieNeeds
    {
        public int MaintencanceCalories { get; set; }
        public int DailyCalories { get; set; }

        public static CalorieNeeds GetProfileCalorieNeeds(DietProfile dietProfile)
        {
            var calorieNeeds = new CalorieNeeds
            {
                MaintencanceCalories = ((int) dietProfile.Weight*dietProfile.ActivityLevel)
            };
            calorieNeeds.DailyCalories = dietProfile.Goal == Goal.Gain
                ? (calorieNeeds.MaintencanceCalories + 250)
                : (calorieNeeds.MaintencanceCalories - 500);

            return calorieNeeds;
        }
    }
}
