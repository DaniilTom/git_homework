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
    }
}
