﻿using System.Windows;
using System.Windows.Input;
using myDietManager.Model;

namespace myDietManager.ViewModel
{
    public class UserInformationRecapViewModel : ViewModelBase
    {
        private readonly User _newUser;
        private readonly UserCreationWindowViewModel _windowViewModel;
        private readonly UserInformationViewModel _userInfoViewModel;
        private ICommand _cancelCreationCommand;
        private ICommand _comfirmCreationCommand;

        public UserInformationRecapViewModel(User newUser, UserCreationWindowViewModel windowViewModel, UserInformationViewModel userInfoViewModel)
        {
            this._newUser = newUser;
            this._windowViewModel = windowViewModel;
            this._userInfoViewModel = userInfoViewModel;

            Application.Current.MainWindow.Width = 380;
            Application.Current.MainWindow.Height = 245;
        }

        public int MaintenanceCalories => this._newUser.DietProfile.CalorieNeeds.MaintencanceCalories;
        public int DailyCalories => this._newUser.DietProfile.CalorieNeeds.DailyCalories;
        public int Protein => this._newUser.DietProfile.Macros.Protein.Weight;
        public int Carbohydrates => this._newUser.DietProfile.Macros.Carbohydrate.Weight;
        public int Fat => this._newUser.DietProfile.Macros.Fat.Weight;

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
            this._windowViewModel.CurrentViewModel = new UserInformationViewModel(this._windowViewModel, this._newUser);
        }

        public void FinishUserCreation()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
