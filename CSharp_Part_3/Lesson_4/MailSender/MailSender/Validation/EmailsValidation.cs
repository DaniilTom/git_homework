using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    partial class Emails : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                
                switch(columnName)
                {
                    case nameof(Name):
                        string result = "Валидация через IDataErrorInfo. ";
                        MessageBox.Show(result);
                        if (!(Name.Length > 3 && Name.Length < 20)) MessageBox.Show(result + "Длина выходит за пределы.");
                        return result;

                    default: return "";
                }
                
            }
        }

        public string Error => throw new NotImplementedException();
    }
}
