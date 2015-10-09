using myDietManager.Model;

namespace myDietManager.ViewModel
{
    public class UserInformationRecapViewModel : ViewModelBase
    {
        private User _newUser;

        public UserInformationRecapViewModel(User newUser)
        {
            this._newUser = newUser;
        }
    }
}
