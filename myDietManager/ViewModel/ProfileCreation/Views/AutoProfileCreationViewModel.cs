using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.Abstraction.DietManagement;
using myDietManager.Abstraction.Entities;
using myDietManager.View.ProfileCreationViews.Interfaces;
using myDietManager.ViewModel.Base;
using StructureMap;

namespace myDietManager.ViewModel.ProfileCreation.Views
{
    public class AutoProfileCreationViewModel : BaseViewModel, IAutoProfileCreationViewModel, IDataErrorInfo
    {
        public IDietProfile DietProfile { get; set; }
        private readonly IDietManager _dietManager;
        public IDictionary<string, bool> ValidAttributes { get; set; }
        public ObservableCollection<string> Goals { get; set; }
        private ICommand _finishProfileCreationCommand;

        public AutoProfileCreationViewModel(IAutoProfileCreationView view, StructureMap.IContainer container) : base(view, container)
        {
            this.DietProfile = this.Container.GetInstance<IDietProfile>();
            this._dietManager = this.Container.GetInstance<IDietManager>();
            this.Goals = this.PopulateGoalList();
        }

        private ObservableCollection<string> PopulateGoalList() => new ObservableCollection<string>
        {
            "Gain",
            "Lose"
        };

        #region Attributes

        [Required(ErrorMessage = @"A profile name must be entered")]
        public string ProfileName
        {
            get { return this.DietProfile.ProfileName; }
            set
            {
                if (this.DietProfile.ProfileName == value)
                {
                    return;
                }

                this.DietProfile.ProfileName = value;
                OnPropertyChanged("ProfileName");
            }
        }

        [Required]
        [Range(35 * 2.2f, 250 * 2.2f)]
        public double Weight
        {
            get { return this.DietProfile.Weight; }
            set
            {

                this.DietProfile.Weight = value;
                OnPropertyChanged("Weight");
            }
        }

        [Required]
        [Range(100, 300)]
        public double Height
        {
            get { return this.DietProfile.Height; }
            set
            {
                if ( Math.Abs(this.DietProfile.Height - value) <= 0 )
                {
                    return;
                }
                this.DietProfile.Height = value;
                OnPropertyChanged("Height");
            }
        }

        [Required]
        public string SelectedGoal
        {
            get { return this.DietProfile.Goal; }
            set
            {
                if (this.DietProfile.Goal == value)
                {
                    return;
                }
                
                this.DietProfile.Goal = value;
                OnPropertyChanged("SelectedGoal");
            }
        }

        [Required]
        [Range(6, 35)]
        public int DietDuration
        {
            get { return this.DietProfile.DietDuration; }
            set
            {
                if ( this.DietProfile.DietDuration == value )
                {
                    return;
                }
                this.DietProfile.DietDuration = value;
                OnPropertyChanged("DietDuration");
            }
        }

        [Required]
        [Range(100, 400)]
        public double WeightGoal
        {
            get { return this.DietProfile.WeightGoal; }
            set
            {
                if ( Math.Abs(this.DietProfile.WeightGoal - value) <= 0 )
                {
                    return;
                }

                this.DietProfile.WeightGoal = value;
                OnPropertyChanged("WeightGoal");
            }
        }

        [Required]
        public int ActivityLevel
        {
            get { return this.DietProfile.ActivityLevel; }
            set
            {
                if ( this.DietProfile.ActivityLevel == value )
                {
                    return;
                }

                this.DietProfile.ActivityLevel = value;
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
            this._dietManager.FinalizeDietProfileCreation(this.DietProfile);


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
