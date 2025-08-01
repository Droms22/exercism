using System;
using System.Linq;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        int length = phoneNumber.Where(c => Char.IsDigit(c)).Count();
        string cleaned = String.Join("",phoneNumber.Where(c => Char.IsDigit(c)).ToList());
        //check letters
        if (hasLetters(phoneNumber)) throw new ArgumentException();
        //check length
        if (length != 10)
        {
            //check length constrain
            if (length < 10 || cleaned[0] != '1') throw new ArgumentException();
            //truncate first 1
            cleaned = cleaned.Substring(1);
        }
        //check N digits 
        if (Char.GetNumericValue(cleaned[0]) < 2 || Char.GetNumericValue(cleaned[3]) < 2) throw new ArgumentException();
        return cleaned;
    }

    public static bool hasLetters(string s) => s.Where(c => Char.IsLetter(c)).Count() > 0;
    
}