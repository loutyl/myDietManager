namespace myDietManager.Entities.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyDietManagerDBEntities dbEntities) : base(dbEntities)
        {
        }
    }
}
