using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    public static class StaticVars
    {
        // при отладке использовал в качестве отправителя и получателя свой email
        // заменил заглушками
        public static List<string> ListStrMails = new List<string> { "example@yandex.ru" };
        public static string SenderEmail = "example@yandex.ru";
        public static string HostName = "smtp.yandex.ru";
        public static int Port = 25;

        public static Dictionary<string, int> Servers
        {
            get { return smtpServers; }
        }
        public static Dictionary<string, int> smtpServers = new Dictionary<string, int>()
        {
            { "smtp.yandex.ru", 25 }
        };

        public static Dictionary<string, string> Senders
        {
            get { return dicSenders; }
        }
        public static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            { "79257443993@yandex.ru",PasswordClass.getPassword("1234l;i") },
            { "sok74@yandex.ru",PasswordClass.getPassword(";liq34tjk") }
        };

        //public static Dictionary<string, string> SendersD { get; } = new Dictionary<string, string>
        //{
        //    {"asdvv", "1234" },
        //    {"ghghjm", "456" }
        //};
    }
}
