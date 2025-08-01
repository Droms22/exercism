using System;
using System.Collections.Generic;

public static class Wordy
{
    public static int Answer(string question)
    {
         List<string> exp = new();   
        foreach (string word in question.Substring(0,question.Length-1).Split(' '))
        {
            if (int.TryParse(word, out _))
            {
                exp.Add(word);
            } else 
            {
                switch (word)
                {
                    case "plus":
                        exp.Add("+");
                        break;
                    case "minus":
                        exp.Add("-");
                        break;
                    case "multiplied":
                        exp.Add("*");
                        break;
                    case "divided":
                        exp.Add("/");
                        break;
                    case "What":
                    case "is":
                    case "by":
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            Console.WriteLine($"exp: {String.Join("",exp)}");
            if (exp.Count == 3)
            {
                if (!(int.TryParse(exp[0],out _) && int.TryParse(exp[2], out _)))
                {
                    throw new ArgumentException();
                }
                string tmp = String.Join("",exp);
                Console.WriteLine($"exp: {exp[0]}{exp[1]}{exp[2]} evaluated in: {Eval(tmp)}");
                exp.Clear();
                exp.Add(Eval(tmp).ToString());
            }
        }
        if (exp.Count != 1) throw new ArgumentException();
        return int.Parse(exp[0]);
    }

    static Double Eval(String expression)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        return Convert.ToDouble(table.Compute(expression, String.Empty));
    }
}