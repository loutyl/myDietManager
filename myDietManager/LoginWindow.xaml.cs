using System.Windows;
using myDietManager.ViewModel;
using myDietManager.ViewModel.Login;

namespace myDietManager
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, ILoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
    }
}
