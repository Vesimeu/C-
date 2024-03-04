using System;


namespace MyLists{
public class DynamicList : BaseList
{
    private int[] buffer;
    private int count;

    public DynamicList()
    {
        buffer = new int[4];
        count = 0;
    }

    public override int Count => count;

    public override void Add(int item)
    {
        if (count == buffer.Length)
        {
            Resize(buffer.Length * 2);
        }
        buffer[count++] = item;
    }

    public override void Insert(int pos, int item)
    {
        if (pos < 0 || pos > count)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range");
        }

        if (count == buffer.Length)
        {
            Resize(buffer.Length * 2);
        }

        for (int i = count; i > pos; i--)
        {
            buffer[i] = buffer[i - 1];
        }

        buffer[pos] = item;
        count++;
    }

    public override void Delete(int pos)
    {
        if (pos < 0 || pos >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range");
        }

        for (int i = pos; i < count - 1; i++)
        {
            buffer[i] = buffer[i + 1];
        }

        count--;
    }

    public override void Clear()
    {
        buffer = new int[4];
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
            return buffer[i];
        }
        set
        {
            if (i < 0 || i >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range");
            }
            buffer[i] = value;
        }
    }

    public override void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(buffer[i] + " ");
        }
        Console.WriteLine();
    }

    public override void Assign(BaseList source)
    {
        DynamicList dynamicSource = source as DynamicList;
        if (dynamicSource == null)
        {
            throw new ArgumentException("Source list is not of type DynamicList");
        }

        buffer = new int[dynamicSource.buffer.Length];
        Array.Copy(dynamicSource.buffer, buffer, dynamicSource.count);
        count = dynamicSource.count;
    }

    public override void AssignTo(BaseList dest)
    {
        DynamicList dynamicDest = dest as DynamicList;
        if (dynamicDest == null)
        {
            throw new ArgumentException("Destination list is not of type DynamicList");
        }

        dynamicDest.buffer = new int[buffer.Length];
        Array.Copy(buffer, dynamicDest.buffer, count);
        dynamicDest.count = count;
    }

    public override BaseList Clone()
    {
        DynamicList clone = new DynamicList();
        clone.Assign(this);
        return clone;
    }

    // public override void Sort()
    // {
    //     Array.Sort(buffer, 0, count);
    // }

    // public override bool IsEqual(BaseList other)
    // {
    //     DynamicList dynamicOther = other as DynamicList;
    //     if (dynamicOther == null)
    //     {
    //         throw new ArgumentException("Other list is not of type DynamicList");
    //     }

    //     if (count != dynamicOther.count)
    //     {
    //         return false;
    //     }

    //     for (int i = 0; i < count; i++)
    //     {
    //         if (buffer[i] != dynamicOther.buffer[i])
    //         {
    //             return false;
    //         }
    //     }

    //     return true;
    // }

    private void Resize(int newSize)
    {
        int[] newBuffer = new int[newSize];
        Array.Copy(buffer, newBuffer, count);
        buffer = newBuffer;
    }
}
}