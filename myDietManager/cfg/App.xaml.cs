using System.Windows;
using myDietManager.Abstraction.Repositories;
using myDietManager.Registration;
using myDietManager.ViewModel;
using myDietManager.ViewModel.Login;
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
            var container = Container.For<StartingRegistry>();
            var window = container.GetInstance<ILoginWindowViewModel>();
            var loginWindow = (LoginWindow) window.Window;
            loginWindow.ShowDialog();
        }
    }
}
