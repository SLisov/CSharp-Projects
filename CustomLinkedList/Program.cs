using System.Collections;

Console.ReadLine();

public class CustomLinkedList<T> : ICustomLinkedList<T?>
{
    private CustomLinkedListNode<T>? _head;
    private int _count;

    public CustomLinkedList()
    {
        _head = null;
    }

    public int Count => _count;

    public bool IsReadOnly => false;

    public bool Contains(T? item)
    {
        CustomLinkedListNode<T>? current = _head;

        for (int i = 0; i < _count; i++)
        {
            if (current.value.Equals(item))
            {
                return true;
            }
            current = current.next;
        }
        return false;
    }

    public bool Remove(T? item)
    {
        if (_head == null)
        {
            return false;
        }

        if (_head.value.Equals(item))
        {
            _head = _head.next;
            _count--;
            return true;
        }

        CustomLinkedListNode<T> current = _head;

        while (current.next != null)
        {
            if (current.next.value.Equals(item))
            {
                current.next = current.next.next;
                _count--;
                return true;
            }

            current = current.next;
        }

        return false;
    }
    public void AddToFront(T? item)
    {
        if (this._head == null)
        {
            this._head = new CustomLinkedListNode<T>(item);
        }
        else
        {
            CustomLinkedListNode<T> temp = _head;
            _head = new CustomLinkedListNode<T>(item);
            _head.next = temp;
        }
        ++_count;
    }
    public void AddToEnd(T? item)
    {
        if(this._head == null)
        {
            this._head = new CustomLinkedListNode<T>(item);
        }
        else
        {
            CustomLinkedListNode<T> current = _head;

            while (current.next != null)
            {
                current = current.next;
            }

            current.next = new CustomLinkedListNode<T>(item);
        }
        ++_count;
    }
    public void Add(T? item)
    {
        AddToEnd(item);
    }
    public void CopyTo(T?[] array, int arrayIndex)
    {
        if(array == null
            || array[arrayIndex] is null
            || _count > array.Length - arrayIndex)
        {
            throw new ArgumentNullException("array does not met requarements");
        }
        CustomLinkedListNode<T> current = _head;
        while (current != null)
        {
            array[arrayIndex] = current.value;
            arrayIndex++;
            current = current.next;
        }
    }
    public void Clear()
    {
        CustomLinkedListNode<T>? current = _head;
        while (current != null)
        {
            CustomLinkedListNode<T> temp = current;
            current = current.next;
            temp.Invalidate();
        }

        _head = null;
        _count = 0;
    }
    public IEnumerator<T> GetEnumerator()
    {
        CustomLinkedListNode<T>? current = _head;
        while (current != null)
        {
            yield return current.value;
            current = current.next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public interface ICustomLinkedList<T> : ICollection<T>
{
    void AddToFront(T? item);
    void AddToEnd(T? item);
}

public class CustomLinkedListNode<T>
{
    public CustomLinkedListNode<T>? next;
    public T value;

    public CustomLinkedListNode(T value)
    {
        this.value = value;
    }
    internal void Invalidate()
    {
        next = null;
    }
}