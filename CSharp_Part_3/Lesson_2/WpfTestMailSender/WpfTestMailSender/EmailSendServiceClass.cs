using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfTestMailSender
{
    class EmailSendServiceClass
    {
        List<string> _listStrMails;

        string _senderEmail;
        string _hostName;
        int _port;

        public EmailSendServiceClass(string sender, string host, int port, List<string> addressList)
        {
            _senderEmail = sender;
            _hostName = host;
            _port = port;
            _listStrMails = addressList;
        }

        public void StartMailing(string strPassword, string theme, string message)
        {
            foreach (string mail in _listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage(_senderEmail, mail))
                {
                    // Формируем письмо
                    mm.Subject = theme; // Заголовок письма
                    mm.Body = message;       // Тело письма
                    mm.IsBodyHtml = false;           // Не используем html в теле письма
                                                     // Авторизуемся на smtp-сервере и отправляем письмо
                                                     // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
                                                     // методов в объекте происходит исключение.
                    using (SmtpClient sc = new SmtpClient(_hostName, _port))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(_senderEmail, strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            SendEndWindow sew = new SendEndWindow("Невозможно отправить письмо " + ex.ToString());
                            sew.ISendEnd.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                            sew.ISendEnd.FontSize = 20;
                            sew.ShowDialog();
                        }
                    }
                } //using (MailMessage mm = new MailMessage("sender@yandex.ru", mail))
            }
        }
    }
}
