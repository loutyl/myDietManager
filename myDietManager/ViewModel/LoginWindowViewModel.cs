using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Model;

namespace myDietManager.ViewModel
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private readonly LoginModel _loginModel;
        private ICommand _connectCommand;
        private ICommand _cancelComand;
        
        public LoginWindowViewModel()
        {
            this._loginModel = new LoginModel();
        }

        public ICommand ConnectCommand
        {
            get
            {
                if ( this._connectCommand != null )
                    return this._connectCommand;

                this._connectCommand = new RelayCommand<object>(parameter => this.Login(parameter), () => this.CanLogin());

                return this._connectCommand;
            }
        }

        private void Login(object parameter)
        {
            var pwdBox = parameter as PasswordBox;
            var pwd = pwdBox?.Password;

            MessageBox.Show(pwd);
        }

        private bool CanLogin()
        {
            return true;
        }

        public ICommand CancelCommand
        {
            get
            {
                if ( this._cancelComand != null )
                    return this._cancelComand;

                this._cancelComand = new RelayCommand(() => this.CancelLogin());

                return this._cancelComand;
            }
        }

        private void CancelLogin()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
