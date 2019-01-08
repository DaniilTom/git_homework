using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithList
{
    class Program
    {

        /*
         * 
         * Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
         *      для целых чисел;
         *    * для обобщенной коллекции;
         *   ** используя Linq.
         */

        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            Random rnd = new Random();
            for (int i = 0; i < 20; i++) list.Add(rnd.Next(1, 21));

            Console.WriteLine("\nДля коллекции int: ");
            Dictionary<int, int> d1 = HowFrequently_ForIntCollection(list);
            foreach (var k in d1) Console.WriteLine($"{k.Key, 5} {k.Value, 5}");

            Console.WriteLine("\nДля обобщенной коллекции: ");
            Dictionary<int, int> d2 = HowFrequently_ForGenerciCollection<int>(list);
            foreach (var k in d2) Console.WriteLine($"{k.Key,5} {k.Value,5}");

            Console.WriteLine("\nС помощью LINQ: ");
            foreach(var k in HowFrequently_ForGeneric_With_LINQ(list)) Console.WriteLine($"{k.Key,5} {k.Value,5}");


            Console.ReadLine();
        }

        static Dictionary<int, int> HowFrequently_ForIntCollection(List<int> list)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();

            foreach(int num in list)
            {
                if (d.ContainsKey(num)) d[num]++;
                else d.Add(num, 1);
            }

            return d;
        }

        static Dictionary<T, int> HowFrequently_ForGenerciCollection<T>(List<T> list)
        {
            Dictionary<T, int> d = new Dictionary<T, int>();

            foreach (T smth in list)
            {
                if (d.ContainsKey(smth)) d[smth]++;
                else d.Add(smth, 1);
            }

            return d;
        }

        static IEnumerable<KeyValuePair<T, int>> HowFrequently_ForGeneric_With_LINQ<T>(List<T> list)
        {
            var query = from l in list
                        group l by l into gr
                        select new KeyValuePair<T, int>(gr.Key, gr.Count());

            return query;
        }
    }
}
