using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace myDietManager.ViewModel.ProfileCreationViewModels
{
    public enum CreationChoice
    {
        Auto,
        Manual
    };
    
    public class ProfileCreationChoiceViewModel : ViewModelBase
    {
        public ProfileCreationWindowViewModel ProfileCreationWindow { get; set; }
        private CreationChoice _choice;
        private ICommand _confirmProfileCreationChoice;

        public ProfileCreationChoiceViewModel(ProfileCreationWindowViewModel profileCreationWindow)
        {
            this.ProfileCreationWindow = profileCreationWindow;
            this.ProfileCreationWindow.Window.Width = 300;
            this.ProfileCreationWindow.Window.Height = 225;
        }

        public bool IsManual
        {
            get { return this._choice == CreationChoice.Manual; }
            set
            {
                this._choice = value ? CreationChoice.Manual : CreationChoice.Auto;
                OnPropertyChanged("IsManual");
                OnPropertyChanged("IsAuto");
            }
        }

        public bool IsAuto 
        {
            get { return this._choice == CreationChoice.Auto; }
            set
            {
                this._choice = value ? CreationChoice.Auto : CreationChoice.Manual;
                OnPropertyChanged("IsManual");
                OnPropertyChanged("IsAuto");
            }
        }

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
            this.ProfileCreationWindow.CurrentViewModel = this._choice == CreationChoice.Auto 
                ? (ViewModelBase) new ProfileCreationViewModel(this.ProfileCreationWindow) 
                : new ManualProfileCreationViewModel(this.ProfileCreationWindow);
        }

        public bool CanNaviguateToProfileCreation()
        {
            //return this.IsAuto || this.IsManual;
            return true;
        }
    }
}
