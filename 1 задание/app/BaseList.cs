using System;

public abstract class BaseList
{
    // Абстрактные методы, которые будут реализованы в классах-наследниках
    public abstract int Count { get; }
    public abstract void Add(int item);
    public abstract void Insert(int pos, int item);
    public abstract void Delete(int pos);
    public abstract void Clear();
    
    public abstract int this[int i] { get; set; }
    public abstract void Print();
    public abstract void Assign(BaseList source);
    public abstract void AssignTo(BaseList dest);
    public abstract BaseList Clone();
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