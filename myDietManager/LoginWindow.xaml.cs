﻿using System.Windows;
using myDietManager.Class.Security;
using myDietManager.ViewModel;

namespace myDietManager
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = new LoginWindowViewModel(new AuthentificationHandler());
        }
    }
}
