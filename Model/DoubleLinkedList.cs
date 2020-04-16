using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Node
    {
        public Node prev;
        public Node next;
        public object obj;
    }

    public class doubleLinkedList
    {
        private Node head;
        private Node tail;
        private int count;

        public void AddLast(object obj)//插到尾节点
        {
            if (head == null)
            {
                head = new Node();
                head.obj = obj;
                head.next = null;
                tail = head;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.obj = obj;
                tail.next = toAdd;
                toAdd.prev = tail;
                tail = toAdd;
            }

            count++;
        }

        private void AddFront(object obj)//插到头结点
        {
            if (head == null)
            {
                head = new Node();
                head.obj = obj;
                head.next = null;
                tail = head;
            }
            Node toAdd = new Node();
            toAdd.obj = obj;
            toAdd.next = head;
            head.prev = toAdd;
            head = toAdd;
            if (head.next == null)
            {
                tail = head;
            }

            count++;
        }

        public void Merge(doubleLinkedList mergeList)//合并链表
        {
            if (head != null)
            {
                this.tail.next = mergeList.head;
                mergeList.head.prev = this.tail;
                this.tail = mergeList.tail;
                this.count += mergeList.count;
                count--;
            }
        }

        public int GetCount()//该链表长度
        {
            return count;
        }

        public void InsertAtRandomLocation(object obj)//在随机位置插入
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 10);
            int i = 1;
            Node current = head;

            while (current != null && i < x)
            {
                current = current.next;
                i++;
            }

            Node toAdd = new Node();
            toAdd.obj = obj;
            toAdd.next = current;
            toAdd.prev = current.prev;
            current.prev.next = toAdd;
            current.prev = toAdd;

            count++;
        }

        public void DeleteLast()//删除最后一个
        {
            if (tail != null)
            {
                if (tail.prev != null)
                {
                    Node p = tail.prev;
                    p.next = null;
                    p = tail;
                    count--;
                }
                else
                {
                    head = null;
                    tail = null;
                    count = 0;
                }
            }
        }

        public void DeleteFirst()//删除第一个
        {
            if (head != null)
            {
                if (head.next != null)
                {
                    Node p = head.next;
                    p.prev = null;
                    p = head;
                    count--;
                }
                else
                {
                    head = null;
                    tail = null;
                    count = 0;
                }
            }
        }

        public void PrintAllForward()//打印所有节点
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.obj);
                current = current.next;
            }
        }

        public void PrintAllReverse()//反转并打印
        {
            Node current = tail;
            while (current != null)
            {
                Console.WriteLine(current.obj);
                current = current.prev;
            }
        }

        public void DeleteAll()//删除所有
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
