using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Model;

namespace myDietManager.ViewModel
{
    class UserActionWindowViewModel : ViewModelBase
    {
        private readonly User _user;
        private ICommand _addDietProfileCommand;
        private ICommand _loadDietProfileCommand;

        public UserActionWindowViewModel(User user)
        {
            this._user = user;
        }

        public ICommand AddDietProfileCommand
        {
            get
            {
                if ( this._addDietProfileCommand != null )
                    return this._addDietProfileCommand;

                this._addDietProfileCommand = new RelayCommand(() => this.OpenDietProfileCreationWindow());

                return this._addDietProfileCommand;
            }
        }

        private void OpenDietProfileCreationWindow()
        {
            var profileCreationWindow = new ProfileCreationWindow(this._user);
            profileCreationWindow.Show();
        }

        public ICommand LoadDietProfileCommand
        {
            get
            {
                if ( this._loadDietProfileCommand != null )
                    return this._loadDietProfileCommand;

                this._loadDietProfileCommand = new RelayCommand(() => this.LoadDietProfile(), () => this.CanLoadDietProfile());

                return this._loadDietProfileCommand;
            }
        }

        private void LoadDietProfile()
        {
            
        }

        private bool CanLoadDietProfile()
        {
            return true;
        }

    }
}
