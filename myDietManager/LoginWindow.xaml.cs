using System.Windows;
using myDietManager.Class.Security;
using myDietManager.ViewModel;

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
