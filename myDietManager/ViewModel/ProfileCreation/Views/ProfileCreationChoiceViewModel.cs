using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.View.ProfileCreationViews;
using myDietManager.View.ProfileCreationViews.Interfaces;
using myDietManager.ViewModel.Base;
using myDietManager.ViewModel.ProfileCreation.Window;
using StructureMap;

namespace myDietManager.ViewModel.ProfileCreation.Views
{
    public enum CreationChoice
    {
        Auto,
        Manual
    };
    
    public class ProfileCreationChoiceViewModel : BaseViewModel, IProfileCreationChoiceViewModel
    {
        public IProfileCreationWindow ProfileCreationWindow { get; set; }
        private CreationChoice _choice;
        private ICommand _confirmProfileCreationChoice;

        public ProfileCreationChoiceViewModel(IProfileCreationChoiceView view, IContainer container, IProfileCreationWindow mainWindow)
            : base(view, container)
        {
            this.ProfileCreationWindow = mainWindow;
        }

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
                ? (ViewModelBase) new AutoProfileCreationViewModel(this.ProfileCreationWindow) 
                : new ManualProfileCreationViewModel(this.ProfileCreationWindow);
        }

        public bool CanNaviguateToProfileCreation()
        {
            //return this.IsAuto || this.IsManual;
            return true;
        }
    }
}
