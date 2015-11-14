using myDietManager.View.Base;
using StructureMap;

namespace myDietManager.ViewModel.Base
{
    public class BaseViewModel : BaseNotification, IViewModel
    {
        public BaseViewModel(IView view, IContainer container)
        {
            View = view;
            View.DataContext = this;

            Container = container;
        }

        public IContainer Container { get; set; }

        public IView View { get; set; }
    }
}
