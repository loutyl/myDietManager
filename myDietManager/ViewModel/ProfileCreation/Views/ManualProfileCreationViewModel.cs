using myDietManager.View.ProfileCreationViews.Interfaces;
using myDietManager.ViewModel.Base;
using myDietManager.ViewModel.ProfileCreation.Window;
using StructureMap;

namespace myDietManager.ViewModel.ProfileCreation.Views
{
    public class ManualProfileCreationViewModel : BaseViewModel, IManualProfileCreationViewModel
    {
        private readonly ProfileCreationWindowViewModel _profileCreationWindow;

        public ManualProfileCreationViewModel(IManualProfileCreationView view, IContainer container)
            : base(view, container)
        {
            
        }
    }
}
