using System;
using System.Linq;

public static class SquareRoot
{
    public static int Root(int number)
    {
        var range = Enumerable.Range(1, number);
        
        while (range.Count() > 0) {
            int middle = range.Skip(range.Count() / 2).First();
            
            if (middle * middle == number)
                return middle;

            if (middle * middle > number) {
                range = range.TakeWhile(n => n < middle);
            } else {
                range = range.SkipWhile(n => n <= middle);
            }
        }

        return 1;
    }
}
