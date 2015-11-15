using myDietManager.Abstraction.Entities;
using myDietManager.ViewModel.Base;

namespace myDietManager.ViewModel.ProfileCreation.Views
{
    public interface IAutoProfileCreationViewModel : IViewModel
    {
        IDietProfile DietProfile { get; set; }
    }
}
