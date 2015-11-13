using myDietManager.Entities.Repositories;

namespace myDietManager.Entities
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDietManagerDBEntities _dbEntities;
        private UsersDietProfileRepository _dietProfileRepository;
        private UserCalorieNeedsRepository _calorieNeedsRepository;
        private UserMacronutrientsRepository _macronutrientsRepository;
        private UserRepository _userRepository;

        public UnitOfWork(MyDietManagerDBEntities dbEntities)
        {
            this._dbEntities = dbEntities;
        }

        public UsersDietProfileRepository DietProfileRepository => this._dietProfileRepository ?? (this._dietProfileRepository = new UsersDietProfileRepository(this._dbEntities));

        public UserCalorieNeedsRepository CalorieNeedsRepository => this._calorieNeedsRepository ?? ( this._calorieNeedsRepository = new UserCalorieNeedsRepository(this._dbEntities) );

        public UserMacronutrientsRepository MacronutrientsRepository => this._macronutrientsRepository ?? ( this._macronutrientsRepository = new UserMacronutrientsRepository(this._dbEntities) );

        public UserRepository UserRepository => this._userRepository ?? ( this._userRepository = new UserRepository(this._dbEntities) );

        public void Save()
        {
            this._dbEntities.SaveChanges();
        }
    }
}
