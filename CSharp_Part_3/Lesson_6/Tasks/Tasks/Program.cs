using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr1 = new int[100, 100];
            int[,] arr2 = new int[100, 100];

            int[,] result = new int[10, 10];

            Random rnd = new Random();

            for(int i = 0; i < 100; i++)
                for(int j = 0; j < 100; j++)
                {
                    arr1[i, j] = rnd.Next(0, 11);
                    arr2[i, j] = rnd.Next(0, 11);
                }

            ParallelLoopResult state = 
                Parallel.For(0, 10,
                (i) =>
                {
                    for(int j = 0; j < 10; j++)
                    {
                        for(int l = 0; l < 100; l++)
                        {
                            result[i, j] += arr1[i, l] * arr2[l, j];
                        }
                    }
                });

            Console.WriteLine("Completed? " + state.IsCompleted);
            Console.ReadLine();

        }
    }
}
