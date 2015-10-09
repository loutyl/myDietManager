namespace myDietManager.ViewModel
{
    public class UserCreationWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

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

        public UserCreationWindowViewModel() 
        {
            this.CurrentViewModel = new UserInformationViewModel(this);
        }

    }
}
