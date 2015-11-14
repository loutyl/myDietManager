using System.Windows.Controls;
using myDietManager.View.ProfileCreationViews.Interfaces;

namespace myDietManager.View.ProfileCreationViews
{
    /// <summary>
    /// Interaction logic for ManualProfileCreationView.xaml
    /// </summary>
    public partial class ManualProfileCreationView : UserControl, IManualProfileCreationView
    {
        public ManualProfileCreationView()
        {
            InitializeComponent();
        }
    }
}
