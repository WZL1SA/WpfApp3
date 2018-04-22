using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp3
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void OnCanExecuteChanged() // jeśli ktoś wybierze zamówienie wysłana notyfikacja to przekaże informacje do CanExecuteChange
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private readonly Action<object> execute;  //delegat typowany readonly można go zainicjalizować tylko w konstruktorze lub w jego deklaracji, nie można go później zmieniać

        private readonly Func<object, bool> canExecute;  //delegat w którym możesz określić wynik  1 parametr - co przychodzi, 2 parametr - co zwraca

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute; // przekazuje akcję do wykonania do zapamiętania
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute.Invoke(parameter);  // invoke służy do jawnego wywoływania metody
        }

        public void Execute(object parameter)
        {
            if (execute != null)             // sprawdza czy jest przekazana jakaś akcja
                execute.Invoke(parameter);  // wywołujemy metody przekazane przez Action


            // execute?.Invoke(parameter);   // można stosować zamiennie od C# 6.0

        }
    }

    //public class RelayCommand : ICommand
    //{
    //    private Action execute;
    //    private Func<bool> canExecute;

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }

    //    public RelayCommand(Action execute, Func<bool> canExecute = null)
    //    {
    //        this.execute = execute;
    //        this.canExecute = canExecute;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        if (canExecute == null)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return canExecute.Invoke();
    //        }
    //    }

    //    public void Execute(object parameter)
    //    {
    //        this.execute.Invoke();
    //    }
    //}
}
