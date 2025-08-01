using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        double distance = Math.Pow((x*x)+(y*y),0.5);
        switch (distance) {
            case >10:
                return 0;
            case >5:
                return 1;
            case >1:
                return 5;
            case <=1:
                return 10;
            default:
                return 0;
        }
    }
}
