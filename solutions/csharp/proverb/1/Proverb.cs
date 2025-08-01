using System;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string[] proverb = new string[subjects.Length];
        for (int i=0; i < subjects.Length; i++) {
            if (i != subjects.Length - 1) {
                proverb[i] = $"For want of a {subjects[i]} the {subjects[i+1]} was lost.";
            } else {
                proverb[i] = $"And all for the want of a {subjects[0]}.";
            }
        }
        return proverb;
    }
}