namespace myDietManager.ViewModel.ProfileCreationViewModels
{
    public class ManualProfileCreationViewModel : ViewModelBase
    {
        private readonly ProfileCreationWindowViewModel _profileCreationWindow;

        public ManualProfileCreationViewModel(ProfileCreationWindowViewModel profileCreationWindow)
        {
            this._profileCreationWindow = profileCreationWindow;
            this._profileCreationWindow.Window.Width = 600;
            this._profileCreationWindow.Window.Height = 365;
        }
    }
}
