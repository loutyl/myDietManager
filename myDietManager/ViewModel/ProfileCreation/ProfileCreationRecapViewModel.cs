using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace myDietManager.ViewModel.ProfileCreation
{
    public class ProfileCreationRecapViewModel : ViewModelBase
    {
        private readonly ProfileCreationWindowViewModel _windowViewModel;
        private readonly ProfileCreationViewModel _profileCreationViewModel;
        private ICommand _cancelCreationCommand;
        private ICommand _comfirmCreationCommand;

        public ProfileCreationRecapViewModel(ProfileCreationWindowViewModel windowViewModel, ProfileCreationViewModel profileCreationviewModel)
        {
            this._windowViewModel = windowViewModel;
            this._profileCreationViewModel = profileCreationviewModel;

            Application.Current.MainWindow.Width = 380;
            Application.Current.MainWindow.Height = 245;
        }

        public int MaintenanceCalories => this._windowViewModel.DietProfile.CalorieNeeds.MaintencanceCalories;
        public int DailyCalories => this._windowViewModel.DietProfile.CalorieNeeds.DailyCalories;
        public int Protein => this._windowViewModel.DietProfile.Macros.Protein.Weight;
        public int Carbohydrates => this._windowViewModel.DietProfile.Macros.Carbohydrate.Weight;
        public int Fat => this._windowViewModel.DietProfile.Macros.Fat.Weight;

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

        public void GoBackToUserInformations()
        {
            Application.Current.MainWindow.Width = this._profileCreationViewModel.ViewWidth;
            Application.Current.MainWindow.Height = this._profileCreationViewModel.ViewHeight;
            this._windowViewModel.CurrentViewModel = this._profileCreationViewModel;
        }

        public void FinishUserCreation()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
