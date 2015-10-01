namespace myDietManager.Model
{
    public class Macronutrients
    {
        public Protein Protein { get; set; }
        public Carbohydrate Carbohydrate { get; set; }
        public Fat Fat { get; set; }

        public Macronutrients()
        {
            this.Protein = new Protein();
            this.Carbohydrate = new Carbohydrate();
            this.Fat = new Fat();

        }
    }

    public interface INutrients
    {
        float Weight { get; }
        int Calorie { get; }

    }

    public class Protein : INutrients
    {
        public Protein()
        {
            Calorie = 4;
            Weight = 1;
        }

        public float Weight { get; private set; }
        public int Calorie { get; private set; }
    }

    public class Carbohydrate : INutrients
    {
        public Carbohydrate()
        {
            Calorie = 4;
            Weight = 1;
        }

        public float Weight { get; private set; }
        public int Calorie { get; private set; }
    }

    public class Fat : INutrients
    {
        public Fat()
        {
            Calorie = 9;
            Weight = 1;
        }

        public float Weight { get; private set; }
        public int Calorie { get; private set; }
    }
}
