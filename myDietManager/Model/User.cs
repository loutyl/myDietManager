namespace myDietManager.Model
{
    public class User
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public float Weight { get; set; }
        public bool IsPound { get; set; }
        public bool IsKilo { get; set; }
        public float Height { get; set; }
        internal DietProfile DietProfile { get; set; }

        public User()
        {
            this.IsKilo = true;
        }

        public void CreateUserCalorieNeeds()
        {
            this.DietProfile.CalorieNeeds = new CalorieNeeds
            {
                MaintencanceCalories = (int)(!this.IsPound
                    ? (this.Weight * 2.2f) * this.DietProfile.ActivityLevel
                    : this.Weight * this.DietProfile.ActivityLevel)
            };

            this.DietProfile.CalorieNeeds.DailyCalories = this.DietProfile.IsGain
                ? (this.DietProfile.CalorieNeeds.MaintencanceCalories + 250)
                : (this.DietProfile.CalorieNeeds.MaintencanceCalories - 500);
        }

        public void CreateUserMacroRatio()
        {
            this.DietProfile.Macros = new Macronutrients
            {
                Carbohydrate = new Carbohydrate((int)(this.DietProfile.CalorieNeeds.DailyCalories * 0.4)),
                Protein = new Protein((int)(this.DietProfile.CalorieNeeds.DailyCalories * 0.4)),
                Fat = new Fat((int)(this.DietProfile.CalorieNeeds.DailyCalories * 0.2))
            };
        }
    }
}
