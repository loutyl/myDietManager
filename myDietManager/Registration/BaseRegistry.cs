using System.Data.Entity;
using myDietManager.IMP.Authentification;
using myDietManager.IMP.DietManagement;
using myDietManager.IMP.Entities.Converter;
using myDietManager.IMP.Entities.Repositories;
using myDietManager.IMP.POCO;
using myDietManager.ViewModel.Login;
using myDietManager.ViewModel.UserActionWindow;
using MyDietManagerAbstract.Abstraction.DietManagement;
using MyDietManagerAbstract.Abstraction.Security;
using MyDietManagerEntities;
using Registry = StructureMap.Configuration.DSL.Registry;

namespace myDietManager.Registration
{
    public class BaseRegistry : Registry
    {
        public BaseRegistry()
        {
            For<ILoginWindow>().Singleton().Use<LoginWindow>();
            For<ILoginWindowViewModel>().Use<LoginWindowViewModel>();

            For<IUserActionWindow>().Singleton().Use<UserActionWindow>();
            For<IUserActionWindowViewModel>().Use<UserActionWindowViewModel>();

            For<IAuthentifactionManager<User>>().Use<AuthentificationManager>();

            For<IDietManager>().Use<DietManager>();
            For<IDietCalculator>().Use<DietCalculator>();
        }
    }
}
