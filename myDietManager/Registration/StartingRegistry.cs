using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.Abstraction.Entities;
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
            For<ILoginWindowViewModel>().Use<LoginWindowViewModel>();
        }
        
    }
}
