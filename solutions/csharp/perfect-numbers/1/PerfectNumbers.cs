using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException();
        HashSet<int> factors = new();
        for (int i=1; i < number; i++) {
            if (number % i == 0) {
                factors.Add(i);
            }
        }
        int sum = factors.Sum();
        if (sum < number) return Classification.Deficient;
        if (sum > number) return Classification.Abundant;
        return Classification.Perfect;
    }
}
