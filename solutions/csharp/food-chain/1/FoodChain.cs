using System;
using System.Text;
using System.Collections.Generic;

public static class FoodChain
{
    public static StringBuilder s = new StringBuilder();
    public static List<string> animals = new List<string>(){"fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse"};
    public static Dictionary<string,string> animalVerses = new Dictionary<string,string>()
    {
        {"spider", "It wriggled and jiggled and tickled inside her."},
        {"bird", "How absurd to swallow a bird!"},
        {"cat", "Imagine that, to swallow a cat!"},
        {"dog", "What a hog, to swallow a dog!"},
        {"goat", "Just opened her throat and swallowed a goat!"},
        {"cow", "I don't know how she swallowed a cow!"},
        {"horse", "She's dead, of course!"}
    };
    
    public static string Recite(int n)
    {
        s.Clear();
        s.Append($"I know an old lady who swallowed a {animals[n-1]}.\n");

        if (n == 8) {
            s.Append(animalVerses[animals[n-1]]);
            return s.ToString();
        } else if (n != 1) {
            s.Append(animalVerses[animals[n-1]] + "\n");
        }
        while (n > 1)
        {
            if (n != 3) {
                s.Append($"She swallowed the {animals[n-1]} to catch the {animals[n-2]}.\n");
            } else {
                s.Append("She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n");
            }
            n--;
        }
        s.Append("I don't know why she swallowed the fly. Perhaps she'll die."); 
        return s.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        string result = string.Empty;
        for (int i = startVerse; i <= endVerse; i++) {
            result += Recite(i);
            if (i != endVerse) {
                result += "\n\n";
            }
        }
        return result;
    }
}