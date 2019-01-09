using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace WpfClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DataTable departamentTable;
        DataTable employeeTable;
        WebClient webClient;

        public MainWindow()
        {
            InitializeComponent();
            webClient = new WebClient() { Encoding = Encoding.UTF8 };

            departamentTable = new DataTable();
            employeeTable = new DataTable();
        }

        /// <summary>
        /// Метод обновляет данные привязки отображения Employee и Departament
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_UpdateData(object sender, RoutedEventArgs e)
        {
            var data = UpdateResult();
            dataGrid.ItemsSource = data;
            departamentGrid.ItemsSource = departamentTable.DefaultView;
            employeeGrid.ItemsSource = employeeTable.DefaultView;
            
        }

        /// <summary>
        /// Возвращает актуальные данные, которые могут быть привязаны к DataGrid.
        /// </summary>
        /// <returns></returns>
        private dynamic UpdateResult()
        {
            employeeTable.Clear();
            departamentTable.Clear();

            webClient.Headers.Add("Accept", "application/xml");
            XDocument xmlEmp = XDocument.Parse(webClient.DownloadString(@"http://localhost:49479/get_employees"));

            webClient.Headers.Add("Accept", "application/xml");
            XDocument xmlDep = XDocument.Parse(webClient.DownloadString(@"http://localhost:49479/get_departaments"));

            DataSet dsEmp = new DataSet(), dsDep = new DataSet();
            dsEmp.ReadXml(xmlEmp.CreateReader());
            dsDep.ReadXml(xmlDep.CreateReader());

            employeeTable = dsEmp.Tables[0];
            departamentTable = dsDep.Tables[0];

            return from et in employeeTable.AsEnumerable()
                   join dt in departamentTable.AsEnumerable()
                   on (int)et["Departament_ID"] equals (int)dt["ID"]
                   select new RowViewTemplate
                   {
                       Employee_ID = (int)et["ID"],
                       Employee_Name = (string)et["Name"],
                       Departament_Name = (string)dt["Name"],
                       Departament_ID = (int)dt["ID"]
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
            public int Departament_ID { get; set; }
        }
    }
}
