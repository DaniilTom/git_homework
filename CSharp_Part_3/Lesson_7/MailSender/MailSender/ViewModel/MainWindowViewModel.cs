using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MailSender.Service;
using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataAccessService _dataService;
        private ObservableCollection<Emails> _emails = new ObservableCollection<Emails>();

        public ObservableCollection<Emails> Emails
        {
            get => _emails;
            set
            {
                Set(ref _emails, value);
                //if (Equals(_emails, value)) return;
                //_emails = value;
                //RaisePropertyChanged(nameof(Emails));
            }
        }
        private Emails _currentEmail = new Emails();
        public Emails CurrentEmail
        {
            get => _currentEmail;
            set => Set(ref _currentEmail, value);
        }

        public RelayCommand<Emails> SaveEmailCommand { get; }
        public RelayCommand ReadAllMailsCommand { get; }

        public MainWindowViewModel(IDataAccessService dataService)
        {
            _dataService = dataService;
            ReadAllMailsCommand = new RelayCommand(GetEmails);
            SaveEmailCommand = new RelayCommand<Emails>(SaveEmail);

            DataGridFilter = new RelayCommand<object>(DataGridFiltering);
            GetMyCommand = new MyCommand(DataGridFiltering);
        }

        private void SaveEmail(Emails email)
        {
            email.Id = _dataService.CreateEmail(email);
            if (email.Id == 0) return;
            Emails.Add(email);
        }

        private void GetEmails() => Emails = _dataService.GetEmails();

        //public RoutedCommand MyCommand { get; } = new RoutedCommand();

        public RelayCommand<object> DataGridFilter { get; }

        private void DataGridFiltering(object ob)
        {
            // всегда заново берем все Email
            GetEmails();

            // потом просеиваем их по имени без учета регистра
            var em = (from e in Emails
                     where e.Name.StartsWith((string)ob, true, System.Globalization.CultureInfo.CurrentCulture)
                     select e).ToList();

            Emails = new ObservableCollection<Emails>(em);
        }

        // реализация ICommand на прямую
        public MyCommand GetMyCommand { get; }
        public class MyCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            Action<object> _methToDo;

            public MyCommand(Action<object> m)
            {
                _methToDo = m;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object ob)
            {
                _methToDo(ob);
            }
        }
    }
}
