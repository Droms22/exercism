using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        Regex rg = new Regex(@"\p{IsGreekandCoptic}");
        StringBuilder builder = new StringBuilder();
        bool isKebab = false;
        foreach (char c in identifier) {
            if (c == ' ') {
                builder.Append(c);
                continue;
            }
            if (rg.IsMatch(""+c) && c == Char.ToLower(c)) continue;
            if (c == '-') {
                isKebab = true;
                continue;
            }
            if (Char.IsControl(c)) {
                builder.Append("CTRL");
                continue;
            }
            if (!Char.IsLetter(c)) continue;
            if (isKebab) {
                builder.Append(Char.ToUpper(c));
                isKebab = false;
            } else {
                builder.Append(c);
            }
        }
        return builder.Replace(' ','_').ToString();
    }
}
