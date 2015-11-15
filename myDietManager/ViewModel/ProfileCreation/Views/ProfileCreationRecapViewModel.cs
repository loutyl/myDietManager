using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Abstraction.Entities;
using myDietManager.Class.Database;
using myDietManager.View.ProfileCreationViews.Interfaces;
using myDietManager.ViewModel.Base;
using myDietManager.ViewModel.ProfileCreation.Window;
using StructureMap;

namespace myDietManager.ViewModel.ProfileCreation.Views
{
    public class ProfileCreationRecapViewModel : BaseViewModel, IProfileCreationRecapViewModel
    {
        private readonly IAutoProfileCreationViewModel _profileCreationViewModel;
        private ICommand _cancelCreationCommand;
        private ICommand _comfirmCreationCommand;

        public ProfileCreationRecapViewModel(IProfileCreationRecapView view, IContainer container, IAutoProfileCreationViewModel profileCreationViewModel) : base(view, container)
        {
            this._profileCreationViewModel = profileCreationViewModel;
        }

        public int MaintenanceCalories => this._profileCreationViewModel.DietProfile.CalorieNeeds.MaintenanceCalories;
        public int DailyCalories => this._profileCreationViewModel.DietProfile.CalorieNeeds.DailyCalories;
        public int Protein => this._profileCreationViewModel.DietProfile.Macronutrients.Protein;
        public int Carbohydrates => this._profileCreationViewModel.DietProfile.Macronutrients.Carbohydrate;
        public int Fat => this._profileCreationViewModel.DietProfile.Macronutrients.Fat;

        public ICommand CancelCreationCommand
        {
            get
            {
                if ( this._cancelCreationCommand != null )
                    return this._cancelCreationCommand;

                this._cancelCreationCommand = new RelayCommand(() => this.GoBackToUserInformations());

                return this._cancelCreationCommand;
            }
        }

        public ICommand ComfirmCreationCommand
        {
            get
            {
                if ( this._comfirmCreationCommand != null )
                    return this._comfirmCreationCommand;

                this._comfirmCreationCommand = new RelayCommand(() => this.FinishUserCreation());

                return this._comfirmCreationCommand;
            }
        }

        private void FinishUserCreation()
        {

        }

        private void GoBackToUserInformations()
        {

        }
    }
}
