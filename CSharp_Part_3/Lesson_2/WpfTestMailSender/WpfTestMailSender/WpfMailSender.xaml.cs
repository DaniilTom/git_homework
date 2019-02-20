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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            cbSenderSelect.ItemsSource = StaticVars.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";

            cbSmtpSelect.ItemsSource = StaticVars.Servers;
            cbSmtpSelect.DisplayMemberPath = "Key";
            cbSmtpSelect.SelectedValuePath = "Value";

            dgEmails.ItemsSource = Database.Emails;
        }

        /// <summary>
        /// Отправка сразу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateMessage() == false) return;

            // c использованием библиотеки
            //EmailSenderLib.EmailSendServiceClass essc =
            //    new EmailSenderLib.EmailSendServiceClass(cbSenderSelect.Text, cbSenderSelect.SelectedValue.ToString(),
            //                                cbSmtpSelect.Text, (int)cbSmtpSelect.SelectedValue);

            // в EmailSendServiceClass требуется использовать класс Emails. Но этот класс есть и в текущем приложении, и в библиотеке,
            //  в связи с чем возникает конфилкт имен. Чтобы использовать библиотеку в этом приложении, надо еще везде заменить Emails класс
            //  текущего приложения на EmailSenderLib.Emails класс библиотеки, но это как-то неудобно и рабочее приложение не хочется
            //  лишний раз трогать. (Но можно было бы описать интерфейс, но я не успеваю так быстро схватывать материал).


            EmailSendServiceClass essc =
                new EmailSendServiceClass(cbSenderSelect.Text, cbSenderSelect.SelectedValue.ToString(),
                                            cbSmtpSelect.Text, (int)cbSmtpSelect.SelectedValue);

            essc.StartMailing((IQueryable<Emails>) dgEmails.ItemsSource);

            SendEndWindow sew = new SendEndWindow("Работа завершена");
            sew.ShowDialog();
        }

        /// <summary>
        /// Отправка по расписанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateMessage() == false) return;

            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты");
                return;
            }
            DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);

            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Раньше, чем настоящее время.");
                return;
            }

            EmailSendServiceClass emailSender = 
                new EmailSendServiceClass(cbSenderSelect.Text, cbSenderSelect.SelectedValue.ToString(),
                                            cbSmtpSelect.Text, (int)cbSmtpSelect.SelectedValue);

            sc.SendEmails(dtSendDateTime, emailSender, (IQueryable<Emails>)dgEmails.ItemsSource);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPlanner;
        }

        private bool ValidateMessage()
        {
            if (String.IsNullOrEmpty(tbMessage.Text))
            {
                MessageBox.Show("Сообщение не может быть пустым.");
                tabControl.SelectedItem = tabEdit;
                return false;
            }
            return true;
        }
    }
}
