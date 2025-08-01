using System;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        if (number.Length <= 1) return false;
        number = number.Replace(" ",string.Empty);
        bool first = true;
        int tot = 0;
        int zeroCount = 0;
        for (int i = number.Length-1; i > -1; i--) {
            if (!Char.IsDigit(number[i])) return false;
            int digit = int.Parse(number[i].ToString());
            if (digit == 0) zeroCount++;
            if (first) {
                first = false;
                tot += digit;
            } else {
                first = true;
                tot += digit*2 < 9 ? digit*2 : digit*2 - 9;
            }
        }
        if (tot == 0 && zeroCount == 1) return false;
        return tot % 10 == 0 ? true : false;
    }
}