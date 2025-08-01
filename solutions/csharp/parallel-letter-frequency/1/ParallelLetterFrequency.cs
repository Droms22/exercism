using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        ConcurrentDictionary<char,int> freq = new();
        foreach(string text in texts) {
            if (String.IsNullOrWhiteSpace(text)) continue;
            string clear = new string(text.Where(c => Char.IsLetter(c)).ToArray());
            Parallel.ForEach(clear.ToLower(), c => {
                freq.AddOrUpdate(c,1, (k,v) => v += 1);
            });
        }
        return new Dictionary<char,int>(freq);
    }
}