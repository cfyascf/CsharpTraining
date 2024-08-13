using System.Data.SqlTypes;

namespace Project;
public class Program  
{
    public static void Main(String[] args) 
    {
        // var list = BigInt.Random(10000);
        // BigInt.Sort(list);
        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
        var lista = BigInt.Random(1000000);
        BigInt.Sort(lista);
        Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));

        return;
    }
}