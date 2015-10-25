using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using myDietManager.Model;
using System.Linq;

namespace myDietManager.ViewModel
{
    public class UserInformationViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly UserCreationModel _userCreationModel;
        private readonly UserCreationWindowViewModel _userCreationWindowViewModel;
        private ICommand _finishCreationCommand;

        public UserInformationViewModel(UserCreationWindowViewModel windowViewModel)
        {
            this._userCreationModel = new UserCreationModel();
            this._userCreationWindowViewModel = windowViewModel;
        }

        #region Interface Implementation

        public string Error => ( this._userCreationWindowViewModel.NewUser as IDataErrorInfo ).Error;

        public string this[string propertyName]
        {
            get
            {
                var error = ( this._userCreationWindowViewModel.NewUser as IDataErrorInfo )[propertyName];
                this.ValidProperties[propertyName] = string.IsNullOrEmpty(error);
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }
        #endregion

        #region Attributes

        public ObservableCollection<string> GenderList => this._userCreationModel.GenderList;
        public Dictionary<string, bool> ValidProperties => this._userCreationModel.ValidProperties;

        public string LastName
        {
            get { return this._userCreationWindowViewModel.NewUser.LastName; }
            set
            {
                this._userCreationWindowViewModel.NewUser.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Name
        {
            get { return this._userCreationWindowViewModel.NewUser.Name; }
            set
            {
                this._userCreationWindowViewModel.NewUser.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string UserName
        {
            get { return this._userCreationWindowViewModel.NewUser.UserName; }
            set
            {
                this._userCreationWindowViewModel.NewUser.UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        public int Age
        {
            get { return this._userCreationWindowViewModel.NewUser.Age; }
            set
            {
                this._userCreationWindowViewModel.NewUser.Age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Gender
        {
            get { return this._userCreationWindowViewModel.NewUser.Gender; }
            set
            {
                this._userCreationWindowViewModel.NewUser.Gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string SelectedGender
        {
            get { return this._userCreationWindowViewModel.NewUser.Gender; }
            set
            {
                this._userCreationWindowViewModel.NewUser.Gender = value;
                OnPropertyChanged("SelectedGender");
            }
        }

        public float Weight
        {
            get { return this._userCreationWindowViewModel.NewUser.Weight; }
            set
            {
                this._userCreationWindowViewModel.NewUser.Weight = value;
                OnPropertyChanged("Weight");
            }
        }

        public bool IsPound
        {
            get { return this._userCreationWindowViewModel.NewUser.IsPound; }
            set
            {
                this._userCreationWindowViewModel.NewUser.IsPound = value;
                OnPropertyChanged("IsPound");
            }
        }

        public bool IsKilo
        {
            get { return this._userCreationWindowViewModel.NewUser.IsKilo; }
            set
            {
                this._userCreationWindowViewModel.NewUser.IsKilo = value;
                OnPropertyChanged("IsKilo");
            }
        }

        public float Height
        {
            get { return this._userCreationWindowViewModel.NewUser.Height; }
            set
            {
                this._userCreationWindowViewModel.NewUser.Height = value;
                OnPropertyChanged("Height");
            }
        }

        public bool IsLose
        {
            get { return this._userCreationWindowViewModel.NewUser.DietProfile.IsLose; }
            set
            {
                this._userCreationWindowViewModel.NewUser.DietProfile.IsLose = value;
                OnPropertyChanged("IsLose");
            }
        }

        public bool IsGain
        {
            get { return this._userCreationWindowViewModel.NewUser.DietProfile.IsGain; }
            set
            {
                this._userCreationWindowViewModel.NewUser.DietProfile.IsGain = value;
                OnPropertyChanged("IsGain");
            }
        }

        public int DietDuration
        {
            get { return this._userCreationWindowViewModel.NewUser.DietProfile.DietDuration; }
            set
            {
                this._userCreationWindowViewModel.NewUser.DietProfile.DietDuration = value;
                OnPropertyChanged("DietDuration");
            }
        }

        public float WeightGoal
        {
            get { return this._userCreationWindowViewModel.NewUser.DietProfile.WeightGoal; }
            set
            {
                this._userCreationWindowViewModel.NewUser.DietProfile.WeightGoal = value;
                OnPropertyChanged("WeightGoal");
            }
        }

        public int ActivityLevel
        {
            get { return this._userCreationWindowViewModel.NewUser.DietProfile.ActivityLevel; }
            set
            {
                this._userCreationWindowViewModel.NewUser.DietProfile.ActivityLevel = value;
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
            this._userCreationWindowViewModel.NewUser.FinalizeUserCreation();

            this._userCreationWindowViewModel.CurrentViewModel = new UserInformationRecapViewModel(this._userCreationWindowViewModel, this);
        }

        public bool CanFinishUserCreation()
        {
            return !this.ValidProperties.ContainsValue(false);
        }

        #endregion
    }
}
