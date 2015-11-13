namespace myDietManager.Entities.Repositories
{
    public class UserCalorieNeedsRepository : BaseRepository<UserCalorieNeeds>
    {
        public UserCalorieNeedsRepository(MyDietManagerDBEntities dbEntities) : base(dbEntities)
        {
        }
    }
}
