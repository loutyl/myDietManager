using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using myDietManager.View.ProfileCreationViews.Interfaces;
using myDietManager.ViewModel.Base;
using myDietManager.ViewModel.ProfileCreation.Window;
using StructureMap;

namespace myDietManager.ViewModel.ProfileCreation.Views
{
    public enum CreationMethod
    {
        Auto,
        Manual
    };
    
    public class ProfileCreationChoiceViewModel : BaseViewModel, IProfileCreationChoiceViewModel
    {
        private readonly IProfileCreationWindowViewModel _profileCreationWindow;
        private CreationMethod _choice;
        private ICommand _confirmProfileCreationChoice;

        public ProfileCreationChoiceViewModel(IProfileCreationChoiceView view, IContainer container)
            : base(view, container)
        {
        }

        public bool IsManual
        {
            get { return this._choice == CreationMethod.Manual; }
            set
            {
                this._choice = value ? CreationMethod.Manual : CreationMethod.Auto;
                OnPropertyChanged("IsManual");
                OnPropertyChanged("IsAuto");
            }
        }

        public bool IsAuto 
        {
            get { return this._choice == CreationMethod.Auto; }
            set
            {
                this._choice = value ? CreationMethod.Auto : CreationMethod.Manual;
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
            if (this._choice == CreationMethod.Auto)
            {
                var test = this.Container.GetInstance<IProfileCreationWindowViewModel>();
                test.ShowView<IAutoProfileCreationViewModel>();
            }
            else
            {
                this._profileCreationWindow.ShowView<IManualProfileCreationViewModel>();
            }
            
        }

        public bool CanNaviguateToProfileCreation()
        {
            //return this.IsAuto || this.IsManual;
            return true;
        }
    }
}
