namespace myDietManager.Entities.Repositories
{
    public class UserMacronutrientsRepository : BaseRepository<UserMacronutrients>
    {
        public UserMacronutrientsRepository(MyDietManagerDBEntities dbEntities) : base(dbEntities)
        {
        }
    }
}
