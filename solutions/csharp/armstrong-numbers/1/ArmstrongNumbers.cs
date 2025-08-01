using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int total = 0;
        foreach (var digit in number.ToString())
        {
            int d = (int) Char.GetNumericValue(digit);
            total += (int) Math.Pow(d,number.ToString().Length);
        }
        return total == number;
    }
}