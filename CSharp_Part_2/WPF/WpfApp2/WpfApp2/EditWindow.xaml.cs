using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public ObservableCollection<Department> colD { get; set; }
        public ObservableCollection<Employee> colE { get; set; }

        public EditWindow(ObservableCollection<Department> _colD, ObservableCollection<Employee> _colE)
        {
            InitializeComponent();
            colD = _colD;
            colE = _colE;

            addCB.ItemsSource = colD;
            addCB.SelectedItem = -1;

            editDG.ItemsSource = colE;
            columnCB.ItemsSource = colD;
        }

        // AddingNewEmployee и AddingNewDepartament добавляют новые сущности
        private void AddingNewEmployee(object sender, RoutedEventArgs e)
        {
            try
            {
                (addCB.SelectedItem as Department).AddEmployee(new Employee(textBoxInput.Text));
                SendToLog("OK");
            }
            catch (NullReferenceException)
            { SendToLog("Проверьте выбор Employee/Department и повторите попытку"); }
        }

        private void AddingNewDepartament(object sender, RoutedEventArgs e)
        {
            colD.Add(new Department(textBoxInputDep.Text));
        }

        /// <summary>
        /// Передает сообщение в лог.
        /// </summary>
        /// <param name="msg"></param>
        private void SendToLog(string msg)
        {
            textBlockLog.Text = msg;
            if(msg != "OK") System.Media.SystemSounds.Hand.Play();
        }
    }
}
