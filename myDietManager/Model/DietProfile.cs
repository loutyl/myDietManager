namespace myDietManager.Model
{
    public class DietProfile
    {
        public string Goal { get; set; }
        public int DietDuration { get; set; }
        public float WeightGoal { get; set; }
        public int ActivityLevel { get; set; }
        internal CalorieNeeds CalorieNeeds { get; set; }
        internal Macronutrients Macros { get; set; }

        public DietProfile() { }

        public DietProfile(DietProfileInformations informations)
        {
            this.Goal = informations.Goal;
            this.DietDuration = informations.DietDuration;
            this.WeightGoal = informations.WeightGoal;
            this.ActivityLevel = informations.ActivityLevel;
        }
    }
}
