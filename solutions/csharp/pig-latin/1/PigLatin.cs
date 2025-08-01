using System.Text.RegularExpressions;

public static class PigLatin
{
    public static string Translate(string word) => Regex.Replace(word, @"\b(ch?|qu?|squ|thr|th|sch|y(?!t)|x(?!r)|[bdfghjklmnprstvwz]{2,}(?=y)|[bdfghjklmnprstvwz])?(\S+)", @"$2$1ay", RegexOptions.IgnoreCase);
}