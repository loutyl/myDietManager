using System.Windows;
using myDietManager.Class;
using myDietManager.Model;

namespace myDietManager.ViewModel.ProfileCreationViewModels
{
    public class ProfileCreationWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public DietProfile DietProfile { get; set; }
        public Window Window { get; set; }

        public ViewModelBase CurrentViewModel
        {
            get { return this._currentViewModel; }
            set
            {
                if (this._currentViewModel == value) return;

                this._currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public ProfileCreationWindowViewModel(Window profileCreationWindow, DietProfile dietProfile)
        {
            this.DietProfile = dietProfile;
            this.Window = profileCreationWindow;
            this.CurrentViewModel = new ProfileCreationChoiceViewModel(this);
        }
    }
}
