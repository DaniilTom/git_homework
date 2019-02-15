using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class Stack1
    {
        int size = 32; // стэк будет иметь фиксированный размер
        int[] buf;
        int pos;

        public Stack1()
        {
            buf = new int[size];
            pos = -1; // показывает, что стэк пуст
        }

        /// <summary>
        /// Положить в стэк
        /// </summary>
        /// <param name="a"></param>
        public int push(int a)
        {
            if (pos < size)
            {
                pos++;
                buf[pos] = a;
                return 0; // показывает, что операция выполнена успешно
            }
            else return -1; // показывает, что стэк полон
        }

        /// <summary>
        /// Вынуть из стэка
        /// </summary>
        /// <returns></returns>
        public int pop()
        {
            if (pos >= 0) return buf[pos--];
            else return -1; // показывает, что стэк пуст
        }

        /// <summary>
        /// Возвращает текущее количество элементов
        /// </summary>
        public int Size { get { return pos+1; } } 
    }
}
