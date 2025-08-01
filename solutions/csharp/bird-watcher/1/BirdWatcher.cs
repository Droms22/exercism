using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] {0,2,5,3,7,8,4};
    }

    public int Today()
    {
        return birdsPerDay.Last();
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length-1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int birds in birdsPerDay) {
            if (birds == 0) return true;
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int tot = 0;
        for (int i=0; i < numberOfDays; i++) {
            tot += birdsPerDay[i];
        }
        return tot;
    }

    public int BusyDays()
    {
        int count = 0; 
        foreach (int birds in birdsPerDay) {
            if (birds >= 5) count++;
        }
        return count;
    }
}
