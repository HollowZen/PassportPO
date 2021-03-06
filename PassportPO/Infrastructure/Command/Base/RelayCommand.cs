using System;
using System.Diagnostics;
using System.Windows.Input;

namespace PassportPO.Infrastructure.Command.Base
{
    internal class RelayCommand : ICommand
    {
        #region Поля

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion // Поля 

        #region Конструктор

        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object>? canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute; _canExecute = canExecute;
        }

        #endregion // Конструктор 

        #region ICommand Члены

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter) { _execute(parameter); }


        #endregion // ICommand Члены
    }
}
