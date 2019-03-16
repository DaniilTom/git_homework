using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicketSeller.Model;

namespace TicketSeller.View
{
    /// <summary>
    /// Логика взаимодействия для BuyTicketWindow.xaml
    /// </summary>
    public partial class BuyTicketWindow : Window
    {
        //public string FilmTitle { get; set; } = "Название фильма";

        public BuyTicketWindow(Film film)
        {
            InitializeComponent();

            FilmTitle.Text = film.Title;
        }

        public Ticket GetTicket{ get; set; }

        private void Sell(object sender, RoutedEventArgs a)
        {
            Ticket ticket = new Ticket();

            ticket.FilmName = FilmTitle.Text;
            ticket.Count = Count.Value ?? 1;

            DateTime dt = Date.SelectedDate ?? new DateTime();
            DateTime d_tp = Time.Value ?? new DateTime();
            dt = dt.AddHours(d_tp.Hour).AddMinutes(d_tp.Minute);

            ticket.Date = dt;

            GetTicket = ticket;

            this.Close();
            
        }
    }
}
