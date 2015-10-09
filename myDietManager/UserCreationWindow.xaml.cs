using System.Windows;
using myDietManager.Model;
using myDietManager.View;
using myDietManager.ViewModel;


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
            this.DataContext = new UserCreationWindowViewModel();
        }
    }
}
