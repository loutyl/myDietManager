using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using myDietManager.Class.Serialization;
using myDietManager.Model;
using System.Linq;
using myDietManager.Entities;

namespace myDietManager.Class.Database
{
    public class DatabaseObject
    {
        private readonly UnitOfWork _unitOfWork;

        public DatabaseObject()
        {
            this._unitOfWork = new UnitOfWork(new MyDietManagerDBEntities());
        }

        public User Authenticate(string username, string password)
        {
            using (var context = new MyDietManagerDBEntities())
            {
                return context.User.Single(user => user.UserName == username && user.Password == password);
            }
        }

        public void CompleteDietProfileCreation(DietProfile dietProfile)
        {
            var dietProfileEntity = new UsersDietProfile
            {
                ProfileName = dietProfile.ProfileName,
                Weight = dietProfile.Weight,
                Height = dietProfile.Height,
                Goal = dietProfile.Goal,
                DietDuration = dietProfile.DietDuration,
                ActivityLevel = dietProfile.ActivityLevel,
                WeightGoal = dietProfile.WeightGoal,
                UserID = dietProfile.UserID
            };

            dietProfile.UserDietProfileID = this._unitOfWork.DietProfileRepository.Insert(dietProfileEntity);

            var calorieNeedsEntity = new UserCalorieNeeds
            {
                DailyCalories = dietProfile.CalorieNeeds.DailyCalories,
                MaintenanceCalories = dietProfile.CalorieNeeds.MaintenanceCalories,
                UserDietProfileID = dietProfile.UserDietProfileID
            };
            this._unitOfWork.CalorieNeedsRepository.InsertWithoutSaving(calorieNeedsEntity);

            var macronutrientsEntity = new UserMacronutrients
            {
                UserDietProfileID = dietProfile.UserDietProfileID,
                Protein = dietProfile.Macros.Protein,
                Carbohydrate = dietProfile.Macros.Carbohydrate,
                Fat = dietProfile.Macros.Fat
            };
            this._unitOfWork.MacronutrientsRepository.InsertWithoutSaving(macronutrientsEntity);
            this._unitOfWork.Save();
        }

        public bool UserHasDietProfile(User user)
        {
            return this._unitOfWork.DietProfileRepository.Exists(user.UserID);
        }

        public IEnumerable<string> GetUserDietProfileNames(User user)
        {
            return this._unitOfWork.DietProfileRepository.GetDietProfileName(user);
        }
    }
}
