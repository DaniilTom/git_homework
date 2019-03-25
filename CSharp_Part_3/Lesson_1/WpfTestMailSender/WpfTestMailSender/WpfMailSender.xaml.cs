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
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = StaticVars.ListStrMails;  // Список email'ов //кому мы отправляем письмо
            string strPassword = passwordBox.Password;  // для WinForms - string strPassword = passwordBox.Text;
            string theme = themeBox.Text;
            string message = messageBox.Text;

            EmailSendServiceClass essc = new EmailSendServiceClass(StaticVars.SenderEmail,
                                                                    StaticVars.HostName,
                                                                    StaticVars.Port,
                                                                    StaticVars.ListStrMails);

            essc.StartMailing(strPassword, theme, message);

            SendEndWindow sew = new SendEndWindow("Работа завершена");
            sew.ShowDialog();
        }
    }
}
