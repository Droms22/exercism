using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        return String.Join("",phrase.Split(' ','-','_').Where(s => s.Length >= 1).Select(s => s.Substring(0,1).ToUpper()));
    }
}