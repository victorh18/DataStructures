using System;
using DataStructures;

namespace DataStructures
{
    public interface IStack{
        void Push(object obj);
        object Pop();
        object Peek();
        bool Contains(object obj);
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
