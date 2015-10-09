using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                this._addUserCommand = new RelayCommand(() => this.OpenAddUserWindow());

                return this._addUserCommand;
            }
        }

        public void OpenAddUserWindow()
        {
            var userCreationWindow = new UserCreationWindow();
            userCreationWindow.Show();
        }
    }
}
