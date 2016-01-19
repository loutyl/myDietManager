using myDietManager.ViewModel.Base;
using myDietManager.ViewModel.ProfileCreation.Views;
using MyDietManagerAbstract.Abstraction.Entities;
using StructureMap;

namespace myDietManager.ViewModel.ProfileCreation.Window
{
    public class ProfileCreationWindowViewModel : BaseWindowViewModel, IProfileCreationWindowViewModel
    {
        private IWindowViewModel _currentViewModel;
        public IUser User { get; set; }

        public ProfileCreationWindowViewModel(IProfileCreationWindow profileCreationWindow, IContainer container)
            : base(profileCreationWindow, container)
        {
            this.ShowView<IProfileCreationChoiceViewModel>();
        }

        public IWindowViewModel CurrentViewModel
        {
            get { return this._currentViewModel; }
            set
            {
                if (this._currentViewModel != value)
                {
                    return;
                }
                this._currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
    }
}
