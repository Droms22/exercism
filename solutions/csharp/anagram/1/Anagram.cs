using System;
using System.Collections.Generic;

public class Anagram
{
    private string _baseWord;
    private List<char> _charSet;
    
    public Anagram(string baseWord)
    {
        this._baseWord = baseWord;
        this._charSet = new List<char>();
        foreach (char c in baseWord) {
            _charSet.Add(c);
        }
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> matches = new List<string>();
        foreach (string candidate in potentialMatches) {
            if (isAnagram(candidate)) {
                matches.Add(candidate);
            }
        }
        return matches.ToArray();
    }

    public bool isAnagram(string candidate) {
        if (candidate.ToLower() == _baseWord.ToLower() || candidate.Length != _baseWord.Length) {
           return false; 
        } 
        List<char> charSetCopy = new List<char>();

        foreach (char c in _charSet) {
            charSetCopy.Add(Char.ToLower(c));
        }
        
        foreach (char c in candidate) {
            if (!charSetCopy.Remove(Char.ToLower(c))) {
                return false;
            }
        }
        return true;
    }
}