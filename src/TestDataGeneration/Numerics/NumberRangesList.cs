using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace TestDataGeneration.Numerics;

public class NumberRangesList<T> : IReadOnlySet<NumberExtents<T>>, IReadOnlyList<NumberExtents<T>>, ICollection<NumberExtents<T>>, IList
    where T : IBinaryNumber<T>, IMinMaxValue<T>
{
    private readonly LinkedList<NumberExtents<T>> _backingList = new();

    public int Count => _backingList.Count;

    public object SyncRoot { get; } = new();

    bool ICollection<NumberExtents<T>>.IsReadOnly => false;

    bool IList.IsFixedSize => false;

    bool IList.IsReadOnly => true;

    bool ICollection.IsSynchronized => true;

    object? IList.this[int index] { get => GetItemAt(index); set => throw new NotSupportedException(); }

    NumberExtents<T> IReadOnlyList<NumberExtents<T>>.this[int index] => GetItemAt(index);

    public NumberRangesList(IEnumerable<NumberExtents<T>> collection)
    {
        throw new NotImplementedException();
    }

    public NumberRangesList(IEnumerable<(T First, T Last)> collection)
    {
        throw new NotImplementedException();
    }

    public NumberRangesList(params NumberExtents<T>[] list) : this((IEnumerable<NumberExtents<T>>)list) { }

    public NumberRangesList(params (T First, T Last)[] list) : this((IEnumerable<(T First, T Last)>)list) { }

    public NumberRangesList() { }

    private bool TryFindInsertionNode(T value, [NotNullWhen(true)] out LinkedListNode<NumberExtents<T>>? nextNode, out bool valueIsLessThanStart)
    {
        for (nextNode = _backingList.First; nextNode is not null; nextNode = nextNode.Next)
        {
            var item = nextNode.Value;
            var diff = value.CompareTo(item.First);
            if (diff < 0)
            {
                valueIsLessThanStart = true;
                return true;
            }
            if (diff == 0 || value <= item.Last)
            {
                valueIsLessThanStart = false;
                return true;
            }
        }
        valueIsLessThanStart = false;
        return false;
    }

    public bool Add(T value)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            if (TryFindInsertionNode(value, out LinkedListNode<NumberExtents<T>>? nextNode, out bool valueIsLessThanStart) && valueIsLessThanStart)
            {
                var item = nextNode.Value;
                if (value + T.One < item.First)
                {
                    var previous = nextNode.Previous;
                    if (previous is null || previous.Value.Last + T.One < value)
                    {
                        _backingList.AddBefore(nextNode, new NumberExtents<T>(value));
                        return true;
                    }
                }
            }
            else if ((nextNode = _backingList.First) is null || nextNode.Value.Last + T.One < value)
            {
                _backingList.AddLast(new NumberExtents<T>(value));
                return true;
            }
        }
        finally { Monitor.Exit(SyncRoot); }
        return false;
    }

    private bool SetEnd(LinkedListNode<NumberExtents<T>> node, T value)
    {
        var item = node.Value;
        if (value <= item.Last) return false;
        var first = item.First;
        var nextNode = node.Next;
        _backingList.Remove(node);
        if (nextNode is null)
            _backingList.AddLast(new NumberExtents<T>(first, value));
        else
            _backingList.AddBefore(nextNode, new NumberExtents<T>(first, value));
        return true;
    }

    public bool Add(NumberExtents<T> item)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            NumberExtents<T> other;
            if (TryFindInsertionNode(item.First, out LinkedListNode<NumberExtents<T>>? nextNode, out bool valueIsLessThanStart))
            {
                
            }
            else if ((nextNode = _backingList.First) is null || (other = nextNode.Value).Last + T.One < item.First)
            {
                _backingList.AddLast(item);
                return true;
            }
            else if (other.Last < item.Last)
            {
                var first = other.First;
                _backingList.RemoveLast();
                _backingList.AddLast(new NumberExtents<T>(first, item.Last));
                return true;
            }
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Add(T first, T last)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    void ICollection<NumberExtents<T>>.Add(NumberExtents<T> item) => Add(item);

    int IList.Add(object? value) => throw new NotSupportedException();

    public void Clear()
    {
        Monitor.Enter(SyncRoot);
        try
        {
            _backingList.Clear();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Contains(T value)
    {
        throw new NotImplementedException();
    }

    public bool Contains(NumberExtents<T> item) => _backingList.Contains(item);

    public bool Contains(T first, T last)
    {
        throw new NotImplementedException();
    }

    bool IList.Contains(object? value)
    {
        throw new NotImplementedException();
    }

    public bool ContainsAny(T first, T last)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(NumberExtents<T>[] array, int arrayIndex) => _backingList.CopyTo(array, arrayIndex);

    public void CopyTo(Array array, int index) => _backingList.ToArray().CopyTo(array, index);

    public IEnumerable<T> GetAllValues()
    {
        foreach (NumberExtents<T> item in _backingList)
        {
            foreach (T value in item)
                yield return value;
        }
    }

    public IEnumerator<NumberExtents<T>> GetEnumerator() => _backingList.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_backingList).GetEnumerator();

    public NumberExtents<T> GetItemAt(int index)
    {
        throw new NotImplementedException();
    }

    public T GetValueAt(BigInteger index)
    {
        throw new NotImplementedException();
    }

    public BigInteger GetValueCount()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(NumberExtents<T> value)
    {
        throw new NotImplementedException();
    }

    int IList.IndexOf(object? value)
    {
        throw new NotImplementedException();
    }

    void IList.Insert(int index, object? value) => throw new NotSupportedException();

    private bool ContainsAllElements(IEnumerable<NumberExtents<T>> other)
    {
        foreach (NumberExtents<T> element in other)
        {
            if (!Contains(element)) return false;
        }
        return true;
    }

    private int CheckUniqueAndUnfoundElements(IEnumerable<NumberExtents<T>> other, bool returnIfUnfound, out int unfoundCount)
    {
        // need special case in case this has no elements. 
        if (_backingList.Count == 0)
        {
            int numElementsInOther = 0;
            foreach (NumberExtents<T> item in other)
            {
                numElementsInOther++;
                // break right away, all we want to know is whether other has 0 or 1 elements
                break;
            }
            unfoundCount = numElementsInOther;
            return 0;
        }

        BitArray bitHelper = new BitArray(_backingList.Count);

        // count of items in other not found in this
        unfoundCount = 0;
        // count of unique items in other found in this
        int uniqueFoundCount = 0;
        foreach (NumberExtents<T> item in other)
        {
            int index = InternalIndexOf(item);

            if (index >= 0)
            {
                if (!bitHelper.Get(index))
                {
                    bitHelper.Set(index, true);
                    // item hasn't been seen yet
                    uniqueFoundCount++;
                }
            }
            else
            {
                unfoundCount++;
                if (returnIfUnfound) break;
            }
        }

        return uniqueFoundCount;
    }

    private int InternalIndexOf(NumberExtents<T> item)
    {
        int index = -1;
        for (LinkedListNode<NumberExtents<T>>? node = _backingList.First; node is not null; node = node.Next)
        {
            index++;
            if (node.Value.Equals(item)) return index;
        }
        return -1;
    }

    public bool IsProperSubsetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return other.Any();
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount > 0;
    }

    public bool IsProperSupersetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return false;
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount < _backingList.Count && unfoundCount == 0;
    }

    public bool IsSubsetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return true;
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount >= 0;
    }

    public bool IsSupersetOf(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        return ContainsAllElements(other);
    }

    public bool Overlaps(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        if (_backingList.Count == 0) return false;

        foreach (NumberExtents<T> element in other)
        {
            if (Contains(element))
            {
                return true;
            }
        }
        return false;
    }

    public bool Overlaps(T first, T last)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T value)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Remove(NumberExtents<T> item)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            return _backingList.Remove(item);
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool Remove(T first, T last)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    void IList.Remove(object? value) => throw new NotSupportedException();

    public void RemoveAt(int index)
    {
        Monitor.Enter(SyncRoot);
        try
        {
            throw new NotImplementedException();
        }
        finally { Monitor.Exit(SyncRoot); }
    }

    public bool SetEquals(IEnumerable<NumberExtents<T>> other)
    {
        ArgumentNullException.ThrowIfNull(other);
        var uniqueFoundCount = CheckUniqueAndUnfoundElements(other, false, out int unfoundCount);
        return uniqueFoundCount == _backingList.Count && unfoundCount == 0;
    }
}
