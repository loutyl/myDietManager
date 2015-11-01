using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Model;

namespace myDietManager.ViewModel.ProfileCreationViewModels
{
    public class ProfileCreationViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly ProfileCreationWindowViewModel _profileCreationWindow;
        public Dictionary<string, bool> ValidAttributes { get; set; }
        public double ViewWidth { get; set; } = 600;
        public double ViewHeight { get; set; } = 300;
        private ICommand _finishProfileCreationCommand;

        public ProfileCreationViewModel(ProfileCreationWindowViewModel profileCreationWindow)
        {
            this._profileCreationWindow = profileCreationWindow;
            this.ValidAttributes = PopulateAttributesDictionary();
            this._profileCreationWindow.Window.Width = ViewWidth;
            this._profileCreationWindow.Window.Height = ViewHeight;
        }

        private static Dictionary<string, bool> PopulateAttributesDictionary() => new Dictionary<string, bool>
        {
            {"Weight", false},
            {"Height", false},
            {"DietDuration", false},
            {"WeightGoal", false}
        };

        #region Interface Implementation

        public string Error => ( this._profileCreationWindow.DietProfile as IDataErrorInfo ).Error;

        public string this[string attributeName]
        {
            get
            {
                var error = ( this._profileCreationWindow.DietProfile as IDataErrorInfo )[attributeName];
                this.ValidAttributes[attributeName] = string.IsNullOrEmpty(error);
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }
        #endregion

        #region Attributes
        
        public float Weight
        {
            get { return this._profileCreationWindow.DietProfile.Weight; }
            set
            {
                this._profileCreationWindow.DietProfile.Weight = value;
                OnPropertyChanged("Weight");
            }
        }
        public float Height
        {
            get { return this._profileCreationWindow.DietProfile.Height; }
            set
            {
                this._profileCreationWindow.DietProfile.Height = value;
                OnPropertyChanged("Height");
            }
        }

        public bool IsLose
        {
            get { return this._profileCreationWindow.DietProfile.Goal == Goal.Lose; }
            set
            {
                this._profileCreationWindow.DietProfile.Goal = value ? Goal.Lose : Goal.Gain;
                
                OnPropertyChanged("IsLose");
                OnPropertyChanged("IsGain");
            }
        }

        public bool IsGain
        {
            get { return this._profileCreationWindow.DietProfile.Goal == Goal.Gain; }
            set
            {
                this._profileCreationWindow.DietProfile.Goal = value ? Goal.Gain : Goal.Lose;

                OnPropertyChanged("IsLose");
                OnPropertyChanged("IsGain");
            }
        }

        public int DietDuration
        {
            get { return this._profileCreationWindow.DietProfile.DietDuration; }
            set
            {
                this._profileCreationWindow.DietProfile.DietDuration = value;
                OnPropertyChanged("DietDuration");
            }
        }

        public float WeightGoal
        {
            get { return this._profileCreationWindow.DietProfile.WeightGoal; }
            set
            {
                this._profileCreationWindow.DietProfile.WeightGoal = value;
                OnPropertyChanged("WeightGoal");
            }
        }

        public int ActivityLevel
        {
            get { return this._profileCreationWindow.DietProfile.ActivityLevel; }
            set
            {
                this._profileCreationWindow.DietProfile.ActivityLevel = value;
                OnPropertyChanged("ActivityLevel");
            }
        }

        #endregion

        #region Commands

        public ICommand FinishProfileCreationCommand
        {
            get
            {
                if (this._finishProfileCreationCommand != null)
                    return this._finishProfileCreationCommand;

                this._finishProfileCreationCommand = new RelayCommand(() => this.FinishProfileCreation(), () => this.CanFinishProfileCreation());

                return this._finishProfileCreationCommand;
            }
        }

        public void FinishProfileCreation()
        {
            this._profileCreationWindow.DietProfile.FinalizeProfileCreation();

            this._profileCreationWindow.CurrentViewModel = new ProfileCreationRecapViewModel(this._profileCreationWindow, this);
        }

        public bool CanFinishProfileCreation()
        {
            return true;
            //return !this.ValidProperties.ContainsValue(false);
        }

        #endregion
    }
}
