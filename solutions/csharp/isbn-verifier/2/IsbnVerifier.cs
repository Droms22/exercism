using System;
using System.Text.RegularExpressions;
using System.Linq;

public static class IsbnVerifier
{
    const string pattern = "^\\d{1}-?\\d{3}-?\\d{5}-?[\\dX]{1}$";
    public static bool IsValid(string number) => Regex.IsMatch(number,pattern) && SumCheck(number);

    public static bool SumCheck(string number)
    {
        int sum = number.Where(c => Char.IsDigit(c) || c == 'X')
            .Select((x,i) => x == 'X' ? 10 * (10-i) : (int) Char.GetNumericValue(x) * (10-i)).Sum();
        return sum % 11 == 0;
    }
}