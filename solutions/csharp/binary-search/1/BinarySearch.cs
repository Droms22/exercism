using System;
using System.Linq;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int low = 0;
        int high = input.Length-1;

        while (low <= high) {
            int middle = (low + high) / 2;
            if (input[middle] == value) return middle;
            if (input[middle] > value) {
                high = middle - 1;
            } else {
                low = middle + 1;
            }
        }
        return -1;
    }
}