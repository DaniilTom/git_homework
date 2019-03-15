using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xceed.Words.NET;

namespace MailSender
{
	public partial class MainWindow : Window
	{
		private EmailSendServiceClass _emailSender;

		public MainWindow()
		{
			InitializeComponent();

			#region Task

			object a = 1;
			object b = 1;

			Console.WriteLine(a==b);
			Console.WriteLine(a.Equals(b));
			Console.WriteLine(Object.ReferenceEquals(b, a));

			#endregion
		}

		private void TabSwitcherControl_OnBack(object sender, RoutedEventArgs e)
		{
			if (MainTabControl.SelectedIndex == 0) return;
			MainTabControl.SelectedIndex--;
		}

		private void TabSwitcherControl_OnForward(object sender, RoutedEventArgs e)
		{
			if (MainTabControl.SelectedIndex == MainTabControl.Items.Count - 1) return;
			MainTabControl.SelectedIndex++;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			//KeyValuePair<string, string> item = (KeyValuePair<string, string>) cbSenderSelect.SelectionBoxItem;
			//MessageBox.Show(item.Value);
			//string strLogin = cbSenderSelect.Text;
			//string strPassword = cbSenderSelect.SelectedValue.ToString();
			//if (string.IsNullOrEmpty(strLogin))
			//{
			//	MessageBox.Show("Выберите отправителя");
			//	return;
			//}
			//if (string.IsNullOrEmpty(strPassword))
			//{
			//	MessageBox.Show("Укажите пароль отправителя");
			//	return;
			//}
			//_emailSender = new EmailSendServiceClass(strLogin, strPassword);
			//_emailSender.SendMails((IQueryable<Emails>)dgEmails.ItemsSource);

		}
	}
}
