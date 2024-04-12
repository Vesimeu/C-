using System;
using System.IO;
using System.Collections.Generic;
public delegate void ChangeEventHandler(object sender, EventArgs e);

public class BadIndexException : Exception
{
    public BadIndexException(string message) : base(message)
    {
    }
}

public class BadFileException : Exception
{
    public BadFileException(string message) : base(message)
    {
    }
}

public abstract class BaseList<T> where T : IComparable<T>
{

    public int CompareTo(BaseList<T> other)
    {
        // Сначала сравниваем количество элементов в списках
        if (Count != other.Count)
        {
            return Count.CompareTo(other.Count);
        }

        // Затем сравниваем каждый элемент поочередно
        for (int i = 0; i < Count; i++)
        {
            int comparisonResult = this[i].CompareTo(other[i]);
            if (comparisonResult != 0)
            {
                return comparisonResult;
            }
        }

        // Если все элементы равны, возвращаем ноль
        return 0;
    }
    public event ChangeEventHandler Change;

    protected virtual void OnChange(EventArgs e)
    {
        Change?.Invoke(this, e);
    }

    public virtual int Count { get; }

    public abstract void Add(T item);

    public abstract void Insert(int pos, T item);

    public abstract void Delete(int pos);

    public abstract void Clear();

    public abstract T this[int i] { get; set; }

    public virtual void Assign(BaseList<T> source)
    {
        Clear(); // Очищаем текущий список
        for (int i = 0; i < source.Count; i++)
        {
            Add(source[i]); // Копируем элементы из списка-источника в текущий список
        }
    }

    public virtual void AssignTo(BaseList<T> dest)
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

    protected abstract BaseList<T> CloneInternal(); // Абстрактный метод для копирования элементов списка

    public BaseList<T> Clone()
    {
        BaseList<T> clone = CloneInternal(); // Вызов абстрактного метода для копирования элементов
        clone.Assign(this);
        return clone;
    }

    public virtual bool IsEqual(BaseList<T> other)
    {
        if (other == null || !(other is BaseList<T>))
        {
            throw new ArgumentException("Other list is not of the same type as this list");
        }

        BaseList<T> otherList = (BaseList<T>)other;

        if (this.Count != otherList.Count)
        {
            return false;
        }

        for (int i = 0; i < this.Count; i++)
        {
            if (this[i].CompareTo(otherList[i]) != 0)
            {
                return false;
            }
        }

        return true;
    }

    public virtual void Sort()
    {
    // Создаем временный массив для сортировки
    T[] tempArray = new T[Count];
    for (int i = 0; i < Count; i++)
    {
        tempArray[i] = this[i];
    }

    // Сортируем временный массив с использованием CompareTo
    Array.Sort(tempArray);

    // Заменяем элементы в текущем списке отсортированными элементами из временного массива
    for (int i = 0; i < Count; i++)
    {
        this[i] = tempArray[i];
    }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < Count; i++)
                {
                    writer.WriteLine(this[i].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            throw new BadFileException("Error saving to file: " + ex.Message);
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    T item = (T)Convert.ChangeType(line, typeof(T));
                    Add(item);
                }
            }
            Change?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception ex)
        {
            throw new BadFileException("Error loading from file: " + ex.Message);
        }
    }

//     public virtual IEnumerator<T> GetEnumeratorInternal()
// {
//     return new ListEnumerator<T>(this);
// }

// public IEnumerator<T> GetEnumerator()
// {
//     return GetEnumeratorInternal();
// }
public void ForEach(Action<T> action)
    {
        for (int i = 0; i < Count; i++)
        {
            action(this[i]);
        }
    }

}
