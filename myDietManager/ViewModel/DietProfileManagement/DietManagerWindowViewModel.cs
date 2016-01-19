using myDietManager.ViewModel.Base;
using MyDietManagerEntities;
using StructureMap;

namespace myDietManager.ViewModel.DietProfileManagement
{
    public class DietManagerWindowViewModel: BaseWindowViewModel, IDietManagerWindowViewModel
    {
        private readonly UsersDietProfile _dietProfile;

        public DietManagerWindowViewModel(IDietManagerWindow window, IContainer container, UsersDietProfile dietProfile) : base(window, container)
        {
            this._dietProfile = dietProfile;
        }

    }
}
