using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.IMP.Entities.Converter;
using myDietManager.ViewModel.Base;
using myDietManager.ViewModel.UserActionWindow;
using MyDietManagerAbstract.Abstraction.Entities;
using MyDietManagerAbstract.Abstraction.Entities.Converter;
using MyDietManagerAbstract.Abstraction.Security;
using MyDietManagerEntities;
using StructureMap;

namespace myDietManager.ViewModel.Login
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

                this._connectCommand = new Base.RelayCommand<object>(parameter => this.Login(parameter), () => this.CanLogin());

                return this._connectCommand;
            }
        }

        private void Login(object parameter)
        {
            var pwdBox = parameter as PasswordBox;
            var pwd = pwdBox?.Password;

            var user = this._authManager.Authenticate(this.Username, pwd);

            if ( user == null ) { return; }

            var converter = this.Container.GetInstance<IConverter<User, IUser>>();
            var pocoUser = converter.Convert(user);

            var window = this.Container.With("user").EqualTo(pocoUser).GetInstance<IUserActionWindowViewModel>();
            var userActionWindow = (myDietManager.UserActionWindow)window.Window;
            userActionWindow.ShowDialog();
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