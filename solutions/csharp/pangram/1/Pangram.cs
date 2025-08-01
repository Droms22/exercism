using System;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        input = input.ToUpper();
        for (int i=65; i < 91; i++) {
            if (!input.Contains((char)i)) return false;
        }
        return true;
    }
}
