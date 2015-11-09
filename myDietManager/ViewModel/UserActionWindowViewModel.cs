using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Class.Database;
using myDietManager.Model;

namespace myDietManager.ViewModel
{
    class UserActionWindowViewModel : ViewModelBase
    {
        private readonly User _user;
        public ObservableCollection<string> DietProfileNames;
        private string _selectedProfileName;
        private ICommand _addDietProfileCommand;
        private ICommand _loadDietProfileCommand;

        public UserActionWindowViewModel(User user)
        {
            this._user = user;
            this.DietProfileNames = this.PopulateDietProfileNames();
        }

        private ObservableCollection<string> PopulateDietProfileNames()
        {
            var profileNames = new ObservableCollection<string>();
            var dbObject = new DatabaseObject();

            if (dbObject.UserHasDietProfile(this._user)){ return profileNames; }
            var test = dbObject.GetUserDietProfileNames(this._user);
            foreach ( var profileName in dbObject.GetUserDietProfileNames(this._user))
            {
                profileNames.Add(profileName);
            }

            this.SelectedProfileName = profileNames[0];
            return profileNames;
        }


        public string SelectedProfileName
        {
            get { return this._selectedProfileName; }
            set
            {
                if (this._selectedProfileName == value ){ return; }

                this._selectedProfileName = value;
                OnPropertyChanged("SelectedProfileName");
            }
            
        }

        public ICommand AddDietProfileCommand
        {
            get
            {
                if ( this._addDietProfileCommand != null )
                    return this._addDietProfileCommand;

                this._addDietProfileCommand = new RelayCommand(() => this.OpenDietProfileCreationWindow());

                return this._addDietProfileCommand;
            }
        }

        private void OpenDietProfileCreationWindow()
        {
            var profileCreationWindow = new ProfileCreationWindow(this._user);
            profileCreationWindow.Show();
        }

        public ICommand LoadDietProfileCommand
        {
            get
            {
                if ( this._loadDietProfileCommand != null )
                    return this._loadDietProfileCommand;

                this._loadDietProfileCommand = new RelayCommand(() => this.LoadDietProfile(), () => this.CanLoadDietProfile());

                return this._loadDietProfileCommand;
            }
        }

        private void LoadDietProfile()
        {
            
        }

        private bool CanLoadDietProfile()
        {
            return true;
        }

    }
}
