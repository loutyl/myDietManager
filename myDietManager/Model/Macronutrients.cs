﻿namespace myDietManager.Model
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
        public Protein(int calorie)
        {
            this.Calorie = calorie;
            this.Weight = (this.Calorie / 4);
        }

        public float Weight { get; set; }
        public int Calorie { get; set; }
    }

    public class Carbohydrate : INutrients
    {
        public Carbohydrate()
        {
            Calorie = 4;
            Weight = 1;
        }

        public Carbohydrate(int calorie)
        {
            this.Calorie = calorie;
            this.Weight = (this.Calorie / 4);
        }

        public float Weight { get; set; }
        public int Calorie { get; set; }
    }

    public class Fat : INutrients
    {
        public Fat()
        {
            Calorie = 9;
            Weight = 1;
        }

        public Fat(int calorie)
        {
            this.Calorie = calorie;
            this.Weight = (this.Calorie / 4);
        }

        public float Weight { get; set; }
        public int Calorie { get; set; }
    }
}
