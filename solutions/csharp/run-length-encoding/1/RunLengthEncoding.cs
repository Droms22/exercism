using System;
using System.Linq;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (String.IsNullOrEmpty(input)) return "";
        string encoded = "";
        int count = 0;
        for (int i=0; i < input.Length; i++) {
            if (i == 0 || input[i] == input[i-1]) count++;
            else {
                encoded += $"{(count > 1 ? count : "")}{input[i-1]}";
                count = 1;
            }
        }
        encoded += $"{(count > 1 ? count : "")}{input[input.Length-1]}";
        return encoded;
    }

    public static string Decode(string input)
    {
        if (String.IsNullOrEmpty(input)) return "";
        string decoded = "";
        string count = "0";
        for (int i=0; i < input.Length; i++) {
            if (int.TryParse(""+input[i], out _)) {
                count += input[i];
            } else {
                decoded += String.Concat(
                    Enumerable.Repeat(input[i],(
                        (count == "0" ? 1 : Convert.ToInt32(count))
                    )));
                count = "0";
            }
        }
        return decoded;
    }
}
