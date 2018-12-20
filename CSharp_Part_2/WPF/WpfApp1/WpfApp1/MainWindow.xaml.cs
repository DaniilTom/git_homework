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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> colE = new ObservableCollection<Employee>();
        //public ObservableCollection<Employee> colE { get; set; }
        public ObservableCollection<Department> colD = new ObservableCollection<Department>();

        public MainWindow()
        {
            InitializeComponent();

            Employee[] Employees;
            foreach (Department d in SupportMethods.CreateSet(out Employees))
            {
                colD.Add(d);
            }

            foreach(Employee e in Employees)
            {
                colE.Add(e);
            }

            listView.ItemsSource = colE;
            //this.DataContext = colE;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
