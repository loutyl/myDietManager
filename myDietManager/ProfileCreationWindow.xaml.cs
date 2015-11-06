using System.Windows;
using myDietManager.Class;
using myDietManager.Model;
using myDietManager.ViewModel.ProfileCreationViewModels;

namespace myDietManager
{
    /// <summary>
    /// Logique d'interaction pour UserCreationWindow.xaml
    /// </summary>
    public partial class ProfileCreationWindow : Window
    {
        public ProfileCreationWindow(User user)
        {
            InitializeComponent();
            var dietProfile = new DietProfile { UserId = user.UserId };
            this.DataContext = new ProfileCreationWindowViewModel(this, dietProfile);
        }
    }
}
