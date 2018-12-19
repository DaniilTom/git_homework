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
        ObservableCollection<Department> col = new ObservableCollection<Department>();

        public MainWindow()
        {
            InitializeComponent();

            Employee[] Employees;
            foreach (Department d in SupportMethods.CreateSet(out Employees))
            {
                col.Add(d);
            }

            listView.ItemsSource = col;
        }
    }
}
