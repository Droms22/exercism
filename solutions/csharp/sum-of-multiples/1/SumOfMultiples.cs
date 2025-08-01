using System;
using System.Linq;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        HashSet<int> uniqueMultiples = new HashSet<int>();
        for (int i=1; i < max; i++) {
            foreach (int multiple in multiples) {
                if (multiple != 0 && i % multiple == 0) {
                    uniqueMultiples.Add(i);
                }
            }
        }
        return uniqueMultiples.Sum();
    }
}