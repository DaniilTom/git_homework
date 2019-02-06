using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10000;

            int[] arr = new int[size];
            int[] arr1 = new int[size];
            int[] arr2 = new int[size];
            int[] arr3 = new int[size];
            int[] arr4 = new int[size];
            int[] arr5 = new int[size];
            int[] arr6 = new int[size];

            Random rnd = new Random();

            for (int i = 0; i < arr.Length; arr[i++] = rnd.Next(0, 10000)) ;

            Array.Copy(arr, arr1, arr.Length);
            Array.Copy(arr, arr2, arr.Length);
            Array.Copy(arr, arr3, arr.Length);
            Array.Copy(arr, arr4, arr.Length);
            Array.Copy(arr, arr5, arr.Length);
            Array.Copy(arr, arr6, arr.Length);

            Console.WriteLine("Размер: " + size + "\n");

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan tres;

            sw.Start();
            Console.WriteLine("Улучшенная пузырьковая: " + BubleSort(arr1) + " op.");
            tres = sw.Elapsed;
            Console.WriteLine("Время: " + tres);

            sw.Restart();
            Console.WriteLine("\nШейкерная: " + ShakeSort(arr2) + " op.");
            tres = sw.Elapsed;
            Console.WriteLine("Время: " + tres);

            sw.Restart();
            Console.WriteLine("\nБыстрая: " + quicksort(arr3, 0, arr3.Length - 1) + " op.");
            tres = sw.Elapsed;
            Console.WriteLine("Время: " + tres);

            int count = 0;
            sw.Restart();
            MergeSort(arr4, ref count);
            Console.WriteLine("\nСплавлением: " + count + " op.");
            tres = sw.Elapsed;
            Console.WriteLine("Время: " + tres);

            sw.Restart();
            Console.WriteLine("\nШелла: " + shellSort(arr5) + " op.");
            tres = sw.Elapsed;
            Console.WriteLine("Время: " + tres);

            sw.Restart();
            Console.WriteLine("\nПирамидальная: " + Pyramid_Sort(arr6) + " op.");
            tres = sw.Elapsed;
            Console.WriteLine("Время: " + tres);


            Console.ReadLine();
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Улучшенная пузырьковая
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int BubleSort(int[] arr)
        {
            int count = 1;

            for (int i = 0; i < arr.Length - 1; i++, count++)
            {
                for (int j = 0; j < arr.Length - 1; j++, count++)
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        //count++;
                    }
            }

            return count;
        }

        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int ShakeSort(int[] arr)
        {
            int count = 0;

            int left = 0;
            int right = arr.Length - 1;

            while (left < right)
            {
                for (int i = left; i < right; i++, count++)
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        //count++;
                    }
                right--;

                for (int j = right; j > left; j--, count++)
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        //count++;
                    }
                left++;
            }

            return count;
        }


        ////////////////////////Быстрая///////////////////////
        static int partition(int[] array, int start, int end, out int count)
        {
            count = 0;
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++, count++)
            {
                if (array[i] < array[end]) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        static int quicksort(int[] array, int start, int end)
        {
            int res;

            if (start >= end)
            {
                return 0;
            }
            int pivot = partition(array, start, end, out res);
            int res1 = quicksort(array, start, pivot - 1);
            int res2 = quicksort(array, pivot + 1, end);

            return res + res1 + res2;
        }

        /// <summary>
        /// Сортировка сплавлением
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static Int32[] MergeSort(Int32[] array, ref int count)
        {
            if (array.Length == 1)
            {
                return array;
            }

            Int32 middle = array.Length / 2;

            Int32[] arr = Merge(MergeSort(array.Take(middle).ToArray(), ref count), MergeSort(array.Skip(middle).ToArray(), ref count), ref count);
            return arr;
        }

        static Int32[] Merge(Int32[] arr1, Int32[] arr2, ref int count)
        {
            Int32 ptr1 = 0, ptr2 = 0;
            Int32[] merged = new Int32[arr1.Length + arr2.Length];

            for (Int32 i = 0; i < merged.Length; ++i, count++)
            {
                if (ptr1 < arr1.Length && ptr2 < arr2.Length)
                {
                    merged[i] = arr1[ptr1] > arr2[ptr2] ? arr2[ptr2++] : arr1[ptr1++];
                }
                else
                {
                    merged[i] = ptr2 < arr2.Length ? arr2[ptr2++] : arr1[ptr1++];
                }
            }

            return merged;
        }

        /// <summary>
        /// Сортировка Шелла
        /// </summary>
        /// <param name="vector"></param>
        static int shellSort(int[] vector)
        {
            int count = 0;
            int step = vector.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < vector.Length; i++)
                {
                    int value = vector[i];
                    for (j = i - step; (j >= 0) && (vector[j] > value); j -= step, count++)
                        vector[j + step] = vector[j];
                    vector[j + step] = value;
                }
                step /= 2;
            }

            return count;
        }

        
        /// <summary>
        /// Пирамилальная
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="len"></param>
        static int Pyramid_Sort(Int32[] arr)
        {
            Int32 len = arr.Length - 1;
            Int32 count = 0;
            //step 1: building the pyramid
            for (Int32 i = len / 2 - 1; i >= 0; --i, count++)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            //step 2: sorting
            Int32 buf;
            for (Int32 k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                Int32 i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }

            return count;
        }
        static Int32 add2pyramid(Int32[] arr, Int32 i, Int32 N)
        {
            Int32 imax;
            Int32 buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }
    }
}
