using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Lesson_8
{
    public partial class Program
    {
        /*
         * Томашевич
         * 
         * 5. **Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
         * */

        static void Task5()
        {
            List<Student> list = new List<Student>();

            StreamReader sr = new StreamReader("res/students_4.csv");

            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }

            //сериализация
            XmlSerializer serializer = new XmlSerializer(list.GetType(), new XmlRootAttribute("Students"));
            StreamWriter writer = new StreamWriter(@"xmlStudents.xml");
            serializer.Serialize(writer.BaseStream, list);
            writer.Close();

            //десериализация
            FileStream fs = new FileStream("xmlStudents.xml", FileMode.Open);
            List<Student> newList = (List<Student>)serializer.Deserialize(fs);

            Console.WriteLine("Результат десериализации: ");
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(newList[i].ToString());
            }
        }

        [Serializable]
        public class Student
        {
            public string lastName;
            public string firstName;
            public string university;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;
            public int age;

            public Student(string firstName, string lastName, string university,
            string faculty, string department, int age, int course, int group, string city)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.university = university;
                this.faculty = faculty;
                this.department = department;
                this.course = course;
                this.age = age;
                this.group = group;
                this.city = city;
            }

            public Student() // для сериализации
            { }

            public override string ToString()
            {
                return lastName + " " + firstName + " " + age + " " + university;
                //return base.ToString();
            }
        }
    }
}