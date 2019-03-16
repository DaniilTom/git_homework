using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TicketSeller.Model;

namespace TicketSeller.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        public ICommand CommandConfirm { get; }
        public ObservableCollection<Film> GetFilms { get; set; } = new ObservableCollection<Film>();
        public TicketsContainer GetTicketsContainer { get; } = new TicketsContainer();
        public ObservableCollection<Ticket> _tickets;

        public MainWindowVM()
        {
            CommandConfirm = new RelayCommand(ConfrimFilmSelect);

            GetFilms.Add(new Film { Title = "Film 1"});
            GetFilms.Add(new Film { Title = "Film 2" });
            _tickets = new ObservableCollection<Ticket>(GetTicketsContainer.TicketSet.ToList());

        }
        
        /// <summary>
        /// Метод для комманды CommandConfirm
        /// </summary>
        /// <param name="content"></param>
        private void ConfrimFilmSelect(object content)
        {
            //вызов окна покупки
            View.BuyTicketWindow bt = new View.BuyTicketWindow(new Film(content.ToString()));
            bt.ShowDialog();

            //получаем сгенерированный билет
            Ticket t = bt.GetTicket;

            //вносим изменения и сохраняем в БД
            GetTicketsContainer.TicketSet.Add(t);
            GetTicketsContainer.SaveChanges();

            //обновляем коллекция проданных билетов
            _tickets = new ObservableCollection<Ticket>(GetTicketsContainer.TicketSet.ToList());

            OnPropertyChanged("GetTickets");
        }

        /// <summary>
        /// Свойство для привязки в DataGrid
        /// </summary>
        public ObservableCollection<Ticket> GetTickets
        {
            get { return _tickets; }
            set { _tickets = value; OnPropertyChanged("GetTickets"); }
        }

    }

    /// <summary>
    /// Своя комманда
    /// </summary>
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

    /// <summary>
    /// Своя ViewModelBase
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, args);
        }
    }
}
