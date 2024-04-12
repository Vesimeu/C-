using System;

namespace MyLists
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseList<string> dynamicList = new DynamicList<string>();
            BaseList<string> linkedList = new LinkedList<string>();

            // Добавление элементов
            dynamicList.Add("apple");
            dynamicList.Add("banana");
            dynamicList.Add("orange");

            linkedList.Add("apple");
            linkedList.Add("banana");
            linkedList.Add("orange");

            Console.WriteLine("Список DynamicList после добавления элементов:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после добавления элементов:");
            linkedList.Print();
            Console.WriteLine();

            // Вставка элемента
            dynamicList.Insert(1, "grape");
            linkedList.Insert(1, "grape");

            Console.WriteLine("Список DynamicList после вставки элемента:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после вставки элемента:");
            linkedList.Print();
            Console.WriteLine();

            // Удаление элемента
            dynamicList.Delete(2);
            linkedList.Delete(2);

            Console.WriteLine("Список DynamicList после удаления элемента:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после удаления элемента:");
            linkedList.Print();
            Console.WriteLine();

            // Очистка списков
            dynamicList.Clear();
            linkedList.Clear();

            Console.WriteLine("Список DynamicList после очистки:");
            dynamicList.Print();
            Console.WriteLine("Список LinkedList после очистки:");
            linkedList.Print();
            Console.WriteLine();

            // Проверка на равенство списков
            dynamicList.Add("apple");
            dynamicList.Add("banana");
            dynamicList.Add("orange");

            linkedList.Add("apple");
            linkedList.Add("banana");
            linkedList.Add("orange");

            bool areListsEqual = dynamicList.IsEqual(linkedList);
            Console.WriteLine($"Списки {(areListsEqual ? "одинаковы" : "различны")}.");
            Console.WriteLine();

            // Проверка метода Assign
            BaseList<string> assignedList = new DynamicList<string>();

            assignedList.Add("pineapple");
            assignedList.Add("grapefruit");

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
            dynamicList.Add("watermelon");
            BaseList<string> assignedToList = new DynamicList<string>();

            assignedToList.Add("grapes");
            assignedToList.Add("kiwi");

            Console.WriteLine("Список DynamicList после применения метода Assign:");
            dynamicList.Print();
            Console.WriteLine("Список AssignedToList после применения метода Assign:");
            assignedToList.Print();

            dynamicList.AssignTo(assignedToList);

            Console.WriteLine("Список DynamicList после применения метода AssignTo:");
            dynamicList.Print();
            Console.WriteLine("Список AssignedToList после применения метода AssignTo:");
            assignedToList.Print();
            Console.WriteLine();

            Console.WriteLine("*** ВЫЗОВ МЕТОДА ТЕСТИРОВКИ ***");
            TestPerformance();
        }

        public static void TestPerformance()
        {
            Random random = new Random();

            BaseList<string> dynamicList = new DynamicList<string>();
            BaseList<string> linkedList = new LinkedList<string>();

            for (int i = 0; i < 10000; i++)
            {
                int operation = random.Next(4); // Выбор операции
                string value = "Value" + random.Next(100); // Случайное значение
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
                            dynamicList.Insert(value, index % dynamicList.Count);
                            linkedList.Insert(value, index % linkedList.Count);
                            break;
                        case 2:
                            dynamicList.Delete(index);
                            linkedList.Delete(index);
                            break;
                        case 3:
                            dynamicList.Clear();
                            linkedList.Clear();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }

            Console.WriteLine(dynamicList.Count == linkedList.Count);

            // Проверка на равенство списков
            bool areListsEqual = dynamicList.IsEqual(linkedList);
            Console.WriteLine($"Списки {(areListsEqual ? "одинаковы" : "различны")}.");
            Console.WriteLine("Тестирование завершено.");
        }
    }
}
