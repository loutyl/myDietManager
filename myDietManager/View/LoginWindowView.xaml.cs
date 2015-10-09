using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
