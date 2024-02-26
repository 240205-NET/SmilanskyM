using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var frequency = CountFrequency(new List<string>() { "hi", "bye", "hi", "hi", "bye", "later" });

        foreach (var item in frequency)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    public static Dictionary<T, int> CountFrequency<T>(List<T> list)
    {
        var frequency = new Dictionary<T, int>();

        foreach (var item in list)
        {
            if (frequency.ContainsKey(item))
            {
                frequency[item]++;
            }
            else
            {
                frequency[item] = 1;
            }
        }

        return frequency;
    }
}
