using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    class QueueWithList
    {
        SinglyLinkedListForQue buf;

        public QueueWithList()
        {
            buf = new SinglyLinkedListForQue();
        }

        public void Enqueue(int _d)
        {
            buf.Enqueue(_d);
        }

        public int Dequeue()
        {
            return buf.Dequeue();
        }

        public int Length { get { return buf.num_elements; } }
    }

    /// <summary>
    /// Список из прошлого задания немного переделанный для очереди
    /// </summary>
    class SinglyLinkedListForQue
    {
        // простейший односвязный список только для задачи 4.

        public SinglyLinkedListForQue() { }

        Node head;
        Node last;

        public int num_elements;

        /// <summary>
        /// Представляет узел односвязного списка, который содержит значение типа int и ссылку на следующий узел
        /// </summary>
        class Node
        {
            public int data;
            public Node next;

            public Node(int _data)
            {
                next = null;
                data = _data;
            }
        }

        /// <summary>
        /// Добавляет новый узел
        /// </summary>
        /// <param name="data"></param>
        public void Enqueue(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                last = head;
                num_elements++;
                return;
            }

            last.next = new Node(data);
            last = last.next;
            num_elements++;
        }

        /// <summary>
        /// Возвращает значение текущего узла
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            if(num_elements == 1)
            {
                int res1 = head.data;
                head = null;
                last = null;
                num_elements--;
                return res1;
            }

            if (num_elements == 0) return -1; //очередь пуста, просто вернем минус 1

            int res = head.data;
            num_elements--;

            head = head.next;


            return res;
        }
    }
}
