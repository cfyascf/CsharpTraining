using System.Collections;
using System.Dynamic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Project;

public class MyList<T> : ICollection<T>
{
    MyNode<T> Head { get; set; }
    int Size { get; set; }
    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(T item)
    {
        if (Head == null)
        {
            MyNode<T> n = new MyNode<T>();
            n.GetContent()[0] = item;
            n.Next = null;
            n.Size = 1;

            Head = n;
            Size = 1;

            return;
        }

        var aux = Head;
        while (aux.Next != null)
        {
            aux = aux.Next;
        }

        if (aux.Size == 3)
        {
            MyNode<T> n = new MyNode<T>();
            n.GetContent()[0] = item;
            n.Size = 1;

            aux.Next = n;
            n.Next = null;
            Size++;

            return;
        }

        aux.Content[aux.Size] = item;
        aux.Size++;
        Size++;

        return;
    }

    public void Print() {
        MyNode<T> aux = Head;
        while(aux != null) {
            for(int i = 0; i < aux.Size; i++) {
                Console.WriteLine("{0}", aux.Content[i]);
            }

            aux = aux.Next;
        }
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        MyIterable<T> myIterable = new MyIterable<T>(Head);
        return myIterable;
    }

    public bool Remove(T item)
    {
        MyNode<T> aux = Head;

        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public class MyNode<U>
    {
        public U[] Content = new U[3];
        public int Size { get; set; }
        public MyNode<U> Next { get; set; }

        public U[] GetContent()
        {
            return Content;
        }
    }

    public class MyIterable<V> : IEnumerator<V>
    {
        MyNode<V> Head { get; set; }
        MyNode<V> CurrentNode { get; set; }
        int CurrentArrayIndex { get; set; }
        bool InList { get; set; }

        public MyIterable(MyNode<V> head)
        {
            Head = head;
            CurrentArrayIndex = 0;
            CurrentNode = null;
            InList = false;
        }

        public V GetCurrent() 
        {
            return CurrentNode.Content[CurrentArrayIndex];
        }

        public V Current => GetCurrent();
        object IEnumerator.Current => GetCurrent();


        public void Dispose() { }

        public bool MoveNext()
        {
            if(!InList) 
            {
                InList = true;
                CurrentNode = Head;

                return true;
            }

            if(CurrentArrayIndex < 2) 
            {
                CurrentArrayIndex++;
                if(CurrentArrayIndex > CurrentNode.Size - 1) return false;

                return true;
            }

            CurrentNode = CurrentNode.Next;
            if(CurrentNode == null) return false;

            CurrentArrayIndex = 0;
            return true;
        }

        public void Reset()
        {
            CurrentNode = null;
            CurrentArrayIndex = 0;
            InList = false;
        }
    }
}