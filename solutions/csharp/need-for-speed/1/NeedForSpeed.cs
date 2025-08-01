using System;

class RemoteControlCar
{
    private int _speed;
    private int _battery;
    private int _distanceDriven;
    private int _batteryDrain;
    
    public RemoteControlCar(int speed, int batteryDrain) {
        this._speed = speed;
        this._battery = 100;
        this._batteryDrain = batteryDrain;
        this._distanceDriven = 0;
    }

    public bool BatteryDrained()
    {
        return this._battery == 0 || (this._battery < this._batteryDrain);
    }

    public int DistanceDriven()
    {
        return this._distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained()) {
            this._distanceDriven += this._speed;
            this._battery -= this._batteryDrain;
        } 
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50,4);
    }
}

class RaceTrack
{
    private int _distance;
    
    public RaceTrack(int distance) {
        this._distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained()) {
            car.Drive();
        }
        return car.DistanceDriven() >= this._distance;
    }
}
