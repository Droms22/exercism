using System;
using System.Linq;
using System.Collections.Generic;

public class CustomSet
{
    private List<int> _values;

    public override bool Equals(Object obj)
    {
        var customSet = obj as CustomSet;
        return this._values.All(v => customSet.Contains(v)) && this._values.Count == customSet._values.Count;
    }
    
    public CustomSet(params int[] values)
    {
        _values = new(values);
    }

    public CustomSet Add(int value)
    {
        if (!_values.Any(v => v == value))
        {
            _values.Add(value);
        }
        return this;
    }

    public bool Empty()
    {
        return _values.Count == 0;
    }

    public bool Contains(int value)
    {
        return _values.Any(v => v == value);
    }

    public bool Subset(CustomSet right)
    {
        foreach (var value in this._values)
        {
            if (!right._values.Any(v => v == value))
            {
                return false;
            }
        }
        return true;
    }

    public bool Disjoint(CustomSet right)
    {
        return right._values.Count == 0 || this._values.All(v => !right._values.Contains(v));
    }

    public CustomSet Intersection(CustomSet right)
    {
        CustomSet result = new();
        List<int> common = new();

        foreach (var value in this._values)
        {
            if (right.Contains(value))
            {
                common.Add(value);
            }
        }
        
        result._values = common;
        return result;
    }

    public CustomSet Difference(CustomSet right)
    {
        CustomSet result = new();
        result._values = this._values.Where(v => !right.Contains(v)).ToList(); 
        return result;
    }

    public CustomSet Union(CustomSet right)
    {
        foreach (var value in right._values)
        {
            if (!this._values.Contains(value))
            {
                this._values.Add(value);
            }
        }
        return this;
    }
}