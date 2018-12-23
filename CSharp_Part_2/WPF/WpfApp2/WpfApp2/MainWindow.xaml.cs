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
        //public ObservableCollection<Employee> colE = new ObservableCollection<Employee>();
        public ObservableCollection<Department> colD { get; set; }//= new ObservableCollection<Department>();

        public MainWindow()
        {
            InitializeComponent();

            colD = new ObservableCollection<Department>();

            Employee[] Employees;
            foreach (Department d in SupportMethods.CreateSet(out Employees))
            {
                colD.Add(d);
            }

            //foreach(Employee e in Employees)
            //{
            //    colE.Add(e);
            //}

            //listView.ItemsSource = colD;
            //listView.DataContext = colD;
            this.DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditWindow ew = new EditWindow(colD);
            ew.Owner = this;
            ew.Show();
        }
    }
}
