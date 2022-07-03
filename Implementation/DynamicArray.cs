using System.Collections;
using DataStructures.Adt;

namespace DataStructures.Implementation;



public class DynamicArray<T> : IDynamicArray<T> where T : new()
{

    private T[] _arr;

    private int _len = 0;
    private int _capacity = 0;



    public DynamicArray()
        : this(16)
    {
    }

    public DynamicArray(int capacity)
    {
        if (capacity < 0) throw new ArgumentException("Illegal argument");
        _capacity = capacity;
        _arr = new T[capacity];

    }


    public int Size()
        => _len;

    public void Add(T obj)
    {
        if (_len + 1 >= _capacity)
        {
            if (_capacity == 0) _capacity = 1;
            else _capacity *= 2;

            var newArray = new T[_capacity];
            for (int i = 0; i < _len; i++) newArray[i] = _arr[i];
            _arr = newArray;
        }

        _arr[_len++] = obj; // this will also modify the _len property of object;
    }



    public bool Contains(T obj)
        => IndexOf(obj) != -1;



    public T Get(int index)
    {
        if (index > _len || index < 0)
        {
            throw new ArgumentException("Index out of range");
        }

        return _arr[index];
    }

    public void Set(int index, T val)
    {
        _arr[index] = val;
    }


    public int IndexOf(T obj)
    {
        for (int i = 0; i < _len; i++)
        {
            if (_arr[i]!.Equals(obj))
            {
                return i;
            }
        }

        return -1; // element not found
    }

    public void Insert(int index, T obj)
    {
        if (index >= _len) throw new ArgumentOutOfRangeException();

        if (_len >= _capacity)
        {
            _capacity *= 2;
            var newArray = new T[_capacity];
            for (int i = 0; i < _len; i++)
            {
                newArray[i] = _arr[i];
            }

            _arr = newArray;
        }

        for (int i = _len - 1; i >= index; i--)
        {
            _arr[i + 1] = _arr[i];
        }

        _arr[index] = obj;
        _len++;
    }


    public bool IsEmpty()
        => Size() == 0;

    public bool Remove(T obj)
    {
        var idx = IndexOf(obj);
        RemoveAt(idx);
        return true;
    }

    public T RemoveAt(int index)
    {
        if (index >= _len || index < 0) throw new ArgumentOutOfRangeException();
        var obj = _arr[index];

        var newArr = new T[_len - 1];
        for (int i = 0, j = 0; i < _len; i++, j++)
        {
            if (i == index) j--; //skip over the the removed element
            else newArr[j] = _arr[i];
        }

        _arr = newArr;
        _capacity = --_len;
        return obj;
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _len; i++)
        {
            yield return _arr[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        string output = "{";
        for (int i = 0; i < _len; i++)
        {
            output += $"{_arr[i].ToString()}";
            if (i != _len -1 ) output += ",";
        }
        output += "}";
        return output;
    }
}