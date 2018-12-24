using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindowDepartament : Window
    {
        public DataRow resultRow { get; set; }
        ObservableCollection<Department> colD;
        public EditWindowDepartament(DataRow dataRowDepartament, ObservableCollection<Department> _colD)
        {
            InitializeComponent();

            colD = _colD;
            
            resultRow = dataRowDepartament;
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            colD.Add(new Department(textBoxName.Text));
            resultRow["Name"] = textBoxName.Text;
            DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
