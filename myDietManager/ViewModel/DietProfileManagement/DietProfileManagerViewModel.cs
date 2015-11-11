using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
