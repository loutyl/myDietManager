using System.Data.Entity;
using myDietManager.Abstraction.DietManagement;
using myDietManager.Abstraction.Entities;
using myDietManager.Abstraction.Repositories;
using myDietManager.Abstraction.Security;
using myDietManager.Abstraction.UnitOfWork;
using myDietManager.IMP.Authentification;
using myDietManager.IMP.DietManagement;
using myDietManager.IMP.Entities.Converter;
using myDietManager.IMP.Entities.Repositories;
using myDietManager.IMP.POCO;
using myDietManager.ViewModel.Login;
using myDietManager.ViewModel.UserActionWindow;
using Registry = StructureMap.Configuration.DSL.Registry;

namespace myDietManager.Registration
{
    public class StartingRegistry : Registry
    {
        public StartingRegistry()
        {
            For<ILoginWindow>().Singleton().Use<LoginWindow>();
            For<ILoginWindowViewModel>().Use<LoginWindowViewModel>();

            For<IUserActionWindow>().Singleton().Use<UserActionWindow>();
            For<IUserActionWindowViewModel>().Use<UserActionWindowViewModel>();

            For<IAuthentifactionManager<User>>().Use<AuthentificationManager>();

            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<MyDietManagerDBEntities>();
            For<IRepository<User>>().Use<UserRepository>();
            For<IRepository<UsersDietProfile>>().Use<DietProfileRepository>();
            For<IRepository<UserMacronutrients>>().Use<MacronutrientsRepository>();
            For<IRepository<UserCalorieNeeds>>().Use<CalorieNeedsRepository>();

            For<IConverter<User, IUser>>().Use<UserEntityConverter>();
            For<IConverter<UsersDietProfile, IDietProfile>>().Use<DietProfileEntityConverter>();
            For<IConverter<UserMacronutrients, IMacronutrients>>().Use<MacronutrientsEntityConverter>();
            For<IConverter<UserCalorieNeeds, ICalorieNeeds>>().Use<CalorieNeedsEntityConverter>();

            For<IUser>().Use<POCOUser>();
            For<IDietProfile>().Use<POCODietProfile>();
            For<IMacronutrients>().Use<POCOMacronutrients>();
            For<ICalorieNeeds>().Use<POCOCalorieNeeds>();

            For<IDietManager>().Use<DietManager>();
            For<IDietCalculator>().Use<DietCalculator>();
        }
    }
}
