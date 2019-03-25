using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace EmailSenderLib
{
    public class EmailSendServiceClass
    {

        string _senderEmail;
        string _hostName;
        int _port;
        string _password;

        public EmailSendServiceClass(string sender, string password, string host, int port)
        {
            _senderEmail = sender;
            _password = password;
            _hostName = host;
            _port = port;
        }

        public void StartMailing(IQueryable<Emails> emails)
        {
            foreach (var mail in emails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage(_senderEmail, mail.Email))
                {
                    // Формируем письмо
                    mm.Subject = mail.Name;     // Заголовок письма
                    mm.Body = "Hello world";       // Тело письма
                    mm.IsBodyHtml = false;           // Не используем html в теле письма
                                                     // Авторизуемся на smtp-сервере и отправляем письмо
                    using (SmtpClient sc = new SmtpClient(_hostName, _port))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(_senderEmail, _password);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            SendEndWindow sew = new SendEndWindow("Невозможно отправить письмо " + ex.ToString());
                            sew.ISendEnd.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                            sew.ISendEnd.FontSize = 11;
                            sew.ShowDialog();
                        }
                    }
                }
            }
        }
    }
}
