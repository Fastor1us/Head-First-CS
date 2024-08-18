using System.Collections;

namespace IEnumerationRealisation;

class ClassicIEnumerableRealisation : IEnumerable<Sport>
{
    public Sport this[int index] => (Sport)index;

    public IEnumerator<Sport> GetEnumerator() => new ManualSportEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class ManualSportEnumerator : IEnumerator<Sport>
{
    int current = -1;
    public Sport Current => (Sport)current;
    object IEnumerator.Current => Current;
    public void Dispose() { return; }
    public bool MoveNext()
    {
        bool shouldMoveNext = current < Enum.GetValues(typeof(Sport)).Length - 1;
        if (shouldMoveNext) current++;
        return shouldMoveNext;
    }
    public void Reset() => current = -1;
}
