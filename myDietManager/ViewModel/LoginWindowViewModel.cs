using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Abstraction.Security;
using myDietManager.Class.Database;
using StructureMap;

namespace myDietManager.ViewModel
{
    public class LoginWindowViewModel : BaseWindowViewModel, ILoginWindowViewModel
    {
        private readonly IAuthentifactionManager<User> _authManager;
        private ICommand _connectCommand;
        private ICommand _cancelComand;

        public string Username { get; set; }


        public LoginWindowViewModel(ILoginWindow loginWindow, IContainer container) : base(loginWindow, container)
        {
            this._authManager = container.GetInstance<IAuthentifactionManager<User>>();
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

            var user = this._authManager.Authenticate(this.Username, pwd);

            if (user == null){ return; }

            var actionWindow = new UserActionWindow {DataContext = new UserActionWindowViewModel(user, new DatabaseObject())};
            Application.Current.MainWindow.Close();
            actionWindow.Show();            
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(this.Username);
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
