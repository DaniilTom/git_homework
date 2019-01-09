using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using static WpfApp2.MainWindow;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindowEmployee : Window
    {
        ObservableCollection<Department> colD;
        public RowViewTemplate result { get; set; } 
        public EditWindowEmployee(RowViewTemplate dataRowEmployee, ObservableCollection<Department> _colD)
        {
            InitializeComponent();
            result = dataRowEmployee;
            colD = _colD;
            selectorCB.ItemsSource = colD;
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = result.Employee_Name;
            //DepartamentNameTextBoxTextBox.Text = resultRow["Departament_ID"].ToString();
            selectorCB.SelectedValue = result.Departament_Name;
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            result.Employee_Name = NameTextBox.Text;
            result.Departament_Name = selectorCB.SelectedValue.ToString();
            DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
