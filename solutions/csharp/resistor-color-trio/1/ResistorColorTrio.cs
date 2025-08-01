using System;
using System.Collections.Generic;

public static class ResistorColorTrio
{
    private static Dictionary<string, int> values = new(){
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6},
        {"violet", 7},
        {"grey", 8},
        {"white", 9}
    };
    
    public static string Label(string[] colors)
    {
        int ohms = 0;
        ohms = values[colors[0]];
        ohms = int.Parse($"{ohms}{values[colors[1]]}");
        for (int i = 0; i < values[colors[2]]; i++)
        {
            ohms = int.Parse($"{ohms}0");
        }
        
        if (ohms > 1000)
            return $"{ohms / 1000} kiloohms";
        return $"{ohms} ohms";
    }
}
