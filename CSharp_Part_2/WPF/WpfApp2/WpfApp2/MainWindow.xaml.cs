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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> colE { get; set; }
        public ObservableCollection<Department> colD { get; set; }//= new ObservableCollection<Department>();

        SqlConnection connection;
        SqlDataAdapter departamentAdapter, employeeAdapter;
        DataTable departamentTable;
        DataTable employeeTable;

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
            
            connection.Open();
            SqlCommand command;
            // если надо создать таблицы
            //command = new SqlCommand(Support.createTables, connection);
            //command.ExecuteNonQuery();

            // заполнение таблицы Departament
            /********************************Если данные уже имеются, можно закомментировать */
            // Атрибуты таблиц см. в Entities.cs Support строки создания таблиц
            command = new SqlCommand(Support.addDepartment, connection);
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
            // конец заполнения таблиц

            InitAdapters();
            
            dataGrid.ItemsSource = UpdateResult();
        }

        private void Button_UpdateData(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = UpdateResult();
        }

        /// <summary>
        /// Метод инкапсулирует SQL-запросы.
        /// </summary>
        private void InitAdapters()
        {
            /*******************************************************/
            departamentAdapter = new SqlDataAdapter();
            // добавить комманду выбора
            departamentAdapter.SelectCommand = new SqlCommand(Support.selectAllDepartment, connection);

            // добавить комманду создания нового департамента
            SqlCommand comm = new SqlCommand(Support.addDepartment, connection);
            comm.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            departamentAdapter.InsertCommand = comm;

            /*****************************************************/
            employeeAdapter = new SqlDataAdapter();
            // добавить комманду выбора
            employeeAdapter.SelectCommand = new SqlCommand(Support.selectAllEmployees, connection);

            // добавить комманду создания нового сотрудника
            comm = new SqlCommand(Support.addEmployee, connection);
            comm.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            comm.Parameters.Add("@Departament_ID", SqlDbType.Int, 4, "Departament_ID");
            employeeAdapter.InsertCommand = comm;

            // добавить комманду изменения сотрудника
            comm = new SqlCommand(Support.updateEmployee, connection);
            comm.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            comm.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            comm.Parameters.Add("@Departament_ID", SqlDbType.Int, 4, "Departament_ID");
            employeeAdapter.UpdateCommand = comm;

            departamentTable = new DataTable();
            employeeTable = new DataTable();
        }

        /// <summary>
        /// Метод добавления департамента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_addDepartament(object sender, RoutedEventArgs e)
        {
            DataRow nr = departamentTable.NewRow();
            EditWindowDepartament ed = new EditWindowDepartament(nr, colD);
            ed.ShowDialog();
            if (ed.DialogResult.HasValue && ed.DialogResult.Value)
            {
                departamentTable.Rows.Add(ed.resultRow);
                departamentAdapter.Update(departamentTable);
            }

            dataGrid.ItemsSource = UpdateResult();
        }

        /// <summary>
        /// Метод добавления / редактирования сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_editEmployee(object sender, RoutedEventArgs e)
        {

            RowViewTemplate newRow = (RowViewTemplate) dataGrid.SelectedItem;
            if (newRow != null) // если было выбрано какое-то значение - редактировать его
            {
                EditWindowEmployee ee = new EditWindowEmployee(newRow, colD);
                ee.ShowDialog();
                if (ee.DialogResult.HasValue && ee.DialogResult.Value)
                {
                    // обновим данные строки и выполним обновление
                    DataRow dr = employeeTable.Rows[ee.result.Employee_ID-1];
                    dr.BeginEdit();
                    dr["ID"] = ee.result.Employee_ID;
                    dr["Name"] = ee.result.Employee_Name;
                    dr["Departament_ID"] = colD.Where(d => d.FullName == ee.result.Departament_Name).First().ID;
                    dr.EndEdit();
                    //employeeTable.AcceptChanges();
                    employeeAdapter.Update(employeeTable);
                }
            }
            else // если ничего не было выбрано, то добавить новое
            {
                EditWindowEmployee ee = new EditWindowEmployee(new RowViewTemplate(), colD);
                ee.ShowDialog();
                if (ee.DialogResult.HasValue && ee.DialogResult.Value)
                {
                    // создадим новую строку и добавим в таблицу
                    DataRow dr = employeeTable.NewRow();
                    dr["Name"] = ee.result.Employee_Name;
                    dr["Departament_ID"] = colD.Where(d => d.FullName == ee.result.Departament_Name).First().ID;
                    employeeTable.Rows.Add(dr);
                    employeeAdapter.Update(employeeTable);
                }
            }

            // обновить данные
            dataGrid.ItemsSource = UpdateResult();

        }

        /// <summary>
        /// Возвращает актуальные данные, которые могут быть привязаны к DataGrid.
        /// </summary>
        /// <returns></returns>
        private dynamic UpdateResult()
        {
            employeeTable.Clear();
            departamentTable.Clear();

            employeeAdapter.Fill(employeeTable);
            departamentAdapter.Fill(departamentTable);

            return from et in employeeTable.AsEnumerable()
                   join dt in departamentTable.AsEnumerable()
                   on (int)et["Departament_ID"] equals (int)dt["ID"]
                   select new RowViewTemplate
                   {
                       Employee_ID = (int)et["ID"],
                       Employee_Name = (string)et["Name"],
                       Departament_Name = (string)dt["Name"]
                   };
        }

        /// <summary>
        /// Представление данных для DataGrid
        /// </summary>
        public class RowViewTemplate
        {
            public int Employee_ID { get; set; }
            public string Employee_Name { get; set; }
            public string Departament_Name { get; set; }
        }
    }
}
