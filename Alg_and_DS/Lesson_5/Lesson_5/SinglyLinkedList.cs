using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    class SinglyLinkedList
    {
        // простейший односвязный список только для задачи 4.

        public SinglyLinkedList() { }

        Node head;
        Node current;

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
        public void Add(int data)
        {
            if (head == null)
            {
                head = new Node(data);
                current = head;
                num_elements++;
                return;
            }

            Node node = head;
            while (node.next != null) node = node.next;

            node.next = new Node(data);
            num_elements++;
        }

        /// <summary>
        /// Возвращает значение текущего узла
        /// </summary>
        /// <returns></returns>
        public int GetCurrentValue()
        {
            int res = current.data;
            if (current.next != null) current = current.next;
            else Reset();

            return res;
        }

        /// <summary>
        /// Сбрасывает указатель на текущий узел current
        /// </summary>
        public void Reset()
        {
            current = head;
        }
    }
}
