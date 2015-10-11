using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using myDietManager.Model;

namespace myDietManager.ViewModel
{
    public class UserInformationViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly User _newUser;
        private readonly DietProfile _newUserDietProfile;
        private ICommand _finishCreationCommand;
        private readonly UserCreationWindowViewModel _userCreationWindowViewModel;

        public UserInformationViewModel(UserCreationWindowViewModel windowViewModel, User newUser)
        {   
            this._newUser = newUser;
            this._newUserDietProfile = new DietProfile();
            this._userCreationWindowViewModel = windowViewModel;
        }

        #region Interface Implementation

        public string Error => ( this._newUser as IDataErrorInfo ).Error;

        public string this[string propertyName]
        {
            get
            {
                var error = ( this._newUser as IDataErrorInfo )[propertyName];
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }
        #endregion

        #region Attributes

        public string LastName
        {
            get { return _newUser.LastName; }
            set
            {
                this._newUser.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Name
        {
            get { return this._newUser.Name; }
            set
            {
                this._newUser.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string UserName
        {
            get { return this._newUser.UserName; }
            set
            {
                this._newUser.UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        public int Age
        {
            get { return this._newUser.Age; }
            set
            {
                this._newUser.Age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Gender
        {
            get { return this._newUser.Gender; }
            set
            {
                this._newUser.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public float Weight
        {
            get { return this._newUser.Weight; }
            set
            {
                this._newUser.Weight = value;
                OnPropertyChanged("Weight");
            }
        }

        public bool IsPound
        {
            get { return this._newUser.IsPound; }
            set
            {
                this._newUser.IsPound = value;
                OnPropertyChanged("IsPound");
            }
        }

        public bool IsKilo
        {
            get { return this._newUser.IsKilo; }
            set
            {
                this._newUser.IsKilo = value;
                OnPropertyChanged("IsKilo");
            }
        }

        public float Height
        {
            get { return this._newUser.Height; }
            set
            {
                this._newUser.Height = value;
                OnPropertyChanged("Height");
            }
        }

        public bool IsLose
        {
            get { return this._newUserDietProfile.IsLose; }
            set
            {
                this._newUserDietProfile.IsLose = value;
                OnPropertyChanged("IsLose");
            }
        }

        public bool IsGain
        {
            get { return this._newUserDietProfile.IsGain; }
            set
            {
                this._newUserDietProfile.IsGain = value;
                OnPropertyChanged("IsGain");
            }
        }

        public int DietDuration
        {
            get { return this._newUserDietProfile.DietDuration; }
            set
            {
                this._newUserDietProfile.DietDuration = value;
                OnPropertyChanged("DietDuration");
            }
        }

        public float WeightGoal
        {
            get { return this._newUserDietProfile.WeightGoal; }
            set
            {
                this._newUserDietProfile.WeightGoal = value;
                OnPropertyChanged("WeightGoal");
            }
        }

        public int ActivityLevel
        {
            get { return this._newUserDietProfile.ActivityLevel; }
            set
            {
                this._newUserDietProfile.ActivityLevel = value;
                OnPropertyChanged("ActivityLevel");
            }
        }

        #endregion

        #region Commands

        public ICommand FinishCreationCommand
        {
            get
            {
                if (this._finishCreationCommand != null)
                    return this._finishCreationCommand;

                this._finishCreationCommand = new RelayCommand(() => this.FinishUserCreation(), () => this.CanFinishUserCreation());

                return this._finishCreationCommand;
            }
        }


        public void FinishUserCreation()
        {
            this._newUser.DietProfile = this._newUserDietProfile;
            this._newUser.FinalizeUserCreation();

            this._userCreationWindowViewModel.CurrentViewModel = new UserInformationRecapViewModel(this._newUser, this._userCreationWindowViewModel, this);
        }

        public bool CanFinishUserCreation() 
        {
            return true;
        }

        #endregion
    }
}
