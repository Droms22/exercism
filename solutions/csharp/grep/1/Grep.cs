using System;
using System.IO;
using System.Text;

public static class Grep
{   
    public static string Match(string pattern, string flags, string[] files)
    {
        var builder = new StringBuilder();
        var isMatch = GetMatchFunc(pattern, flags);
        
        foreach (var file in files) {
            string[] lines = File.ReadAllLines(file);

            //Only file names flag
            if (flags.Contains("-l")) {
                foreach (var line in lines) {
                    if (isMatch(line)) {
                        builder.AppendLine(file);
                        break;
                    }
                }
            } else {
                for (int i = 0; i < lines.Length; i++) {
                    if (isMatch(lines[i])) {
                        //Prepend file name if there are multiple files
                        if (files.Length > 1) {
                            builder.Append($"{file}:");
                        }
                        
                        //Line number flag
                        if (flags.Contains("-n")) {
                            builder.Append($"{i+1}:");
                        }
                        
                        builder.AppendLine(lines[i]);
                    }
                }
            }
        }

        //Remove last line terminator
        if (builder.Length != 0) {
            builder.Remove(builder.Length - 1, 1);
        }
        
        return builder.ToString();
    }
    
    public static Func<string, bool> GetMatchFunc(string pattern, string flags) {
        //Base func
        Func<string, bool> match = line => line.Contains(pattern);
        
        //Entire line flag
        if (flags.Contains("-x")) {
            var previous = match;
            match = line => previous(line) && line == pattern;
        }
        
        //Case insensitive flag
        if (flags.Contains("-i")) {
            match = line => flags.Contains("-x") ? line.ToLower() == pattern.ToLower() : line.ToLower().Contains(pattern.ToLower());
        }

        //Invert match flag
        if (flags.Contains("-v")) {
            var previous = match;
            match = line => !previous(line);
        }

        return match;
    }
}