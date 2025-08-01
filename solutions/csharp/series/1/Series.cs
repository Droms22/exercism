using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        List<string> slices = new();
        if (numbers.Length < sliceLength || sliceLength <= 0) throw new ArgumentException();
        int i=0;
        while (i+sliceLength <= numbers.Length) {
            slices.Add(numbers.Substring(i,sliceLength));
            i++;
        }
        return slices.ToArray();
    }
}