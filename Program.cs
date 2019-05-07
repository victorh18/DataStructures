using System;
using DataStructures;

namespace DataStructures
{
    class Program
    {
        public static void Main(){
            TestingLists();
        }

        public static void Testing(){
            Queue q = new Queue(5);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);

            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            q.Enqueue(6);
            Console.WriteLine(q.Dequeue());
            q.Enqueue(8);
            Console.WriteLine(q.Dequeue());
            q.Enqueue(7);
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            //Console.WriteLine(q.Dequeue());
        }

        public static void TestingReallocation(){
            Queue q = new Queue(5);
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);

            Queue q2 = new Queue(q, 10);
            while(q2.Peek() != null){
                Console.WriteLine(q2.Dequeue());
            }
        }

        public static void TestingStacks(){
            Stack s = new Stack(5);
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);

            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            s.Push(6);
            s.Push(7);
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            s.Push(8);
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
        }
    
        public static void TestingLists(){
            LinkedList<int> linkedList = new LinkedList<int>(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);
            
            PrintingLists(linkedList.head);
            PrintingLists(linkedList.head);
        }

        public static void PrintingLists(Node<int> _n){
            Console.WriteLine(_n.obj);
            if(_n.NextNode != null){
                PrintingLists(_n.NextNode);
            }
        }
    }

    public interface IQueue{
        void Enqueue(object obj);
        object Dequeue();
        object Peek();
        bool Contains(object obj);

    }

    public interface IStack{
        void Push(object obj);
        object Pop();
        object Peek();
        bool Contains(object obj);
    }

    public class Queue : IQueue{
        private object[] items;
        private int length;
        private int head;
        private int tail {get {
            return (head + length) % capacity;
        }}
        public int capacity;

        public Queue(int _size){
            capacity = _size;
            items = new object[capacity];
            length = 0;
        }

        public Queue(Queue q, int _size = 0){
            //Creates an even larger Queue 
            if(_size == 0){
                _size++;
            }
            _size += q.capacity;
            capacity = _size;
            items = new object[capacity];
            length = 0;
            while(q.Peek() != null){
                Enqueue(q.Dequeue());
            }

        }

        public void Enqueue(object obj){
            if(capacity == length){
                throw new Exception("Queue Overflow");
            }
            items[tail] = obj;
            length++;
        }

        public object Dequeue(){
            if (capacity == 0){
                throw new Exception("Queue is empty");
            }
            object obj = items[head];
            items[head] = null;
            head = ++head % capacity; 
            length--;
            return obj;

        }
        public object Peek(){
            return items[head];
        }

        public bool Contains(object obj){
            return true;
        }

    }

    public class Stack : IStack {
        private object[] items;
        private int top;
        private int bottom;
        public int capacity;

        public Stack(int _capacity){
            this.capacity = _capacity;
            items = new object[this.capacity];

        }

        public void Push(object obj){
            if(top == (capacity)){
                throw new Exception("Stack is full");
            }
        items[top++] = obj;

        }
        public object Pop(){
            if(top == 0){
                throw new Exception("Stack is empty");

            }
            object r =items[--top]; 
            items[top] = null;
            return r;
        }

        public object Peek(){
            int i = (top == bottom) ? top : top - 1;
            return items[(i)];
        }

        public bool Contains(object obj){
            return true;
        }

    }
}
