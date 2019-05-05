using System;

namespace DataStructures
{
    class Program
    {
        public static void Main(){
            TestingReallocation();
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
    }

    public interface IQueue{
        void Enqueue(object obj);
        object Dequeue();
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
}
