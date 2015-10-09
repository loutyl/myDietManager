using System.Windows.Controls;
using myDietManager.ViewModel;

namespace myDietManager.View
{
    /// <summary>
    /// Logique d'interaction pour LoginWindowView.xaml
    /// </summary>
    public partial class LoginWindowView : UserControl
    {
        public LoginWindowView()
        {
            InitializeComponent();
            this.DataContext = new LoginWindowViewModel();
        }
    }
}
