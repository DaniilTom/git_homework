using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Adding(5,6);
        }

        public static int Adding(int a, int b)
        {
            return a + b;
        }

        public static int Subtracting(int a, int b)
        {
            return a - b;
        }
    }
}
