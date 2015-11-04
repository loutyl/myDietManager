using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Class.Database;

namespace myDietManager.ViewModel.ProfileCreationViewModels
{
    public class ProfileCreationRecapViewModel : ViewModelBase
    {
        private readonly ProfileCreationWindowViewModel _profileCreationWindow;
        private readonly ProfileCreationViewModel _profileCreationViewModel;
        private ICommand _cancelCreationCommand;
        private ICommand _comfirmCreationCommand;

        public ProfileCreationRecapViewModel(ProfileCreationWindowViewModel windowViewModel, ProfileCreationViewModel profileCreationviewModel)
        {
            this._profileCreationViewModel = profileCreationviewModel;
            this._profileCreationWindow = windowViewModel;
            this._profileCreationWindow.Window.Width = 385;
            this._profileCreationWindow.Window.Height = 245;
        }

        public int MaintenanceCalories => this._profileCreationWindow.DietProfile.CalorieNeeds.MaintencanceCalories;
        public int DailyCalories => this._profileCreationWindow.DietProfile.CalorieNeeds.DailyCalories;
        public int Protein => this._profileCreationWindow.DietProfile.Macros.Protein.Weight;
        public int Carbohydrates => this._profileCreationWindow.DietProfile.Macros.Carbohydrate.Weight;
        public int Fat => this._profileCreationWindow.DietProfile.Macros.Fat.Weight;

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
            var dbObject = new DatabaseObject();
            dbObject.AddDietProfile(this._profileCreationWindow.DietProfile);

            this._profileCreationWindow.Window.Close();
        }

        private void GoBackToUserInformations()
        {
            this._profileCreationWindow.Window.Width = this._profileCreationViewModel.ViewWidth;
            this._profileCreationWindow.Window.Height = this._profileCreationViewModel.ViewHeight;
            this._profileCreationWindow.CurrentViewModel = this._profileCreationViewModel;
        }
    }
}
