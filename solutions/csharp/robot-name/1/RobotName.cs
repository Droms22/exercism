using System;
using System.Collections.Generic;

public class Robot
{
    private string _name;
    private static HashSet<string> usedNames = new HashSet<string>();
    private Random _random = new Random();

    public Robot() {
        this._name = generateName();
    }
    
    public string Name
    {
        get
        {
            return _name;
        }
    }

    public void Reset()
    {
        this._name = generateName();    
    }

    private string generateName() {
        string name;
        do {
            name = "";
            name += (char) _random.Next(65,91);
            name += (char) _random.Next(65,91);
            name += _random.Next(0,10);
            name += _random.Next(0,10);
            name += _random.Next(0,10);
        } while (!usedNames.Add(name));
        return name;
    }
    
}