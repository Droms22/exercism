using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    public static List<int> scores;
    
    public HighScores(List<int> list)
    {
        scores = list;
    }

    public List<int> Scores() => scores;

    public int Latest() => scores.Last();

    public int PersonalBest() => scores.OrderByDescending(s => s).First();

    public List<int> PersonalTopThree() => scores.OrderByDescending(s => s).Take(3).ToList();
}