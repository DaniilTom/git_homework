using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
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
                int res1 = last.data;
                head = null;
                last = null;
                num_elements--;
                return res1;
            }

            if (num_elements == 0) return -1; //очередь пуста, просто вернем минус 1

            int res = last.data;
            num_elements--;

            if (num_elements == 1)
            {
                last = head;
                head.next = last; //когда остается один элемент - он первый, он же и последний
                return res;
            }

            // ищем предпоследний узел, чтобы обновить ссылку last;
            Node node_pre_last = head;
            Node node_last = head.next;
            

            while (node_last.next != null)
            {
                node_pre_last = node_last;
                node_last = node_last.next;
            }

            last = node_pre_last;
            last.next = null;


            return res;
        }
    }
}
