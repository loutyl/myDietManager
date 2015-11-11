using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Class.Database;
using myDietManager.Model;
using myDietManager.ViewModel.DietProfileManagement;

namespace myDietManager.ViewModel
{
    class UserActionWindowViewModel : ViewModelBase
    {
        private readonly User _user;
        private readonly DatabaseObject _dbOjbect;
        private readonly Window _windowInstance;
        private ObservableCollection<string> _dietProfileNames;
        private string _selectedProfileName;
        private ICommand _addDietProfileCommand;
        private ICommand _loadDietProfileCommand;


        public UserActionWindowViewModel(User user, DatabaseObject dbObject)
        {
            this._user = user;
            this._dbOjbect = dbObject;
            this._dietProfileNames = this.PopulateDietProfileNames();
        }

        private ObservableCollection<string> PopulateDietProfileNames()
        {
            var profileNames = new ObservableCollection<string>();

            if ( !this._dbOjbect.UserHasDietProfile(this._user) )
            {
                return profileNames;
            }

            foreach ( var profileName in this._dbOjbect.GetUserDietProfileNames(this._user) )
            {
                profileNames.Add(profileName);
            }

            this.SelectedProfileName = profileNames[0];
            return profileNames;
        }

        public ObservableCollection<string> DietProfileNames
        {
            get { return this._dietProfileNames; }
            set
            {
                this._dietProfileNames = value;
                OnPropertyChanged("DietProfileNames");
            }
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
            Application.Current.Windows[0]?.Close();
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
            var dietProfileManagerWindow = new DietProfileManagerWindow()
            {
                DataContext = new DietProfileManagerViewModel(this._dbOjbect.GetDietProfile(this._user.UserID, this.SelectedProfileName))
            };
            dietProfileManagerWindow.Show();
            Application.Current.Windows[0]?.Close();
        }

        private bool CanLoadDietProfile()
        {
            return this._dietProfileNames.Count != 0;
        }

    }
}
