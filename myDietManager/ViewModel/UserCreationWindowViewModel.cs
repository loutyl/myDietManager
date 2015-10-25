using System.Windows;
using myDietManager.Model;

namespace myDietManager.ViewModel
{
    public class UserCreationWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public User NewUser { get; set; }

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
            this.NewUser = new User();
            this.CurrentViewModel = new UserInformationViewModel(this);
        }

    }

}
