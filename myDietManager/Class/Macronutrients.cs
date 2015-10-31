namespace myDietManager.Class
{
    public class Macronutrients
    {
        public Nutrient Protein { get; set; }
        public Nutrient Carbohydrate { get; set; }
        public Nutrient Fat { get; set; }
    }

    public class Nutrient
    {
        public int Weight { get; set; }
        public int Calorie { get; set; }

        public Nutrient(int calorie, int weight)
        {
            this.Weight = weight;
            this.Calorie = calorie;
        }
    }
}
