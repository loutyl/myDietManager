using System.Data.Entity;
using myDietManager.Abstraction.Repositories;
using myDietManager.Abstraction.Security;
using myDietManager.Abstraction.UnitOfWork;
using myDietManager.IMP.Authentification;
using myDietManager.IMP.Entities.Repositories;
using myDietManager.ViewModel.Login;
using Registry = StructureMap.Configuration.DSL.Registry;

namespace myDietManager.Registration
{
    public class StartingRegistry : Registry
    {
        public StartingRegistry()
        {
            For<ILoginWindow>().Singleton().Use<LoginWindow>();
            For<ILoginWindowViewModel>().Use<LoginWindowViewModel>();

            For<IAuthentifactionManager<User>>().Use<AuthentificationManager>();
            For<IBaseRepository<User>>().Use<UserRepository>();

            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<MyDietManagerDBEntities>();
        }
    }
}
