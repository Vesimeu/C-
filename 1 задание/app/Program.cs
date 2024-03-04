// Program.cs
using System;

namespace MyLists
{
    class Program
    {

        static void Main(string[] args)
{
    BaseList dynamicList = new DynamicList();
    BaseList linkedList = new LinkedList();

    // Блок проверки метода Add
    Console.WriteLine("Проверка метода Add:");
    dynamicList.Add(3);
    dynamicList.Add(10);
    dynamicList.Add(5);

    linkedList.Add(3);
    linkedList.Add(10);
    linkedList.Add(5);

    Console.WriteLine("Список DynamicList после добавления элементов:");
    dynamicList.Print();
    Console.WriteLine("Список LinkedList после добавления элементов:");
    linkedList.Print();
    Console.WriteLine();

    // Блок проверки метода Insert
    Console.WriteLine("Проверка метода Insert:");
    dynamicList.Insert(1, 1);
    linkedList.Insert(1, 1);

    Console.WriteLine("Список DynamicList после вставки элемента:");
    dynamicList.Print();
    Console.WriteLine("Список LinkedList после вставки элемента:");
    linkedList.Print();
    Console.WriteLine();

    // Блок проверки метода Delete
    Console.WriteLine("Проверка метода Delete:");
    dynamicList.Delete(1);
    linkedList.Delete(1);

    Console.WriteLine("Список DynamicList после удаления элемента:");
    dynamicList.Print();
    Console.WriteLine("Список LinkedList после удаления элемента:");
    linkedList.Print();
    Console.WriteLine();

    // Блок проверки метода Clear
    Console.WriteLine("Проверка метода Clear:");
    dynamicList.Clear();
    linkedList.Clear();

    Console.WriteLine("Список DynamicList после очистки:");
    dynamicList.Print();
    Console.WriteLine("Список LinkedList после очистки:");
    linkedList.Print();
    Console.WriteLine();

    // Блок проверки метода IsEqual
    Console.WriteLine("Проверка метода IsEqual:");
    dynamicList.Add(3);
    dynamicList.Add(10);
    dynamicList.Add(5);

    linkedList.Add(3);
    linkedList.Add(10);
    linkedList.Add(5);

    bool equal = dynamicList.IsEqual(linkedList);
    Console.WriteLine($"Списки {(equal ? "одинаковы" : "различны")}\n");


    // Проверка метода Assign
    Console.WriteLine("***ПРОВЕРКА МЕТОДА Assign***");

    BaseList assignedList = new DynamicList();

    assignedList.Add(1);
    assignedList.Add(2);
    assignedList.Add(3);

    Console.WriteLine("Исходный список assignedList:");
    assignedList.Print();


    Console.WriteLine("Исходный список dynamicList:");
    dynamicList.Print();


    //Вот она
    dynamicList.Assign(assignedList);

    Console.WriteLine("Список AssignedList после применения метода Assign:");
    assignedList.Print();
    Console.WriteLine("Список DynamicList после применения метода Assign:");
    dynamicList.Print();
    Console.WriteLine();

    // Проверка метода AssignTo
    Console.WriteLine("***ПРОВЕРКА МЕТОДА AssignTo***");
    //accert
    dynamicList.Add(9);
    BaseList assignedToList = new DynamicList();
    assignedToList.Add(2);
    assignedToList.Add(4);
    assignedToList.Add(3);
    Console.WriteLine("Список DynamicList после применения метода Assign:");
    dynamicList.Print();
    Console.WriteLine("Список AssignedToList после применения метода Assign:");
    assignedToList.Print();


    dynamicList.AssignTo(assignedToList);

    Console.WriteLine("Список DynamicList после применения метода AssignTo:");
    dynamicList.Print();
    Console.WriteLine("Список AssignedToList после применения метода AssignTo:");
    assignedToList.Print();

    }
    }
}
