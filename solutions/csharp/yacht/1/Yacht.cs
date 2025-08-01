using System;
using System.Linq;
using System.Collections.Generic;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        int score = category switch
        {
            YachtCategory.Ones => dice.Where(d => d == 1).Sum(),
            YachtCategory.Twos => dice.Where(d => d == 2).Sum(),
            YachtCategory.Threes => dice.Where(d => d == 3).Sum(),
            YachtCategory.Fours => dice.Where(d => d == 4).Sum(),
            YachtCategory.Fives => dice.Where(d => d == 5).Sum(),
            YachtCategory.Sixes => dice.Where(d => d == 6).Sum(),
            YachtCategory.FullHouse => (dice.Any(d => dice.Where(d1 => d1 == d).Count() == 3) && dice.Any(d => dice.Where(d1 => d1 == d).Count() == 2)) ? dice.Sum() : 0,
            YachtCategory.FourOfAKind => dice.Any(d => dice.Where(d1 => d1 == d).Count() >= 4) ? dice.Where(d => dice.Where(d1 => d1 == d).Count() >= 4).First() * 4 : 0,
            YachtCategory.LittleStraight => dice.OrderBy(d => d).SequenceEqual(new int[]{1,2,3,4,5}) ? 30 : 0,
            YachtCategory.BigStraight => dice.OrderBy(d => d).SequenceEqual(new int[]{2,3,4,5,6}) ? 30 : 0,
            YachtCategory.Choice => dice.Sum(),
            YachtCategory.Yacht => dice.Distinct().Count() == 1 ? 50 : 0,
            _ => 0
        };
        return score;
    }
}

