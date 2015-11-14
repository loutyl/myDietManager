using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.View.ProfileCreationViews;
using myDietManager.View.ProfileCreationViews.Interfaces;
using myDietManager.ViewModel.ProfileCreation.Views;
using myDietManager.ViewModel.ProfileCreation.Window;
using StructureMap.Configuration.DSL;

namespace myDietManager.Registration
{
    public class DietProfileCreationRegistry : Registry
    {
        public DietProfileCreationRegistry()
        {
            For<IProfileCreationWindow>().Singleton().Use<ProfileCreationWindow>();
            For<IProfileCreationWindowViewModel>().Use<ProfileCreationWindowViewModel>();

            For<IProfileCreationChoiceView>().Use<ProfileCreationChoiceView>();
            For<IProfileCreationChoiceViewModel>().Use<ProfileCreationChoiceViewModel>();

            For<IManualProfileCreationView>().Use<ManualProfileCreationView>();
            For<IManualProfileCreationViewModel>().Use<ManualProfileCreationViewModel>();

            For<IAutoProfileCreationView>().Use<AutoProfileCreationView>();
            For<IAutoProfileCreationViewModel>().Use<AutoProfileCreationViewModel>();

            For<IProfileCreationRecapView>().Use<ProfileCreationRecapView>();
            For<IProfileCreationRecapViewModel>().Use<ProfileCreationRecapViewModel>();

        }
    }
}
