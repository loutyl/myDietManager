using System.Windows;
using myDietManager.View;


namespace myDietManager
{
    /// <summary>
    /// Logique d'interaction pour UserCreationWindow.xaml
    /// </summary>
    public partial class UserCreationWindow : Window
    {
        public UserCreationWindow()
        {
            InitializeComponent();

            var userCreationView = new UserInformationsView();
        }
    }
}
