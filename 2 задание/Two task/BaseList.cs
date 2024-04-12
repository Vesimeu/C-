using System;

public abstract class BaseList
{
    // Абстрактные методы, которые будут реализованы в классах-наследниках
    public virtual int Count { get; protected set; }
    public abstract void Add(int item);
    public abstract void Insert(int pos, int item);
    public abstract void Delete(int pos);
    public abstract void Clear();

    public abstract int this[int i] { get; set; }

    public virtual void Assign(BaseList source)
    {
        Clear(); // Очищаем текущий список
        for (int i = 0; i < source.Count; i++)
        {
            Add(source[i]); // Копируем элементы из списка-источника в текущий список
        }
    }

    public virtual void AssignTo(BaseList dest)
    {
        dest.Clear(); // Очищаем целевой список
        for (int i = 0; i < Count; i++)
        {
            dest.Add(this[i]); // Копируем элементы из текущего списка в целевой список
        }
    }

    public virtual void Print()
    {
    for (int i = 0; i < Count; i++)
    {
        Console.Write(this[i] + " "); // Вывод каждого элемента списка через пробел
    }
    Console.WriteLine(); // Переход на новую строку после вывода всех элементов
    }


  // Абстрактный метод для копирования элементов списка
    protected abstract BaseList CloneInternal(); //create пустышку с нужным мне типом данных

    // Метод для создания копии списка
    public BaseList Clone()
    {
        BaseList clone = CloneInternal(); // Вызов абстрактного метода для копирования элементов
        clone.Assign(this);
        return clone;
    }

// Перепиши метод sort для LinkedList использую другой алгоритм - лгоритм быстрой сортировки.
    public virtual void Sort()
        {
            // Реализация сортировки пузырьком
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (this[j] > this[j + 1])
                    {
                        int temp = this[j];
                        this[j] = this[j + 1];
                        this[j + 1] = temp;
                    }
                }
            }
        }
        
    public virtual bool IsEqual(BaseList other)
    {
    // Проверяем, что другой список не равен null и что тип объекта является производным от BaseList
    if (other == null || ! (other is BaseList))
    {
        throw new ArgumentException("Other list is not of the same type as this list"); //или всё таки return
    }

    // Приведение объекта к типу BaseList для сравнения
    BaseList otherList = (BaseList)other;

    // Сравниваем количество элементов
    if (this.Count != otherList.Count)
    {
        return false;
    }

    // Построение логики сравнения элементов списка
    for (int i = 0; i < this.Count; i++)
    {
        if (this[i] != otherList[i])
        {
            return false;
        }
    }

    return true;
    }
}