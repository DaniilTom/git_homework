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

        public EditWindow(ObservableCollection<Department> _colD)
        {
            InitializeComponent();
            colD = _colD;

            leftCB.ItemsSource = colD;
            leftCB.SelectedIndex = -1;

            rightCB.ItemsSource = colD;
            rightCB.SelectedIndex = -1;

            addCB.ItemsSource = colD;
            addCB.SelectedItem = -1;

        }

        // MoveToRight и MoveToLeft переносят Employee между списками в направлении, 
        // соответствующему положению столбцов

        private void MoveToRight(object sender, RoutedEventArgs e)
        {
            try
            {
                (rightCB.SelectedItem as Department).AddEmployee(leftLB.SelectedItem as Employee);
                SendToLog("OK");
            }
            catch (NullReferenceException)
            { SendToLog("Проверьте выбор Employee/Department и повторите попытку"); }
        }

        private void MoveToLeft(object sender, RoutedEventArgs e)
        {
            try
            {
                (leftCB.SelectedItem as Department).AddEmployee(rightLB.SelectedItem as Employee);
                SendToLog("OK");
            }
            catch (NullReferenceException)
            { SendToLog("Проверьте выбор Employee/Department и повторите попытку"); }
        }

        // LeftCB_SelectionChanged и RightCB_SelectionChanged выполняют динамическую привязку
        // списков Employee, которые принадлежат выбранному Department
        private void LeftCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            leftLB.ItemsSource = (leftCB.SelectedItem as Department).empList;
        }

        private void RightCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rightLB.ItemsSource = (rightCB.SelectedItem as Department).empList;
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
