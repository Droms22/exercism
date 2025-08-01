using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var w = word.ToLower().Where(char.IsLetter).ToList();
        return w.Count() == w.Distinct().Count();
    }
}
