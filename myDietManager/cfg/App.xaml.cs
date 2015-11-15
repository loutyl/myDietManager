using System.Windows;
using myDietManager.Registration;
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
            var container = new Container();
            container.Configure(c =>
            {
                c.AddRegistry<StartingRegistry>();
                c.AddRegistry<DietProfileCreationRegistry>();
            });
            var window = container.GetInstance<ILoginWindowViewModel>();
            var loginWindow = (LoginWindow) window.Window;
            loginWindow.ShowDialog();
        }
    }
}
