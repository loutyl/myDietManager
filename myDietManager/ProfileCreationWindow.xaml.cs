using System.Windows;
using myDietManager.ViewModel;
using myDietManager.ViewModel.ProfileCreation;

namespace myDietManager
{
    /// <summary>
    /// Logique d'interaction pour UserCreationWindow.xaml
    /// </summary>
    public partial class ProfileCreationWindow : Window
    {
        public ProfileCreationWindow()
        {
            InitializeComponent();
            this.DataContext = new ProfileCreationWindowViewModel();
            Application.Current.MainWindow = this;
        }
    }
}
