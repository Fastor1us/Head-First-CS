using System.Collections;

namespace IEnumerationRealisation;

class YieldIEnumerableRealisation<T> : IEnumerable<T> where T : Enum
{
    public T this[int index]
    {
        get
        {
            var names = Enum.GetNames(typeof(T));
            if (index >= 0 && index < names.Length)
                return (T)Enum.Parse(typeof(T), names[index]);
            throw new IndexOutOfRangeException("Index out of range");
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var value in Enum.GetValues(typeof(T)))
            yield return (T)value;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
