﻿using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Model;

namespace myDietManager.ViewModel
{
    class UserActionWindowViewModel : ViewModelBase
    {
        private User _user;
        private ICommand _addUserCommand;

        public UserActionWindowViewModel(User user)
        {
            this._user = user;
        }

        public ICommand AddUserCommand
        {
            get
            {
                if ( this._addUserCommand != null )
                    return this._addUserCommand;

                this._addUserCommand = new RelayCommand(() => this.OpenDietProfileCreationWindow());

                return this._addUserCommand;
            }
        }

        public void OpenDietProfileCreationWindow()
        {
            var profileCreationWindow = new ProfileCreationWindow();
            profileCreationWindow.Show();
        }
    }
}
