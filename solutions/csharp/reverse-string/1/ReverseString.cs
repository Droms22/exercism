using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        char[] tmp = input.ToCharArray();
        Array.Reverse(tmp);
        return new string(tmp);
    }
}