using System;

public static class CollatzConjecture
{
    public static int Steps(int n)
    {
        if (n < 1) throw new ArgumentOutOfRangeException();
        int steps = 0;
        while (n > 1) {
            if (n % 2 == 0) {
                n = n/2;
            } else {
                n = n*3 + 1;
            } 
            steps++;
        }
        return steps;
    }
}