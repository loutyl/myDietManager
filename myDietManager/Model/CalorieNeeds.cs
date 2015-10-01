namespace myDietManager.Model
{
    public class CalorieNeeds
    {
        public int Bmr { get; set; }
        public int MaintencanceCalories { get; set; }
        public int DailyCalories { get; set; }
        public CalorieNeeds() { }

        public CalorieNeeds(int bmr, int maintenanceCalories, int dailyCalories)
        {
            this.Bmr = bmr;
            this.MaintencanceCalories = maintenanceCalories;
            this.DailyCalories = dailyCalories;
        }

    }
}
