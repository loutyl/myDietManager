using myDietManager.Model;

namespace myDietManager.ViewModel.ProfileCreation
{
    public class ProfileCreationWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public DietProfile DietProfile { get; set; }

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

        public ProfileCreationWindowViewModel()
        {
            this.DietProfile = new DietProfile();
            this.CurrentViewModel = new ProfileCreationChoiceViewModel(this);
        }

    }

}
