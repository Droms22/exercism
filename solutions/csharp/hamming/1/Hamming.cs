using System;

public static class Hamming
{
    public static int Distance(string f, string s)
    {
        if (f.Length != s.Length) throw new ArgumentException();
        int c = 0;
        for (int i=0; i < f.Length; i++) {
            if (f[i] != s[i]) c++;
        }
        return c;
    }
}