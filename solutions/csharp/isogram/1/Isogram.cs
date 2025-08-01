using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = Regex.Replace(word, "[^a-zA-Z]", string.Empty);
        return word.ToLower().Length == String.Join("",word.ToLower().Distinct()).Length;
    }
}
