using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Treads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");

            int num = Int32.Parse(Console.ReadLine());

            Thread thrd1 = new Thread(Factorial);
            Thread thrd2 = new Thread(Sum);

            thrd1.Start(num);
            thrd2.Start(num);

            Console.ReadLine();
        }

        private static void Factorial(object n)
        {
            ulong res = 1;
            int num = (int)n;

            if (num > 0)
                for (uint i = 1; i <= num; i++)
                {
                    res = res * i;
                }
            else if (num == 0) res = 1;

            Console.WriteLine($"Факториал = {res}");
        }

        private static void Sum(object n)
        {
            int num = (int)n;
            long res = 0;

            if (num >= 0)
                for (int i = 0; i <= num; i++)
                    res += i;

            Console.WriteLine($"Сумма = {res}");
        }
    }
}
