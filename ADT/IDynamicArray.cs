namespace DataStructures.Adt;

public interface IDynamicArray<T>: IEnumerable<T> where T: new()
{
    int Size();
    Boolean IsEmpty();
    T Get(int index);
    void Set(int index, T val);
    int IndexOf(T obj);
    bool Contains(T obj);
    void Clear();
    void Add(T obj);
    void Insert(int index, T obj);
    T RemoveAt(int index);
    bool Remove(T obj);
}