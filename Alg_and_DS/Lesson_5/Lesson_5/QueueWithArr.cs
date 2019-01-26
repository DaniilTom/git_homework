using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    /// <summary>
    /// Очередь фиксированного размера 5 элементов, реализованная через массив
    /// </summary>
    class QueueWithArr
    {
        /// <summary>
        /// Кольцевой массив
        /// </summary>
        int[] buf;

        int size = 5;
        int current_size = 0;
        int first, last;

        public QueueWithArr()
        {
            first = -1; //пустая
            last = -1;
            buf = new int[size];
        }

        public void Enqueue(int _data)
        {
            if (current_size == 0)
            {
                buf[0] = _data;
                last = 0;
                first = 0;
                current_size++;
                return;
            }

            last++; // сразу увеличим last на один и посмотрим на сложившуюся ситуацию

            if (last == size) //если индекс last выходит за границы массива
            {
                if (first == 0) { last--; return; } //а индекс first указывает на начало массива => очередь заполнена, ничего не делать
                else { last = 0; buf[last] = _data; }
            }
            else if (last != first) buf[last] = _data;
            else { last--; return; } // очередь заполнена, ничего не делать

            current_size++;
        }

        public int Dequeue()
        {
            if (current_size == 0) return -1;

            int res = buf[first];

            first++;
            current_size--;

            if (current_size == 0) first = last = 0;

            if (first == size)
            {
                first = 0;
            }

            return res;
        }
    }
}
