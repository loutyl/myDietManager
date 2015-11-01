using System;

namespace myDietManager.Class
{
    [Serializable]
    public class Macronutrients
    {
        public Nutrient Protein { get; set; }
        public Nutrient Carbohydrate { get; set; }
        public Nutrient Fat { get; set; }
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
