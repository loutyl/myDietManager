using System.Windows;
using myDietManager.ViewModel;
using StructureMap;

namespace myDietManager.cfg
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new Container();
            var window = container.GetInstance<ILoginWindowViewModel>();
            var loginWindow = (LoginWindow) window.Window;
            loginWindow.ShowDialog();
        }
    }
}
