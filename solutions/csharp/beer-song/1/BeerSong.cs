using System;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var initialStart = startBottles;
        var song = string.Empty;

        while (takeDown != 0)
        {
            if (startBottles == 0)
            {
                song += "No more bottles of beer on the wall, no more bottles of beer.\n";
                song += $"Go to the store and buy some more, 99 bottles of beer on the wall.";
                return song;
            }
            song += GetFirstVerse(startBottles, takeDown);
            startBottles--;
            song += GetSecondVerse(startBottles, takeDown);
            
            takeDown--;
            if(takeDown != 0)
            {
                song += "\n";
            }
        }
        return song;
    }

    public static string GetFirstVerse(int start, int takeDown)
    {
        if (start == 1)
        {
            return $"{start} bottle of beer on the wall, {start} bottle of beer.\n";
        }
        if (start == 0)
        {
            return "No more bottles of beer on the wall, no more bottles of beer.\n";
        }
        return $"{start} bottles of beer on the wall, {start} bottles of beer.\n";
    }

    public static string GetSecondVerse(int start, int takeDown)
    {
        if (start == 1)
        {
            return takeDown == 1 ?
                $"Take one down and pass it around, {start} bottle of beer on the wall." :
                $"Take one down and pass it around, {start} bottle of beer on the wall.\n";
        }
        if (start == 0)
        {
            return takeDown == 1 ?
                $"Take it down and pass it around, no more bottles of beer on the wall." :
                $"Take it down and pass it around, no more bottles of beer on the wall.\n";
        }
        return takeDown == 1 ?
           $"Take one down and pass it around, {start} bottles of beer on the wall." :
            $"Take one down and pass it around, {start} bottles of beer on the wall.\n";
    }
}