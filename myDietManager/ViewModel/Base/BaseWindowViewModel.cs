using myDietManager.View.Base;
using StructureMap;

namespace myDietManager.ViewModel.Base
{
    public class BaseWindowViewModel : BaseNotification, IWindowViewModel
    {
        public BaseWindowViewModel(IWindow window, IContainer container)
        {
            Window = window;
            Window.DataContext = this;

            Container = container;
        }

        public IView View { get; set; }

        public IContainer Container { get; set; }

        public IWindow Window { get; set; }

        public void ShowView<T>() where T : IViewModel
        {
            View = Container.GetInstance<T>().View;
        }
    }
}
