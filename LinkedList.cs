using System;

namespace DataStructures{

    public interface INode<T>{

    }
    
    public class Node<T>{
        public T obj;
        public Node<T> NextNode;

        public Node(T _obj){    
            this.obj = _obj;
            this.NextNode = null;
        }

    }

    public interface ILinkedList<T>{
        void AddLast(T _obj);
        void AddFront(T _obj);
        void AddAfter(T _obj, Node<T> _n);
        void Remove(T _obj);
        //Node<T> Find(T _obj);
        Node<T> GetLast();
    }
    public class LinkedList<T> : ILinkedList<T>{
        public Node<T> head;

        public LinkedList(T _obj){
            Node<T> n = new Node<T>(_obj);
            this.head = n;
        }

        public LinkedList(){
            this.head.obj = default(T);
            this.head.NextNode = null;
        }

        public void AddLast(T _obj){
            Node<T> n = new Node<T>(_obj); 
            if(head == null){
                this.head = n;
                return;
            }
            
            GetLast().NextNode = n;
        }

        public void AddFront(T _obj){
            Node<T> n = new Node<T>(_obj);
            n.NextNode = this.head;
            this.head = n;
        }

        public void AddAfter(T _obj, Node<T> _n){
            Node<T> n = new Node<T>(_obj);
            n.NextNode = _n.NextNode;
            _n.NextNode = n;
        }

        public void Remove(T _obj){
            if(this.head.obj.Equals(_obj)){
                this.head = this.head.NextNode;
                return;
            }
            Node<T> previousNode = head;
            Node<T> currentNode = previousNode.NextNode;
            while(!currentNode.obj.Equals(_obj)){
                previousNode = currentNode;
                currentNode = previousNode.NextNode;
            }
            previousNode.NextNode = currentNode.NextNode;

        }

        public Node<T> GetLast(){
            Node<T> n = head;
            while(n.NextNode != null){
                n = n.NextNode;
            }
            return n;
        }


    }
}