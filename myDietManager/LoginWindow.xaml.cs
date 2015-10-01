using System.Windows;
using myDietManager.View;

namespace myDietManager
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void BtnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            var userCreationWindow = new UserCreationWindow();
            userCreationWindow.Show();
        }
    }
}
