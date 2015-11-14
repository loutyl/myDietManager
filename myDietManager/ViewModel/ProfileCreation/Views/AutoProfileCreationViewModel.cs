using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.IMP.DietManagement;
using myDietManager.View.ProfileCreationViews;
using myDietManager.View.ProfileCreationViews.Interfaces;
using myDietManager.ViewModel.Base;
using myDietManager.ViewModel.ProfileCreation.Window;

namespace myDietManager.ViewModel.ProfileCreation.Views
{
    public class AutoProfileCreationViewModel : BaseViewModel, IAutoProfileCreationViewModel, IDataErrorInfo
    {
        private readonly ProfileCreationWindowViewModel _profileCreationWindow;
        public Dictionary<string, bool> ValidAttributes { get; set; }
        public ObservableCollection<string> Goals { get; set; }
        public double ViewWidth { get; set; } = 600;
        public double ViewHeight { get; set; } = 340;
        private ICommand _finishProfileCreationCommand;

        public AutoProfileCreationViewModel(IAutoProfileCreationView view, StructureMap.IContainer container) : base(view, container)
        {
            
        }


        public AutoProfileCreationViewModel(ProfileCreationWindowViewModel profileCreationWindow)
        {
            this._profileCreationWindow = profileCreationWindow;
            this.Goals = PopulateGoalList();
            this._profileCreationWindow.Window.Width = ViewWidth;
            this._profileCreationWindow.Window.Height = ViewHeight;
        }

        private static ObservableCollection<string> PopulateGoalList() => new ObservableCollection<string>
        {
            "Gain",
            "Lose"
        };

        #region Attributes

        [Required(ErrorMessage = @"A profile name must be entered")]
        public string ProfileName
        {
            get { return this._profileCreationWindow.DietProfile.ProfileName; }
            set
            {
                if (this._profileCreationWindow.DietProfile.ProfileName == value)
                {
                    return;
                }

                this._profileCreationWindow.DietProfile.ProfileName = value;
                OnPropertyChanged("ProfileName");
            }
        }

        [Required]
        [Range(35 * 2.2f, 250 * 2.2f)]
        public double Weight
        {
            get { return this._profileCreationWindow.DietProfile.Weight; }
            set
            {

                this._profileCreationWindow.DietProfile.Weight = value;
                OnPropertyChanged("Weight");
            }
        }

        [Required]
        [Range(100, 300)]
        public double Height
        {
            get { return this._profileCreationWindow.DietProfile.Height; }
            set
            {
                if ( Math.Abs(this._profileCreationWindow.DietProfile.Height - value) <= 0 )
                {
                    return;
                }
                this._profileCreationWindow.DietProfile.Height = value;
                OnPropertyChanged("Height");
            }
        }

        [Required]
        public string SelectedGoal
        {
            get { return this._profileCreationWindow.DietProfile.Goal; }
            set
            {
                if (this._profileCreationWindow.DietProfile.Goal == value)
                {
                    return;
                }
                
                this._profileCreationWindow.DietProfile.Goal = value;
                OnPropertyChanged("SelectedGoal");
            }
        }

        [Required]
        [Range(6, 35)]
        public int DietDuration
        {
            get { return this._profileCreationWindow.DietProfile.DietDuration; }
            set
            {
                if ( this._profileCreationWindow.DietProfile.DietDuration == value )
                {
                    return;
                }
                this._profileCreationWindow.DietProfile.DietDuration = value;
                OnPropertyChanged("DietDuration");
            }
        }

        [Required]
        [Range(100, 400)]
        public double WeightGoal
        {
            get { return this._profileCreationWindow.DietProfile.WeightGoal; }
            set
            {
                if ( Math.Abs(this._profileCreationWindow.DietProfile.WeightGoal - value) <= 0 )
                {
                    return;
                }

                this._profileCreationWindow.DietProfile.WeightGoal = value;
                OnPropertyChanged("WeightGoal");
            }
        }

        [Required]
        public int ActivityLevel
        {
            get { return this._profileCreationWindow.DietProfile.ActivityLevel; }
            set
            {
                if ( this._profileCreationWindow.DietProfile.ActivityLevel == value )
                {
                    return;
                }

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
            DietCalculator.FinalizeDietProfileCreation(this._profileCreationWindow.DietProfile);

            this._profileCreationWindow.CurrentViewModel = new ProfileCreationRecapViewModel(this._profileCreationWindow, this);
        }

        public bool CanFinishProfileCreation()
        {
            //return !string.IsNullOrEmpty(this.ProfileName);
            //return !this.ValidProperties.ContainsValue(false);
            return true;
        }

        #endregion

        // check for general model error
        public string Error => null;

        // check for property errors
        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                return Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this)
                    , new ValidationContext(this)
                    {
                        MemberName = columnName
                    }
                    , validationResults) ? null : validationResults.First().ErrorMessage;
            }
        }
    }
}
