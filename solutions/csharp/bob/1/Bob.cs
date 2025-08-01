using System;

public static class Bob
{
    public static string Response(string s)
    {
        s = s.TrimEnd();
        if (string.IsNullOrWhiteSpace(s)) return "Fine. Be that way!";
        bool isYelling = (s == s.ToUpper() && s != s.ToLower()) ? true : false;
        bool isQuestion = s[s.Length-1] == '?' ? true : false;
        if (isQuestion && isYelling) return "Calm down, I know what I'm doing!";
        if (isYelling) return "Whoa, chill out!";
        if (isQuestion) return "Sure.";
        return "Whatever.";
    }
}