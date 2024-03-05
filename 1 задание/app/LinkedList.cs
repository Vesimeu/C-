using System;


namespace MyLists{
public class LinkedList : BaseList
{
    private class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private int count;

    public LinkedList()
    {
        head = null;
        count = 0;
    }

    public override int Count => count;

    public override void Add(int item)
    {
        if (head == null)
        {
            head = new Node(item);
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(item);
        }
        count++;
    }

    public override void Insert(int pos, int item)
    {
        if (pos < 0 || pos > count)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range");
        }

        Node newNode = new Node(item);

        if (pos == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < pos - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        count++;
    }

    public override void Delete(int pos)
    {
        if (pos < 0 || pos >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range");
        }

        if (pos == 0)
        {
            head = head.Next;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < pos - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
        count--;
    }

    public override void Clear()
    {
        head = null;
        count = 0;
    }

    public override int this[int i]
    {
        get
        {
            if (i < 0 || i >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range");
            }

            Node current = head;
            for (int j = 0; j < i; j++)
            {
                current = current.Next;
            }
            return current.Data;
        }
        set
        {
            if (i < 0 || i >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range");
            }

            Node current = head;
            for (int j = 0; j < i; j++)
            {
                current = current.Next;
            }
            current.Data = value;
        }
    }

    public override void Print()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public override void Assign(BaseList source)
    {
        LinkedList linkedListSource = source as LinkedList;
        if (linkedListSource == null)
        {
            throw new ArgumentException("Source list is not of type LinkedList");
        }

        head = null;
        count = 0;

        Node currentSource = linkedListSource.head;
        while (currentSource != null)
        {
            Add(currentSource.Data);
            currentSource = currentSource.Next;
        }
    }

    public override void AssignTo(BaseList dest)
    {
        LinkedList linkedListDest = dest as LinkedList;
        if (linkedListDest == null)
        {
            throw new ArgumentException("Destination list is not of type LinkedList");
        }

        linkedListDest.head = null;
        linkedListDest.count = 0;

        Node current = head;
        while (current != null)
        {
            linkedListDest.Add(current.Data);
            current = current.Next;
        }
    }

    public override BaseList Clone()
    {
        LinkedList clone = new LinkedList();
        clone.Assign(this);
        return clone;
    }

}
}