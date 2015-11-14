using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.Abstraction.Entities;
using myDietManager.Abstraction.Repositories;
using myDietManager.IMP.Entities.Repositories;
using myDietManager.ViewModel.Login;
using myDietManager.ViewModel.UserActionWindow;
using Microsoft.Win32;
using StructureMap;
using StructureMap.Configuration.DSL;
using Registry = StructureMap.Configuration.DSL.Registry;

namespace myDietManager.Registration
{
    public class StartingRegistry : Registry
    {
        public StartingRegistry()
        {
            For<ILoginWindow>().Singleton().Use<LoginWindow>();
            For<ILoginWindowViewModel>().Use<LoginWindowViewModel>();


            For<IBaseRepository<UsersDietProfile>>().Use<DietProfileRepository>();

        }
        
    }
}
