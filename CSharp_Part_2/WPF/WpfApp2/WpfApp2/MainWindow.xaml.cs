using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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
        public ObservableCollection<Employee> colE { get; set; }
        public ObservableCollection<Department> colD { get; set; }//= new ObservableCollection<Department>();

        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;

        public MainWindow()
        {
            InitializeComponent();

            colD = new ObservableCollection<Department>();
            colE = new ObservableCollection<Employee>();

            //создадим набор данных
            Employee[] Employees;
            Department[] Departments = Support.CreateSet(out Employees);

            foreach (Department d in Departments)
            {
                colD.Add(d);
            }

            foreach(Employee e in Employees)
            {
                colE.Add(e);
            }


            connection = new SqlConnection(Support.connectionString);
            adapter = new SqlDataAdapter();
            
            connection.Open();

            // если надо создать таблицы
            //command = new SqlCommand(Support.createTables, connection);
            //command.ExecuteNonQuery();

            // заполнение таблицы Departament
            SqlCommand command = new SqlCommand(Support.addDepartment, connection);
            foreach (Department d in Departments)
            {
                command.Parameters.AddWithValue("@Name", d.FullName);
                int i = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }

            // Заполнене таблицы Employee
            command = new SqlCommand(Support.addEmployee, connection);
            foreach (Employee e in Employees)
            {
                command.Parameters.AddWithValue("@Name", e.FullName);
                command.Parameters.AddWithValue("@Departament_ID", e.Departament_ID);
                int i = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }

            dt = new DataTable();

            

            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditWindow ew = new EditWindow(colD, colE);
            ew.Owner = this;
            ew.Show();
        }
    }
}
