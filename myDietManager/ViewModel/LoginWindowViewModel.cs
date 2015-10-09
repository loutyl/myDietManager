using System.Windows.Input;

namespace myDietManager.ViewModel
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private ICommand _addUserCommand;

        public ICommand AddUserCommand
        {
            get
            {
                if (this._addUserCommand != null)
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
