using System;
using System.Collections.Generic;

public static class ResistorColorDuo
{
    private static Dictionary<string,string> band = new() {
        ["black"] = "0",
        ["brown"] = "1",
        ["red"] = "2",
        ["orange"] = "3",
        ["yellow"] = "4",
        ["green"] = "5",
        ["blue"] = "6",
        ["violet"] = "7",
        ["grey"] = "8",
        ["white"] = "9",
    };
    
    public static int Value(string[] colors)
    {
        return Convert.ToInt32(band[colors[0]] + band[colors[1]]);
    }
}
