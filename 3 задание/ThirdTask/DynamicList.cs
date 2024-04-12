using System;

namespace MyLists
{
    public class DynamicList<T> : BaseList<T> where T : IComparable
    {
        private T[] buffer;
        private int count;

        public DynamicList()
        {
            buffer = new T[4];
            count = 0;
        }

        public override int Count => count;

        public override void Add(T item)
        {
            if (count == buffer.Length)
            {
                Resize(buffer.Length * 2);
            }
            buffer[count++] = item;
            OnChange();
        }

        public override void Insert(int pos, T item)
        {
            if (pos < 0 || pos > count)
            {
                throw new BadIndexException("Position is out of range");
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
            OnChange();
        }

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                throw new BadIndexException("Position is out of range");
            }

            for (int i = pos; i < count - 1; i++)
            {
                buffer[i] = buffer[i + 1];
            }

            count--;
            OnChange();
        }

        public override void Clear()
        {
            buffer = new T[4];
            count = 0;
            OnChange();
        }

        public override T this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
                }
                return buffer[i];
            }
            set
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
                }
                buffer[i] = value;
                OnChange();
            }
        }

        protected override BaseList<T> CloneInternal()
        {
            DynamicList<T> clone = new DynamicList<T>();
            return clone;
        }

        private void Resize(int newSize)
        {
            T[] newBuffer = new T[newSize];
            Array.Copy(buffer, newBuffer, count);
            buffer = newBuffer;
        }
    }
}
