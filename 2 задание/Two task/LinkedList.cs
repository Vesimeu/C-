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

    public override int Count => count;
    public LinkedList()
    {
        head = null;
        count = 0;
    }


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
            // throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range");
            return;
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
            // throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range");
            return;
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
                // throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range");
                return 0;
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
                // throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range");
                
            }

            Node current = head;
            for (int j = 0; j < i; j++)
            {
                current = current.Next;
            }
            current.Data = value;
        }
    }

    //Дорогу молодым!
    protected override BaseList CloneInternal()
    {
    LinkedList clone = new LinkedList();
    return clone;
    }

  public override void Sort()
    {
    if (head == null || head.Next == null)
    {
        // Список пуст или содержит только один элемент, уже отсортирован
        return;
    }

    Node sorted = null; // Голова отсортированного списка

    Node current = head;
    while (current != null)
    {
        Node next = current.Next; // Запоминаем следующий узел перед изменением ссылок

        if (sorted == null || current.Data <= sorted.Data)
        {
            // Вставляем текущий узел в начало отсортированного списка
            current.Next = sorted;
            sorted = current;
        }
        else
        {
            // Ищем правильное место для вставки текущего узла в отсортированный список
            Node temp = sorted;
            while (temp.Next != null && temp.Next.Data < current.Data)
            {
                temp = temp.Next;
            }
            current.Next = temp.Next;
            temp.Next = current;
        }

        current = next; // Переходим к следующему узлу
    }

    head = sorted; // Обновляем голову списка
    }

}
}