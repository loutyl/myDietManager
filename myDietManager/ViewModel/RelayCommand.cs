﻿using System;
using System.Windows.Input;

namespace myDietManager.ViewModel
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other
    /// objects by invoking delegates. The default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand
    {
   
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        private readonly Action<object> _executeWithParameter;
        private readonly Predicate<object> _canExecutePredicate;
     

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this._canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this._execute = execute;
            this._canExecute = canExecute;
        }

        public RelayCommand(Action<object> executeParam, Predicate<object> canExecutePredicate)
        {
            if (this._executeWithParameter == null)
                throw new ArgumentNullException("executeParam");

            this._executeWithParameter = executeParam;
            this._canExecutePredicate = canExecutePredicate;
        }

        public void ExecuteWithParameter(object parameter)
        {
            this._executeWithParameter(parameter);
        }

        public void Execute(object parameter)
        {
            this._execute();
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || _canExecute();
        }

        public bool CanExecutePredicate(object parameter)
        {
            return this._canExecutePredicate == null || this._canExecutePredicate(parameter);
        }
    }
}
