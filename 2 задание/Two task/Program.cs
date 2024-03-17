// Program.cs
using System;

namespace MyLists
{
    class Program
    {
public static void TestPerformance()
{
    Random random = new Random();

    DynamicList dynamicList = new DynamicList();
    LinkedList linkedList = new LinkedList();

    for (int i = 0; i < 10000; i++)
    {
        int operation = random.Next(7); // Выбор операции
        int value = random.Next(100); // Случайное значение
        int index = random.Next(1, 100); // Случайный индекс

        try
        {
            switch (operation)
            {
                case 0:
                    dynamicList.Add(value);
                    linkedList.Add(value);
                    break;
                case 1:
                    if (dynamicList.Count > 0 && linkedList.Count > 0)
                    {
                        dynamicList.Insert(value, index % dynamicList.Count);
                        linkedList.Insert(value, index % linkedList.Count);
                    }
                    break;
                case 2:
                    if (dynamicList.Count > 0 && linkedList.Count > 0)
                    {
                        dynamicList.Delete(index);
                        linkedList.Delete(index);
                    }
                    break;
                case 3:
                    dynamicList.Clear();
                    linkedList.Clear();
                    break;
                case 4:
                    if (dynamicList.Count > 0 && linkedList.Count > 0)
                    {
                        dynamicList[index % dynamicList.Count] = value;
                        linkedList[index % linkedList.Count] = value;
                    }
                    break;
                case 5:
                  // Проверка метода Sort
                    dynamicList.Sort();
                    linkedList.Sort();

                    // Проверка, отсортированы ли списки
                    bool isDynamicListSorted = IsSortedFact(dynamicList, dynamicList.Clone());
                    bool isLinkedListSorted = IsSortedFact(linkedList, linkedList.Clone());

                    // Console.WriteLine($"DynamicList is sorted: {isDynamicListSorted}");
                    // Console.WriteLine($"LinkedList is sorted: {isLinkedListSorted}");

                    static bool IsSortedFact(BaseList original, BaseList sorted)
                    {
                        // Проверяем, что количество элементов в исходном и отсортированном списке совпадает
                        if (original.Count != sorted.Count)
                        {
                            return false;
                        }

                        // Создаем копию отсортированного списка для поиска элементов
                        BaseList sortedCopy = sorted.Clone();

                        // Проходим по исходному списку
                        for (int i = 0; i < original.Count; i++)
                        {
                            int currentItem = original[i];
                            bool found = false;

                            // Проверяем, есть ли текущий элемент исходного списка в отсортированной копии
                            for (int j = 0; j < sortedCopy.Count; j++)
                            {
                                if (sortedCopy[j] == currentItem)
                                {
                                    // Если элемент найден, удаляем его из копии
                                    sortedCopy.Delete(j);
                                    found = true;
                                    break;
                                }
                            }

                            // Если текущий элемент исходного списка не найден в отсортированной копии, возвращаем false
                            if (!found)
                            {
                                return false;
                            }
                        }

                        // Если все элементы исходного списка найдены в отсортированной копии, возвращаем true
                        return true;
                    }


                    break;
                // case 6:
                //     BaseList cloneDynamicList = dynamicList.Clone();
                //     BaseList cloneLinkedList = linkedList.Clone();
                //     Console.WriteLine(cloneDynamicList.IsEqual(dynamicList) && cloneLinkedList.IsEqual(linkedList));
                //     break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }

    Console.WriteLine(dynamicList.Count == linkedList.Count);

    // Проверка на одинаковость списков
    bool areListsEqual = dynamicList.IsEqual(linkedList);
    Console.WriteLine($"Списки {(areListsEqual ? "одинаковы" : "различны")}.");
    Console.WriteLine("Тестирование завершено.");
}



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


    Console.WriteLine("Исходный список dynamicList:");
    dynamicList.Print();
    Console.WriteLine("Исходный список assignedList:");
    assignedList.Print();


    
    dynamicList.Assign(assignedList);

    Console.WriteLine("Список DynamicList после применения метода Assign:");
    dynamicList.Print();
    Console.WriteLine("Список AssignedList после применения метода Assign:");
    assignedList.Print();
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
    Console.WriteLine("");

    // Блок проверки метода Sort
    Console.WriteLine("Проверка метода Sort:");
    dynamicList.Sort();
    linkedList.Sort();

    Console.WriteLine("Список DynamicList после сортировки:");
    dynamicList.Print();
    Console.WriteLine("Список LinkedList после сортировки:");
    linkedList.Print();
    Console.WriteLine();

    Console.WriteLine("***ВЫЗОВ МЕТОДА ТЕСТИРОВКИ***");
    TestPerformance();

    }
 }
}
