using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicketSeller.ViewModel
{
    public class MainWindowVM
    {
        public ICommand CommandConfirm { get; }

        public MainWindowVM()
        {
            CommandConfirm = new RelayCommand(ConfrimFilmSelect);
        }
        
        private void ConfrimFilmSelect(object content)
        {
            MessageBox.Show(content.ToString());
        }
    }

    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _act;

        public RelayCommand(Action<object> act) { _act = act; }

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter)
        {
            _act(parameter);
        }
    }
}
