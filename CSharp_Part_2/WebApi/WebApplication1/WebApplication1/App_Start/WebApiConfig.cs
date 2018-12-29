using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // аналогично, как в задании 7 при необхожимоси создаются и заполняются таблицы

            Employee[] Employees;
            Department[] Departments = Support.CreateSet(out Employees);

            SqlConnection connection = new SqlConnection(Support.connectionString);

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
        }
    }
}
