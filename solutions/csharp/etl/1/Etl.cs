using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string,int> newDict = new(); 
        foreach (var item in old) {
            int point = item.Key;
            foreach (string letter in item.Value) {
                newDict.Add(letter.ToLower(),point);
            }
        }
        return newDict;
    }
}