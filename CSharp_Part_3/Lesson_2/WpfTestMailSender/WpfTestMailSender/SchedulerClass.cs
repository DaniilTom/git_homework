using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfTestMailSender
{
    class SchedulerClass
    {
        DispatcherTimer timer = new DispatcherTimer();
        EmailSendServiceClass emailSender;
        DateTime dtSend;
        IQueryable<Emails> emails;

        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse(strSendTime);
            }
            catch (Exception) { }
            return tsSendTime;
        }

        public void SendEmails(DateTime dtSend, EmailSendServiceClass emailSender, IQueryable<Emails> emails)
        {
            this.emailSender = emailSender;
            this.dtSend = dtSend;
            this.emails = emails;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString())
            {
                emailSender.StartMailing(emails);
                timer.Stop();
                MessageBox.Show("Письма отправлены");
            }
        }
    }
}
