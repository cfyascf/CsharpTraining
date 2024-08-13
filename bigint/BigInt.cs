namespace Project;
using System.Numerics;

public class BigInt
{
    private byte[] data { get; set; }
    public BigInt(byte[] array)
    {
        data = array;
    }

    public static List<BigInt> Random(int size) {
        var list = new List<BigInt>();
        Random seed = new Random();

        for(int i = 0; i < size; i++) {
            byte[] bytes = new byte[1024];
            seed.NextBytes(bytes);

            BigInt b = new(bytes);
            list.Add(b);
        }

        return list;
    }

    public static void Sort(List<BigInt> array)
    {
        if (array.Count <= 1)
            return;

        var aux = array.Count / 2;

        var half = new List<BigInt>();
        for(int i = 0; i < aux; i++) {
            half.Insert(i, array[i]);
        }

        var anotherhalf = new List<BigInt>();
        var j = 0;
        for(int i = aux; i < array.Count; i++) {
            anotherhalf.Insert(j, array[i]);
            j++;
        }

        Parallel.Invoke(
        () => Merge(half),
        () => Merge(anotherhalf)
        );

        var arr = new List<BigInt>();
        for(int i = 0; i < half.Count; i++) {
            arr.Insert(i, half[i]);
        }

        
        for(int i = half.Count; i < half.Count + anotherhalf.Count; i++) {
            arr.Insert(i, anotherhalf[i - half.Count]);
        }

        Merge(arr);
    }

    public static void Merge(List<BigInt> array) {
        if (array.Count <= 1)
            return;

        int mid = array.Count / 2;

        List<BigInt> left = new List<BigInt>();
        List<BigInt> right = new List<BigInt>();

        for (int i = 0; i < mid; i++)
            left.Insert(i, array[i]);

        for (int i = mid; i < array.Count; i++)
            right.Insert(i - mid, array[i]);

        Merge(left);
        Merge(right);

        Merge_(array, left, right);
    }

    public static void Merge_(List<BigInt> array, List<BigInt> left, List<BigInt> right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Count && j < right.Count)
        {
            if (left[i] <= right[j])
                array[k++] = left[i++];
            else
                array[k++] = right[j++];
        }

        while (i < left.Count)
            array[k++] = left[i++];

        while (j < right.Count)
            array[k++] = right[j++];
    }

    // public static BigInt operator +(BigInt a, BigInt b) 
    // {
    //     var result = new BigInt();

    //     for(int i = a.data.Length - 1; i > -1; i--) 
    //     {
    //         for(int j = b.data.Length - 1; j == -1; j--) 
    //         {
    //             var flag = false;
    //             var aux = new List<byte>();
    //             var sum = a.data[i] + b.data[j];

    //             if(flag == true && j == -1)
    //             {
    //                 aux.Insert(0, 1);
    //                 continue;
    //             }

    //             if(sum > 1 && flag == false)
    //             {
    //                 flag = true;
    //                 aux.Insert(0, 0);
    //                 continue;
    //             }

    //             if(sum > 1 && flag == true)
    //             {
    //                 aux.Insert(0, 1);
    //                 continue;
    //             }

    //             if(sum == 1 && flag == true)
    //             {
    //                 aux.Insert(0, 0);
    //                 continue;
    //             }

    //             if(sum == 0 && flag == true)
    //             {
    //                 flag = false;
    //                 aux.Insert(0, 1);
    //                 continue;
    //             }

    //             aux.Insert(0, (byte) sum);

    //             if(j == -1 || i == -1) break;
    //         }
    //     }
    // }

    public static bool operator >(BigInt a, BigInt b)
    {
        if (a.data.Length > b.data.Length)
            return true;
        else if (a.data.Length < b.data.Length)
            return false;

        for (int i = 0; i < a.data.Length; i++)
        {
            if (a.data[i] == b.data[i])
                continue;

            if (a.data[i] > b.data[i])
                return true;
            else
                return false;
        }

        return false;
    }

    public static bool operator <(BigInt a, BigInt b)
    {
        if (a.data.Length > b.data.Length)
            return false;
        else if (a.data.Length < b.data.Length)
            return true;

        for (int i = 0; i < a.data.Length; i++)
        {
            if (a.data[i] == b.data[i])
                continue;

            if (a.data[i] > b.data[i])
                return false;
            else
                return true;
        }

        return false;
    }

    public static bool operator ==(BigInt a, BigInt b)
    {
        if (a.data.Length != b.data.Length)
            return false;

        for (int i = 0; i < a.data.Length; i++)
        {
            if (a.data[i] != b.data[i])
                return false;
        }

        return true;
    }

    public static bool operator !=(BigInt a, BigInt b)
    {
        if (a.data.Length != b.data.Length)
            return true;

        for (int i = 0; i < a.data.Length; i++)
        {
            if (a.data[i] != b.data[i])
                return true;
        }

        return false;
    }

    public static bool operator <=(BigInt a, BigInt b) {
        if(a == b) return true;
        if(a < b) return true;

        return false;
    }

    public static bool operator >=(BigInt a, BigInt b) {
        if(a == b) return true;
        if(a > b) return true;

        return false;
    }
}