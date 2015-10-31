using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace myDietManager.ViewModel.ProfileCreation
{
    public class ProfileCreationChoiceViewModel : ViewModelBase
    {
        public ProfileCreationWindowViewModel ProfileCreationWindow { get; set; }
        private ICommand _confirmProfileCreationChoice;

        public ProfileCreationChoiceViewModel(ProfileCreationWindowViewModel profileCreationWindow)
        {
            this.ProfileCreationWindow = profileCreationWindow;
        }

        public bool IsManual { get; set; }
        public bool IsAuto { get; set; }

        public ICommand ConfirmProfileCreationChoice
        {
            get
            {
                if ( this._confirmProfileCreationChoice != null )
                    return this._confirmProfileCreationChoice;

                this._confirmProfileCreationChoice = new RelayCommand(() => this.NaviguateToProfileCreation(), () => this.CanNaviguateToProfileCreation());

                return this._confirmProfileCreationChoice;
            }
        }

        public void NaviguateToProfileCreation()
        {
            this.ProfileCreationWindow.CurrentViewModel = IsManual 
                ? new ProfileCreationViewModel(this.ProfileCreationWindow) 
                : null;
        }

        public bool CanNaviguateToProfileCreation()
        {
            return this.IsAuto || this.IsManual;
        }
    }
}
