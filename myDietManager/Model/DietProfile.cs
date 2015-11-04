using System;
using System.Collections.Generic;
using System.ComponentModel;
using myDietManager.Class;

namespace myDietManager.Model
{
    public enum Goal
    {
        Lose,
        Gain
    };

    [Serializable]
    public class DietProfile : IDataErrorInfo
    {
        public string ProfileName { get; set; } = "test";
        public float Weight { get; set; }
        public float Height { get; set; }
        public Goal Goal { get; set; }
        public int DietDuration { get; set; }
        public int ActivityLevel { get; set; } = 14;
        public float WeightGoal { get; set; }
        public int UserId { get; set; }
        public CalorieNeeds CalorieNeeds { get; set; }
        public Macronutrients Macros { get; set; }

        public DietProfile() { }

        public DietProfile(CalorieNeeds calorieNeeds, Macronutrients macros)
        {
            this.CalorieNeeds = calorieNeeds;
            this.Macros = macros;
        }

        public string this[string attributeName]
        {
            get
            {
                switch (attributeName)
                {
                    case "Weight":
                        return (Math.Abs(this.Weight) < (35 * 2.2f) || Math.Abs(this.Weight) > (250 * 2.2f))
                            ? "The weight entered is incorrect."
                            : string.Empty;
                    case "Height":
                        return (Math.Abs(this.Height) < 100 || Math.Abs(this.Height) > 300)
                            ? "The height entered is incorrect."
                            : string.Empty;
                    case "DietDuration":
                        return this.DietDuration < 6
                            ? "The value entered is too low."
                            : string.Empty;
                    case "WeightGoal":
                        return (Math.Abs(this.Weight) < (35 * 2.2f) || Math.Abs(this.Weight) > (250 * 2.2f))
                            ? "The weight entered is incorrect."
                            : string.Empty;
                    default:
                        throw new ApplicationException("Unknow attribute being validated.");
                }
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        private void CreateProfileMacroRatio()
        {   
            //Carbs - Protein // Fat
            var macrosRatios = this.Goal == Goal.Lose ? new List<float>() {0.4f, 0.4f, 0.2f} : new List<float>() {0.5f, 0.3f, 0.2f};
            var nutrients = new List<Nutrient>();

            macrosRatios.ForEach(ratio =>
            {
                var calorie = Math.Abs(this.CalorieNeeds.DailyCalories * ratio);
                var divider = ratio.Equals(0.2f) ? 9 : 4;  // Fat = 9 Calories for 1g - Carbs and Protein = 4 Calories for 1g
                var weight = Math.Abs(( calorie / divider ));
                nutrients.Add(new Nutrient((int)calorie, (int)weight));
            });

            this.Macros = new Macronutrients
            {
                Carbohydrate = new Nutrient(nutrients[0].Calorie, nutrients[0].Weight),
                Protein = new Nutrient(nutrients[1].Calorie, nutrients[1].Weight),
                Fat = new Nutrient(nutrients[2].Calorie, nutrients[2].Weight)
            };
        }

        private void CreateProfileCalorieNeeds()
        {
            this.CalorieNeeds = new CalorieNeeds
            {
                MaintencanceCalories = (int)this.Weight * this.ActivityLevel
            };

            this.CalorieNeeds.DailyCalories = this.Goal == Goal.Gain
                ? ( this.CalorieNeeds.MaintencanceCalories + 250 )
                : ( this.CalorieNeeds.MaintencanceCalories - 500 );
        }

        public void FinalizeProfileCreation()
        {
            this.CreateProfileCalorieNeeds();
            this.CreateProfileMacroRatio();
        }
    }
}

