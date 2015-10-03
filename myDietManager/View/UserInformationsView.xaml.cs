using System.Windows.Controls;
using myDietManager.Model;
using myDietManager.ViewModel;
namespace myDietManager.View
{
    /// <summary>
    /// Logique d'interaction pour UserCreationView.xaml
    /// </summary>
    public partial class UserInformationsView : UserControl
    {
        public UserInformationsView()
        {
            InitializeComponent();
            this.DataContext = new UserInformationViewModel();

        }
    }
}
