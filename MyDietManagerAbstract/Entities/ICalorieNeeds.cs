namespace MyDietManagerAbstract.Entities
{
    public interface ICalorieNeeds
    {
        int MaintenanceCalories { get; set; }
        int DailyCalories { get; set; }
    }
}
