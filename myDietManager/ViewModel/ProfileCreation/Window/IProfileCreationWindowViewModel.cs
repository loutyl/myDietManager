﻿using myDietManager.ViewModel.Base;

namespace myDietManager.ViewModel.ProfileCreation.Window
{
    public interface IProfileCreationWindowViewModel : IWindowViewModel
    {
        IWindowViewModel CurrentViewModel { get; set; }
    }
}
