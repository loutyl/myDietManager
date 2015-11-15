using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Abstraction.Entities;
using myDietManager.Abstraction.Repositories;
using myDietManager.IMP.Entities.Repositories;
using myDietManager.Registration;
using myDietManager.ViewModel.Base;
using myDietManager.ViewModel.DietProfileManagement;
using myDietManager.ViewModel.ProfileCreation.Window;
using StructureMap;

namespace myDietManager.ViewModel.UserActionWindow
{
    class UserActionWindowViewModel : BaseWindowViewModel, IUserActionWindowViewModel
    {
        private readonly IUser _user;
        private readonly IContainer _profileCreationContainer;
        private readonly IBaseRepository<UsersDietProfile> _dietProfileRepository;
        private ICommand _addDietProfileCommand;
        private ICommand _loadDietProfileCommand;
        private ObservableCollection<string> _dietProfileNames;
        private string _selectedProfileName;

        public UserActionWindowViewModel(IUserActionWindow userActionWindow, IContainer container, IUser user) : base(userActionWindow, container)
        {
            this._profileCreationContainer = new Container(c => c.AddRegistry<DietProfileCreationRegistry>());
            this._dietProfileRepository = this.Container.GetInstance<DietProfileRepository>();
            this._user = user;
        }

        //private ObservableCollection<string> PopulateDietProfileNames()
        //{
        //    var profileNames = new ObservableCollection<string>();

        //    if ( !this._dbOjbect.UserHasDietProfile(this._user) )
        //    {
        //        return profileNames;
        //    }

        //    foreach ( var profileName in this._dbOjbect.GetUserDietProfileNames(this._user) )
        //    {
        //        profileNames.Add(profileName);
        //    }

        //    this.SelectedProfileName = profileNames[0];
        //    return profileNames;
        //}

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
            var window = this._profileCreationContainer.GetInstance<IProfileCreationWindowViewModel>();
            var profileCreationWindow = (ProfileCreationWindow) window.Window;
            profileCreationWindow.ShowDialog();
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
           var selectedDietProfile =  this._dietProfileRepository.Get(profile => 
                    profile.UserID == this._user.UserID && 
                    profile.ProfileName == this.SelectedProfileName);

           var newContainer = new Container(x => {
               x.For<IDietManagerWindowViewModel>()
               .Use<DietManagerWindowViewModel>()
               .Ctor<UsersDietProfile>().Is(selectedDietProfile);
           });

            var window = newContainer.GetInstance<IDietManagerWindowViewModel>();
            var userActionWindow = (DietManagerWindow)window.Window;
            userActionWindow.ShowDialog();

        }

        private bool CanLoadDietProfile()
        {
            return this._dietProfileNames.Count != 0;
        }

    }
}
