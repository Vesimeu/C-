using System;
public class DynamicList
{
    private int[] buffer; // Массив для хранения элементов списка
    private int count; // Количество элементов в списке

    public DynamicList()
    {
        buffer = new int[4]; // Начальный размер буфера
        count = 0;
    }

    // Метод для добавления элемента в список
    public void Add(int item)
    {
        if (count == buffer.Length)
        {
            Resize(buffer.Length * 2); // Увеличиваем размер буфера, если необходимо
        }
        buffer[count++] = item;
    }

    // Метод для вставки элемента на указанную позицию
    public void Insert(int item, int pos)
    {
        if (pos > count || pos < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Позиция вне диапазона списка");
        }

        if (count == buffer.Length)
        {
            Resize(buffer.Length * 2);
        }

        // Сдвигаем элементы на одну позицию вправо, начиная с конца списка
        for (int i = count; i > pos; i--)
        {
            buffer[i] = buffer[i - 1];
        }

        buffer[pos] = item;
        count++;
    }

    // Метод для удаления элемента с указанной позиции
    public void Delete(int pos)
    {
        if (pos >= count || pos < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Позиция вне диапазона списка");
        }

        for (int i = pos; i < count - 1; i++)
        {
            buffer[i] = buffer[i + 1];
        }
        count--;
    }

    // Метод для очистки списка
    public void Clear()
    {
        count = 0;
    }

    // Свойство для получения количества элементов в списке
    public int Count
    {
        get { return count; }
    }

    // Индексатор для доступа к элементам списка
    public int this[int i]
    {
        get
        {
            if (i >= count || i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Индекс вне диапазона списка");
            }
            return buffer[i];
        }
        set
        {
            if (i >= count || i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Индекс вне диапазона списка");
            }
            buffer[i] = value;
        }
    }

    // Метод для изменения размера буфера
    private void Resize(int newSize)
    {
        int[] newBuffer = new int[newSize];
        for (int i = 0; i < count; i++)
        {
            newBuffer[i] = buffer[i];
        }
        buffer = newBuffer;
    }

    // Метод для вывода элементов списка
    public void Cout()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(buffer[i] + " ");
        }
        Console.WriteLine();
    }


}
    public class LinkedList
{
    private class Node
    {
        public int Data; // Данные, хранящиеся в узле
        public Node Next; // Ссылка на следующий узел в списке

        public Node(int data)
        {
            Data = data;
            Next = null; // По умолчанию следующий узел не установлен
        }
    }

    private Node head; // Голова списка, первый узел
    private int count; // Количество узлов в списке

    public LinkedList()
    {
        head = null; // Инициализация пустого списка
        count = 0;
    }

    public void Add(int data)
    {
        if (head == null)
        {
            head = new Node(data); // Создание головы списка, если она отсутствует
        }
        else
        {
            Node current = head;
            while (current.Next != null) // Перемещение к последнему узлу
            {
                current = current.Next;
            }
            current.Next = new Node(data); // Добавление нового узла в конец списка
        }
        count++;
    }

    public void Insert(int data, int pos)
    {
        if (pos < 0 || pos > count) // Проверка корректности позиции
        {
            throw new ArgumentOutOfRangeException("pos", "Позиция вне допустимого диапазона");
        }

        Node newNode = new Node(data);

        if (pos == 0) // Вставка в начало списка
        {
            newNode.Next = head;
            head = newNode;
        }
        else // Вставка в середину или конец списка
        {
            Node current = head;
            for (int i = 0; i < pos - 1; i++) // Перемещение к узлу, предшествующему позиции вставки
            {
                current = current.Next;
            }

            newNode.Next = current.Next; // Вставляем новый узел между current и current.Next
            current.Next = newNode;
        }
        count++;
    }

    public void Delete(int pos)
    {
        if (pos < 0 || pos >= count) // Проверка корректности позиции
        {
            throw new ArgumentOutOfRangeException("pos", "Позиция вне допустимого диапазона");
        }

        if (pos == 0) // Удаление головы списка
        {
            head = head.Next;
        }
        else // Удаление узла из середины или конца списка
        {
            Node current = head;
            for (int i = 0; i < pos - 1; i++) // Перемещение к узлу, предшествующему узлу для удаления
            {
                current = current.Next;
            }

            current.Next = current.Next.Next; // Пропускаем узел, который нужно удалить
        }
        count--;
    }

    public void Clear()
    {
        head = null; // Очистка списка путем удаления ссылки на голову списка
        count = 0;
    }

    public int Count
    {
        get { return count; } // Возвращение текущего количества узлов в списке
    }

    public void Cout()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " "); // Вывод данных каждого узла
            current = current.Next; // Перемещение к следующему узлу
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Тестирование DynamicList
        Console.WriteLine("Тестирование DynamicList:");
        DynamicList dynamicList = new DynamicList();
        dynamicList.Add(1);
        dynamicList.Add(2);
        dynamicList.Add(3);
        dynamicList.Insert(4, 1); // Вставляем 4 на позицию 1
        dynamicList.Cout(); // Должно вывести: 1 4 2 3

        dynamicList.Delete(2); // Удаляем элемент на позиции 2
        dynamicList.Cout(); // Должно вывести: 1 4 3

        dynamicList.Clear();
        dynamicList.Cout(); // Должно вывести пустую строку

        // Тестирование LinkedList
        Console.WriteLine("\nТестирование LinkedList:");
        LinkedList linkedList = new LinkedList();
        linkedList.Add(5);
        linkedList.Add(6);
        linkedList.Add(7);
        linkedList.Insert(8, 2); // Вставляем 8 на позицию 2
        linkedList.Cout(); // Должно вывести: 5 6 8 7

        linkedList.Delete(1); // Удаляем элемент на позиции 1
        linkedList.Cout(); // Должно вывести: 5 8 7

        linkedList.Clear();
        linkedList.Cout(); // Должно вывести пустую строку
    }
}
