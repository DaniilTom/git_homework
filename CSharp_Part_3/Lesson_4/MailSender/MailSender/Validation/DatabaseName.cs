using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MailSender.Validation
{
    class DatabaseName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            MessageBox.Show("Валидация через ValidationRule.");

            string Name = value as string;

            if (!(Name.Length > 3 && Name.Length < 20))
            {
                return new ValidationResult(false, "Валидация через ValidationRule. Длина выходит за пределы.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
