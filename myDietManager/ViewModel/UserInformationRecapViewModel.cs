﻿using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Model;

namespace myDietManager.ViewModel
{
    public class UserInformationRecapViewModel : ViewModelBase
    {
        private readonly UserCreationWindowViewModel _windowViewModel;
        private readonly UserInformationViewModel _userInfoViewModel;
        private ICommand _cancelCreationCommand;
        private ICommand _comfirmCreationCommand;

        public UserInformationRecapViewModel(UserCreationWindowViewModel windowViewModel, UserInformationViewModel userInfoViewModel)
        {
            this._windowViewModel = windowViewModel;
            this._userInfoViewModel = userInfoViewModel;

            Application.Current.MainWindow.Width = 380;
            Application.Current.MainWindow.Height = 245;
        }

        public int MaintenanceCalories => this._windowViewModel.NewUser.DietProfile.CalorieNeeds.MaintencanceCalories;
        public int DailyCalories => this._windowViewModel.NewUser.DietProfile.CalorieNeeds.DailyCalories;
        public int Protein => this._windowViewModel.NewUser.DietProfile.Macros.Protein.Weight;
        public int Carbohydrates => this._windowViewModel.NewUser.DietProfile.Macros.Carbohydrate.Weight;
        public int Fat => this._windowViewModel.NewUser.DietProfile.Macros.Fat.Weight;

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
            Application.Current.MainWindow.Width = this._userInfoViewModel.UserCreationMod.ViewWidth;
            Application.Current.MainWindow.Height = this._userInfoViewModel.UserCreationMod.ViewHeight;
            this._windowViewModel.CurrentViewModel = this._userInfoViewModel;
        }

        public void FinishUserCreation()
        {
            Application.Current.MainWindow.Close();
        }
    }
}