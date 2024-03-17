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

    // public override int Count => count;

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
            // throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range");
            return;
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
            // throw new ArgumentOutOfRangeException(nameof(pos), "Position is out of range");
            return;
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
                // throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range");
                return 0;
            }
            return buffer[i];
        }
        set
        {
            if (i < 0 || i >= count)
            {
                // throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range");
                // return 0;
            }
            buffer[i] = value;
        }
    }


    protected override BaseList CloneInternal()
{
    DynamicList clone = new DynamicList();
    return clone;
}


    private void Resize(int newSize)
    {
        int[] newBuffer = new int[newSize];
        Array.Copy(buffer, newBuffer, count);
        buffer = newBuffer;
    }
}
}