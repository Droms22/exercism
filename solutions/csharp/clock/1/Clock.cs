using System;

public class Clock
{
    private TimeSpan time;
    
    public Clock(int hours, int minutes)
    {
        this.time = new(hours, minutes, 0);
        this.Normalize();
    }

    public Clock Add(int minutesToAdd)
    {
        var clock = new Clock(0,0);
        clock.time = new TimeSpan(this.time.Hours, this.time.Minutes + minutesToAdd, 0);
        clock.Normalize();
        return clock;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        var clock = new Clock(0,0);
        clock.time = new TimeSpan(this.time.Hours, this.time.Minutes - minutesToSubtract, 0);
        clock.Normalize();
        return clock;
    }

    public override string ToString()
    {
        return $"{time.Hours:D2}:{time.Minutes:D2}";
    }

    public void Normalize()
    {
        while (this.time < TimeSpan.Zero)
        {
            this.time += TimeSpan.FromDays(1);
        }
    }

    public override bool Equals(Object obj)
    {
        var clock = obj as Clock;
        return this.time.Hours == clock.time.Hours && this.time.Minutes == clock.time.Minutes; 
    }
}
