using System;

class RemoteControlCar
{
    private int _distance;
    private int _battery;

    public RemoteControlCar() {
        _distance = 0;
        _battery = 100;
    }

    public int Distance {
        get { return _distance; }
        set { _distance = value; }
    }

    public int Battery {
        get { return _battery; }
        set { _battery = value; }
    }
    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {this.Distance} meters";
    }

    public string BatteryDisplay()
    {
        return this.Battery > 0 ? $"Battery at {this.Battery}%" : "Battery empty";
    }

    public void Drive()
    {
        if (this.Battery > 0) {
            this.Distance += 20;
            this.Battery -= 1;
        }
    }
}
