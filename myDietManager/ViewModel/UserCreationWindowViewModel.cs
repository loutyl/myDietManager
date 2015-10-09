using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace myDietManager.ViewModel
{
    public class UserCreationWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private ICommand _changeViewCommand;

        public ViewModelBase CurrentViewModel
        {
            get { return this._currentViewModel; }
            set
            {
                if (this._currentViewModel != value)
                {
                    this._currentViewModel = value;
                    OnPropertyChanged("CurrentViewModel");
                }
            }
        }

        public ICommand ChangeViewCommand
        {
            get
            {
                if (this._changeViewCommand != null)
                    return this._changeViewCommand;

                this._changeViewCommand = new RelayCommand(() => this._currentViewModel = new UserInformationRecapViewModel());

                return this._changeViewCommand;
            }
        }

        public UserCreationWindowViewModel()
        {
            this.CurrentViewModel = new UserInformationViewModel();
        }

    }
}
