using myDietManager.View.Base;

namespace myDietManager.ViewModel.Base
{
    public interface IViewModel
    {
        IView View { get; set; }
    }
}
