using System;
using System.Collections.Generic;
using myDietManager.Model;

namespace myDietManager.Class
{
    public class Macronutrients
    {
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }

        public static Macronutrients GetMacronutrientsRatios(DietProfile dietProfile)
        {
            var macrosRatios = dietProfile.Goal == "Lose" 
                ? new List<float>{ 0.4f, 0.4f, 0.2f } 
                : new List<float>{ 0.5f, 0.3f, 0.2f };

            var nutrients = new List<int>();

            macrosRatios.ForEach(ratio =>
            {
                var calorie = Math.Abs(dietProfile.CalorieNeeds.DailyCalories * ratio);
                var divider = ratio.Equals(0.2f) ? 9 : 4;  // Fat = 9 Calories for 1g - Carbs and Protein = 4 Calories for 1g
                var weight = Math.Abs(( calorie / divider ));
                nutrients.Add((int)weight);
            });

            return new Macronutrients
            {
                Carbohydrate = nutrients[0],
                Protein = nutrients[1],
                Fat = nutrients[2]
            };
        }

    }
}
