using myDietManager.ViewModel.Base;
using MyDietManagerAbstract.Abstraction.Entities;

namespace myDietManager.ViewModel.ProfileCreation.Views
{
    public interface IAutoProfileCreationViewModel : IViewModel
    {
        IDietProfile DietProfile { get; set; }
    }
}
