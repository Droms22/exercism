using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber, (double)r.Numerator / r.Denominator);
    }
}

public struct RationalNumber
{
    public int Numerator;
    public int Denominator;
    
    public RationalNumber(int numerator, int denominator)
    {
        Console.WriteLine($"Numerator: {numerator} Denominator: {denominator}");
        this.Numerator = numerator;
        this.Denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Denominator + r1.Denominator * r2.Numerator;
        int denominator = numerator == 0 ? 1 : Math.Abs(r2.Numerator * r2.Denominator);

        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Denominator - r1.Denominator * r2.Numerator;
        int denominator = numerator == 0 ? 1 : Math.Abs(r2.Numerator * r2.Denominator);
        
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Denominator;
        int denominator = r1.Denominator * r2.Numerator;

        if (denominator < 0) {
            numerator = -numerator;
            denominator = -denominator;
        }

        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(this.Numerator), Math.Abs(this.Denominator)).Reduce();
    }

    public RationalNumber Reduce()
    {
        int MCD(int a, int b) => b == 0 ? Math.Abs(a) : MCD(b, a % b);
        int mcd = MCD(this.Numerator, this.Denominator);

        int numerator = this.Numerator / mcd;
        int denominator = this.Denominator / mcd;

        if (denominator < 0) {
            numerator = -numerator;
            denominator = -denominator;
        }
        
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Exprational(int power)
    {
        if (power == 0)
        {
            return new RationalNumber(1, 1);
        }
    
        int numerator = (int)Math.Pow(this.Numerator, Math.Abs(power));
        int denominator = (int)Math.Pow(this.Denominator, Math.Abs(power));
    
        if (power < 0)
        {
            if (power % 2 != 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
            return new RationalNumber(denominator, numerator);
        }
    
        // Se la potenza è positiva, restituiamo normalmente
        return new RationalNumber(numerator, denominator);
    }


    public double Expreal(int baseNumber)
    {
        return 0;
    }
}