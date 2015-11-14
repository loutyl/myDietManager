using myDietManager.Abstraction.Entities;
using myDietManager.ViewModel.Base;
using StructureMap;

namespace myDietManager.ViewModel.ProfileCreation.Window
{
    public class ProfileCreationWindowViewModel : BaseWindowViewModel, IProfileCreationWindowViewModel
    {
        private IViewModel _currentViewModel;
        public IUser User { get; set; }

        public IViewModel CurrentViewModel
        {
            get { return this._currentViewModel; }
            set
            {
                if (this._currentViewModel == value) return;

                this._currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public ProfileCreationWindowViewModel(IProfileCreationWindow profileCreationWindow, IContainer container)
            : base(profileCreationWindow, container)
        {
        }
    }
}
