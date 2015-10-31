using System.Windows;
using myDietManager.ViewModel.ProfileCreationViewModels;

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
            this.DataContext = new ProfileCreationWindowViewModel(this);

        }
    }
}
