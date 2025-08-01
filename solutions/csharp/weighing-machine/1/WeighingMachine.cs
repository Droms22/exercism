using System;
using System.Collections.Generic;
using System.Linq;

class WeighingMachine
{
    public double _weight;
    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }
    // TODO: define the 'Precision' property
    public int Precision { get; private set; }
    // TODO: define the 'Weight' property
    public double Weight
    {
        get { return _weight; }
        set {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            _weight = value;
        }
    }
    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get {
            string format = $"F{Precision}";
            return (_weight - TareAdjustment).ToString(format) + " kg";
        } 
    }
    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set;} = 5.0;
}
