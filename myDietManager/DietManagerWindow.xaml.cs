using System.Windows;
using myDietManager.ViewModel.DietProfileManagement;

namespace myDietManager
{
    /// <summary>
    /// Interaction logic for DietProfileManagerWindow.xaml
    /// </summary>
    public partial class DietManagerWindow : Window, IDietManagerWindow
    {
        public DietManagerWindow()
        {
            InitializeComponent();
        }
    }
}
