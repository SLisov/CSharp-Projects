using System.Collections;
var list = new CustomLinkedList<string>();
list.Add("a");
list.Add("b");
list.Add("c");
list.Remove("a");
list.Remove("c");
foreach (var item in list)
{
    Console.WriteLine(item);
}
Console.ReadLine();

public class CustomLinkedList<T> : ICustomLinkedList<T?>
{
    private CustomLinkedListNode? _head;
    private int _count;

    public CustomLinkedList()
    {
        _head = null;
    }

    public int Count => _count;

    public bool IsReadOnly => false;

    public bool Contains(T? item)
    {
        if (item is null)
        {
            return GetNodes().Any(node => node.value is null);
        }
        return GetNodes().Any(node => item.Equals(node.value));
    }

    public bool Remove(T? item)
    {
        CustomLinkedListNode? predecessor = null;
        foreach (var node in GetNodes())
        {
            if ((node.value is null && item is null) ||
                (node.value is not null && node.value.Equals(item)))
            {
                if (predecessor is null)
                {
                    _head = node.next;
                }
                else
                {
                    predecessor.next = node.next;
                }
                --_count;
                return true;
            }
            predecessor = node;
        }

        return false;
    }
    public void AddToFront(T? item)
    {
        var newHead = new CustomLinkedListNode(item)
        {
            next = _head
        };
        _head = newHead;
        ++_count;
    }
    public void AddToEnd(T? item)
    {
        var newNode = new CustomLinkedListNode(item);

        if (_head is null)
        {
            _head = newNode;
        }
        else
        {
            var tail = GetNodes().Last();
            tail.next = newNode;
        }
        ++_count;
    }
    public void Add(T? item)
    {
        AddToEnd(item);
    }
    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (arrayIndex < 0 || arrayIndex >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        if (array.Length < _count + arrayIndex)
        {
            throw new ArgumentException("Array is not long enough");
        }

        foreach(var node in GetNodes())
        {
            array[arrayIndex] = node.value;
            arrayIndex++;
        }
    }
    public void Clear()
    {
        CustomLinkedListNode? current = _head;
        while (current is not null)
        {
            CustomLinkedListNode? temp = current;
            current = current.next;
            temp.next = null;
        }

        _head = null;
        _count = 0;
    }
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var node in GetNodes())
        {
            yield return node.value;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    private IEnumerable<CustomLinkedListNode> GetNodes()
    {
        CustomLinkedListNode current = _head;
        while (current is not null)
        {
            yield return current;
            current = current.next;
        }
    }
    private class CustomLinkedListNode
    {
        public CustomLinkedListNode? next;
        public T value;

        public CustomLinkedListNode(T value)
        {
            this.value = value;
        }
        public void Invalidate()
        {
            next = null;
        }
        public override string ToString()
        {
            return $"Value: {value}, Next: {(next is null ? "null" : next.value)}";
        }
    }
}

public interface ICustomLinkedList<T> : ICollection<T>
{
    void AddToFront(T? item);
    void AddToEnd(T? item);
}