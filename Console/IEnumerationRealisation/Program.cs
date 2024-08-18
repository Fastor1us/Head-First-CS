namespace IEnumerationRealisation;

enum Sport { Football, Baseball, Basketball, Hockey, Boxing, Rugby, Fencing }

class Program
{
    static void Main()
    {
        Console.WriteLine("YieldIEnumerableRealisation:");
        YieldIEnumerableRealisation<Sport> sportSequence1 = new();
        foreach (var sport in sportSequence1) Console.WriteLine(sport);
        Console.WriteLine($"Second sport in the sequence is {sportSequence1[1]}");

        Console.WriteLine("");

        Console.WriteLine("ClassicIEnumerableRealisation:");
        ClassicIEnumerableRealisation sportSequence2 = new();
        foreach (var sport in sportSequence2) Console.WriteLine(sport);
        Console.WriteLine($"Second sport in the sequence is {sportSequence2[1]}");

        Console.WriteLine("");
        foreach (var s in SimpleEnumerable()) Console.WriteLine(s);
    }

    static IEnumerable<string> SimpleEnumerable()
    {
        yield return "pegasus";
        yield return "unicorn";
    }
}
