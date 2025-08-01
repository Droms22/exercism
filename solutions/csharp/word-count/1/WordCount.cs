using System;
using System.Collections.Generic;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        Dictionary<string,int> freq = new();
        char[] divider = {' ',',','.','!','?',';','\n','\t','&','@','$','^','%',':'};
        foreach (string word in phrase.Split(divider))
        {
            string w = word.ToLower();
            if (w.Length == 0 || (w.Length == 1 && !int.TryParse(w,out _) && !Char.IsLetter(w[0]))) continue;
            if (!Char.IsLetter(w[0]) && !Char.IsDigit(w[0])) w = w.Substring(1);
            if (!Char.IsLetter(w[w.Length-1]) && !Char.IsDigit(w[0])) w = w.Substring(0,w.Length-1);
            if (freq.ContainsKey(w)) {
                freq[w] = freq[w] += 1;
            } else
            {
                freq[w] = 1;
            }
        }
        return freq;
    }
}