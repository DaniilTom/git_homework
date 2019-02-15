using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class Program
    {
        /*
         * Томашевич
         * 
         * 1. Реализовать перевод из десятичной в двоичную систему счисления с использованием стека.
         * 4. *Создать функцию, копирующую односвязный список (то есть создающую в памяти копию односвязного списка без
         *      удаления первого списка).
         * 6. Реализовать очередь:
         *      1. С использованием массива.
         *      2. *С использованием односвязного списка.
         * 
         * */

        static void Main(string[] args)
        {
            /********** Задача 1. *********************************/

            Console.WriteLine("1. Из десятичной в двоичную: " + BinaryConvertWithStack(32123));

            //Console.WriteLine("2. Скобки норм? " + IsBraketsCorrect(str, 0, str.Length-1));

            /************ Задача 4. ****************************/

            SinglyLinkedList l = new SinglyLinkedList();

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
                l.Add(rnd.Next(0, 20));

            SinglyLinkedList copy = CopySinglyLinkedList(l);

            /***************** Задача 6.1. ***************************/

            QueueWithArr q = new QueueWithArr();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);    // в режиме отладки отслеживал значения
                            // все было норм
            q.Dequeue();

            q.Enqueue(7);
            q.Enqueue(8);
            q.Enqueue(9);
            q.Enqueue(10);
            q.Dequeue();
            q.Dequeue();
            q.Dequeue();
            q.Dequeue();
            int res = q.Dequeue();
            q.Dequeue();

            /********************* Задача 6.2. ****************/

            QueueWithList ql = new QueueWithList();

            ql.Enqueue(1);
            ql.Enqueue(2);
            ql.Enqueue(3);
            ql.Enqueue(4);
            ql.Enqueue(5);
            ql.Enqueue(6);    // в режиме отладки отслеживал значения
                            // все было норм
            ql.Dequeue();

            ql.Enqueue(7);
            ql.Dequeue();
            ql.Dequeue();
            ql.Dequeue();
            ql.Dequeue();
            ql.Dequeue();
            ql.Dequeue();
            ql.Dequeue();
            ql.Dequeue();


            /***********************************************************/
            Console.ReadLine();
        }

        static string BinaryConvertWithStack(int a)
        {
            string result = "";

            Stack1 st = new Stack1();

            while(a > 0)
            {
                if (a % 2 == 0) st.push(0);
                else st.push(1);
                a /= 2;
            }

            int i = 0;
            for(int res = st.pop(); res >= 0; res = st.pop())
            {
                i++;
                if (i % 4 == 0) result += "_";
                result += res;
            }

            return result;
        }

        /// <summary>
        /// Копираует односвязный список
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        static SinglyLinkedList CopySinglyLinkedList (SinglyLinkedList list)
        {
            SinglyLinkedList copy = new SinglyLinkedList();
            list.Reset();

            for (int i = 0; i < list.num_elements; i++)
                copy.Add(list.GetCurrentValue());

            return copy;
        }
    }

}
