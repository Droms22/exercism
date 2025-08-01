using System;

static class AssemblyLine
{
    readonly static int baseProduction = 221;
    
    public static double SuccessRate(int speed)
    {
        switch (speed) {
            case 0:
                return 0;
            case int n when n <= 4:
                return 1;
            case int n when n >= 5 && n <= 8:
                return 0.9;
            case 9:
                return 0.8;
            case 10:
                return 0.77;
            default:
                return 0;
        }
    }
    
    public static double ProductionRatePerHour(int speed) => baseProduction * speed * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) =>  (int) ProductionRatePerHour(speed) / 60;
}
