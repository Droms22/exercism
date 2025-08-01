using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        Console.WriteLine( string.Format("{0, -29} ♡ {1, -29}", studentA, studentB));
        return string.Format("{0, 29} ♡ {1, -29}", studentA, studentB);
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return  
        $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA.Trim()}  +  {studentB.Trim()}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
        ";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        var germanCulture = new CultureInfo("de-DE");
        var germanDate = start.ToString("dd.MM.yyyy", germanCulture);
        var germanFloat = hours.ToString("N2", germanCulture);
        return $"{studentA} and {studentB} have been dating since {germanDate} - that's {germanFloat} hours";
    }
}
