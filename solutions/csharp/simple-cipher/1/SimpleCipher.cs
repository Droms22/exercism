using System;
using System.Linq;
using System.Text;

public class SimpleCipher
{
    private Random _random;
    private string _key;
    
    public SimpleCipher()
    {
        _random = new Random();
        _key = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 128)
                                .Select(s => s[_random.Next(s.Length)])
                                .ToArray());
    }

    public SimpleCipher(string key)
    {
        _key = key;
    }
    
    public string Key 
    {
        get
        {
            return _key;
        }
    }

    public string Encode(string plaintext)
    {
        var builder = new StringBuilder();
        for (int i = 0; i < plaintext.Length; i++) 
        {
            int shift = _key[i % _key.Length] - 'a';
            char encoded = (char)(plaintext[i] + shift);

            if ((int)encoded > 122)
            {
                encoded = (char)(encoded - 26);
            }
            
            builder.Append(encoded);
        }
        return builder.ToString();
    }

    public string Decode(string ciphertext)
    {
        var builder = new StringBuilder();
        for (int i = 0; i < ciphertext.Length; i++) 
        {
            int shift = _key[i % _key.Length] - 'a';
            char decoded = (char)(ciphertext[i] - shift);

            if ((int)decoded < 97)
            {
                decoded = (char)(decoded + 26);
            }
            
            builder.Append(decoded);
        }
        return builder.ToString();
    }
}