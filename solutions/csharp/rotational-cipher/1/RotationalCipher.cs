using System;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        string result = "";
        foreach (char c in text) {
            result += Rotate(c,shiftKey);
        }
        return result;
    }

    public static char Rotate(char c, int shiftKey) {
        if (!Char.IsLetter(c)) return c;
        if (Char.IsUpper(c)) {
            return (char)((((int) c) + shiftKey) > 90 ? (((int) c) + shiftKey) - 26 : (((int) c) + shiftKey));
        } else {
            return (char)((((int) c) + shiftKey) > 122 ? (((int) c) + shiftKey) - 26 : (((int) c) + shiftKey));
        }
    }
}