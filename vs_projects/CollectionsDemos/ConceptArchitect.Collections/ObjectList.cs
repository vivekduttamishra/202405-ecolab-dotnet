using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections
{
    public class ObjectList
    {
        class Node
        {
            public object Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node first; //null

        public void Add(object value)
        {
            var newNode = new Node()
            {
                Value = value,
                Next = null  //this node will be added at the end
            };

            if (first == null)
            {
                first = newNode;
                return;
            }

            //add after the last node.
            var node = first;
            while (node.Next != null)
            {
                node = node.Next;
            }

            //now node is the last node
            var last = node;
            newNode.Previous = last;
            last.Next = newNode;

        }

        public int Count
        {
            get
            {
                var c = 0;
                var n = first;
                while(n!= null)
                {
                    c++;
                    n=n.Next;
                }

                return c;
            }
        }
          
    
        public object Get(int index)
        {
            if(index<0 || index>=Count)
                throw new IndexOutOfRangeException();
            
            var n = first;
            for(var i=0;i<index;i++)
            {   
                n=n.Next;
            }

            return n.Value;
        }

        public void Set(int index, object value)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            var n = first;
            for (var i = 0; i < index; i++)
            {
                n = n.Next;
            }

            n.Value = value;
        }

        public object Remove(int index)
        {
            if( index<0 || index>=Count)
                throw new IndexOutOfRangeException();
            var n = first;
            for(var i=0; i<index;i++)
                n= n.Next;

            //we have to delete 'n'
            //lets fix the remaing code
            var previous= n.Previous;
            var next = n.Next;
            if (n == first)
                first = next;
            else
                previous.Next = next;

            if(next!=null)
                next.Previous = previous;

            return n.Value;
        }


        public void Insert(int index, object value)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            var n = first;
            for (var i = 0; i < index; i++)
            {
                n = n.Next;
            }

           
            var previous = n.Previous;
            var next = n;
            var newNode= new Node() { Value=value, Next=next, Previous=previous };

            if (previous == null)
                first = newNode;
            else
                previous.Next= newNode;

            if (next != null)
                next.Previous = newNode;

        }


        public override string ToString()
        {
            if (Count == 0)
                return "LinkedList(empty)";
            
            var sb = new StringBuilder();
            sb.Append("LinkedList{\t");
            for (var n = first; n != null; n = n.Next)
                sb.Append($"{n.Value}\t");
            sb.Append("}");

            return sb.ToString();
        }

       

    }
}
