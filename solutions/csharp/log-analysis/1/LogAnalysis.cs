using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimiter) {
        return str.Substring(str.IndexOf(delimiter)+delimiter.Length);
    }

    public static string SubstringBetween(this string str, string startDel, string endDel) {
         return str.Substring(str.IndexOf(startDel)+startDel.Length,str.IndexOf(endDel)- (str.IndexOf(startDel) + startDel.Length));
    }

    public static string Message(this string str) {
            return str.SubstringAfter(":").Trim();
    }

    public static string LogLevel(this string str) {
         return str.SubstringBetween("[","]");
    }
}