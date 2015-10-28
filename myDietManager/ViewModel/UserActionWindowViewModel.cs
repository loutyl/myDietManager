using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace myDietManager.ViewModel
{
    class UserActionWindowViewModel : ViewModelBase
    {
        private ICommand _addUserCommand;

        public ICommand AddUserCommand
        {
            get
            {
                if ( this._addUserCommand != null )
                    return this._addUserCommand;

                this._addUserCommand = new RelayCommand(() => OpenAddUserWindow());

                return this._addUserCommand;
            }
        }

        public static void OpenAddUserWindow()
        {
            var userCreationWindow = new UserCreationWindow();
            userCreationWindow.Show();
        }
    }
}
