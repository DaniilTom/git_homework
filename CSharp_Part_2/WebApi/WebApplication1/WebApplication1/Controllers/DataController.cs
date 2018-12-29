using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DataController : ApiController
    {
        List<Employee> empList = new List<Employee>()
        {
            new Employee("Иванов Иван"), new Employee("Петров Петр"), new Employee("Попов Сергей")
        };

        public IEnumerable<Employee> GetEmployees()
        {
            return empList;
        }

        // с аттрибутом Route можно вызвать метод "напрямую"
        [Route("get_one/{i}")]
        public Employee GetOne(int i)
        {
            if (i > 2) throw new IndexOutOfRangeException("В тестовой коллекции всего 3 элемента.");
            return empList[i];
        }

        [Route("get_employees")]
        public DataTable GetAllEmployees()
        {
            SqlConnection con = new SqlConnection(Support.connectionString);
            con.Open();

            SqlCommand com = new SqlCommand("select * from Employee;",con);
            SqlDataAdapter sqlData = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            dt.TableName = "TableName"; // без имени нельзя сериализовать
            sqlData.Fill(dt);


            // тест десериализации (сериализуешь DataTable, десериализуешь DataSet)
            // десериализовать в таблицу не получилось
            MemoryStream m = new MemoryStream();
            dt.WriteXml(m);
            DataSet d = new DataSet();
            m.Position = 0;
            d.ReadXml(m);

            m.Position = 0;
            StreamReader s = new StreamReader(m);
            d.ReadXml(s);

            
            //m.Position = 0;
            //StreamReader s = new StreamReader(m);
            //DataTable t = new DataTable("TableName");
            //t.ReadXml(s);

            return dt;
        }

        [Route("get_departaments")]
        public DataTable GetAllDepartaments()
        {
            using (SqlConnection con = new SqlConnection(Support.connectionString))
            {
                con.Open();

                SqlCommand com = new SqlCommand("select * from Departament;", con);
                SqlDataAdapter sqlData = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                dt.TableName = "TableName"; // без имени нельзя сериализовать
                sqlData.Fill(dt);


                // тест десериализации (сериализуешь DataTable, десериализуешь DataSet)
                // десериализовать в таблицу не получилось
                MemoryStream m = new MemoryStream();
                dt.WriteXml(m);
                DataSet d = new DataSet();
                m.Position = 0;
                d.ReadXml(m);

                m.Position = 0;
                StreamReader s = new StreamReader(m);
                d.ReadXml(s);

                //m.Position = 0;
                //StreamReader s = new StreamReader(m);
                //DataTable t = new DataTable("TableName");
                //t.ReadXml(s);

                return dt;
            }
        }
    }
}
