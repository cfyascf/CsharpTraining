using System.Runtime.InteropServices;

namespace Project;
public class Program
{
    public static void Main(string[] args)
    {
        MyList<int> l = [1, 2, 3, 4, 5, 6, 7];

        foreach (var item in l)
        {
            var iterable = l.GetEnumerator();
            iterable.MoveNext();
            iterable.MoveNext();
            iterable.MoveNext();
    
            Console.WriteLine("{0}", iterable.Current);
        }
    }
}
