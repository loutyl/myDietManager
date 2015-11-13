namespace myDietManager.ViewModel.DietProfileManagement
{
    public class DietProfileManagerViewModel
    {
        private readonly UsersDietProfile _dietProfile;

        public DietProfileManagerViewModel(UsersDietProfile dietProfile)
        {
            this._dietProfile = dietProfile;
        }
    }
}
