using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
    class Program
    {
        /*
         * 
         * Томашевич
         * 
         * Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.
         * 
         * */

        static void Main(string[] args)
        {
            Console.Write("Первая последовательность: ");
            string str1 = Console.ReadLine();

            Console.Write("Вторая последовательность: ");
            string str2 = Console.ReadLine();

            int[][] matrix = new int[str1.Length][];
            for (int i = 0; i < str1.Length; i++) matrix[i] = new int[str2.Length];

            string res = "";

            for (int i = 0, j = 0; i < str1.Length && j < str2.Length; i++, j++)
            {
                int jj = j, ii = i;
                bool flag1 = false, flag2 = false;

                
                for(; jj < str2.Length; jj++)
                {
                    if (str1[i] == str2[jj])
                    {
                        flag1 = true;
                        break;
                    }
                }
                for (; ii < str1.Length; ii++)
                {
                    if (str2[j] == str1[ii])
                    {
                        flag2 = true;
                        break;
                    }
                }

                if (flag1 == false && flag2 == false) {continue; }

                else if (flag1 == true && flag2 == true)
                {
                    if (ii - i >= jj - j)
                    {
                        j = jj;
                        res += str2[j];
                    }
                    else
                    {
                        i = ii;
                        res += str1[i];
                    }
                }
                else if (flag2 == true)
                {
                    i = ii;
                    res += str2[j];
                }
                else if (flag1 == true)
                {
                    j = jj;
                    res += str1[i];
                }

                matrix[i][j] = res.Length;
            }

            Console.WriteLine("LCS: " + res);
            foreach(int[] i in matrix)
            {
                for (int j = 0; j < str2.Length; j++) Console.Write($"{i[j], 5}");
                Console.WriteLine();
            }
            Console.ReadLine();

        }
    }
}
