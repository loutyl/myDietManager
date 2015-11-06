using System;
using System.Collections.Generic;
using myDietManager.Model;

namespace myDietManager.Class
{
    [Serializable]
    public class Macronutrients
    {
        public Nutrient Protein { get; set; }
        public Nutrient Carbohydrate { get; set; }
        public Nutrient Fat { get; set; }

        public static Macronutrients GetMacronutrientsRatios(DietProfile dietProfile)
        {
            var macrosRatios = dietProfile.Goal == Goal.Lose 
                ? new List<float>{ 0.4f, 0.4f, 0.2f } 
                : new List<float>{ 0.5f, 0.3f, 0.2f };

            var nutrients = new List<Nutrient>();

            macrosRatios.ForEach(ratio =>
            {
                var calorie = Math.Abs(dietProfile.CalorieNeeds.DailyCalories * ratio);
                var divider = ratio.Equals(0.2f) ? 9 : 4;  // Fat = 9 Calories for 1g - Carbs and Protein = 4 Calories for 1g
                var weight = Math.Abs(( calorie / divider ));
                nutrients.Add(new Nutrient((int)calorie, (int)weight));
            });

            return new Macronutrients
            {
                Carbohydrate = new Nutrient(nutrients[0].Calorie, nutrients[0].Weight),
                Protein = new Nutrient(nutrients[1].Calorie, nutrients[1].Weight),
                Fat = new Nutrient(nutrients[2].Calorie, nutrients[2].Weight)
            };
        }

    }

    [Serializable]
    public class Nutrient
    {
        public int Weight { get; set; }
        public int Calorie { get; set; }

        public Nutrient(){}

        public Nutrient(int calorie, int weight)
        {
            this.Weight = weight;
            this.Calorie = calorie;
        }
    }
}
