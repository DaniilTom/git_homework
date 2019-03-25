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

namespace MailSender.Views
{
	/// <summary>
	/// Логика взаимодействия для SaveEmailView.xaml
	/// </summary>
	public partial class SaveEmailView : UserControl
	{
		public SaveEmailView()
		{
			InitializeComponent();
		}

        private void Validation_OnError(object sender, ValidationErrorEventArgs e)
        {
            switch(e.Action)
            {
                case ValidationErrorEventAction.Added:
                    //string name = ((TextBox)sender).Text;
                    //MessageBox.Show(name);
                    //if (name.Length > 3 || name.Length < 20) MessageBox.Show("Валидация через событие.");
                    MessageBox.Show("Валидация через событие.");
                    break;
            }
        }
    }
}
