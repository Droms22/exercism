using System;

public static class CollatzConjecture
{
    public static int Steps(int n, int steps = 0)
    {
        if (n < 1) throw new ArgumentOutOfRangeException();
        if (n == 1) return steps;
        return Steps(n % 2 == 0 ? n/2 : n*3 + 1, steps: steps+1);
    }
}