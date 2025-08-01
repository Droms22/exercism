using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool hasSameCurrency(CurrencyAmount a, CurrencyAmount b) => a.currency == b.currency ;
    
    // TODO: implement equality operators
    public static bool operator == (CurrencyAmount a, CurrencyAmount b)
    {
        if (!hasSameCurrency(a,b))
            throw new ArgumentException();
        return a.amount == b.amount;
    }

    public static bool operator != (CurrencyAmount a, CurrencyAmount b) => !(a == b);

    // TODO: implement comparison operators
    public static bool operator > (CurrencyAmount a, CurrencyAmount b)
    {
        if (!hasSameCurrency(a, b))
            throw new ArgumentException();
        return a.amount > b.amount;
    }

    public static bool operator < (CurrencyAmount a, CurrencyAmount b) => !(a > b);

    // TODO: implement arithmetic operators
    public static decimal operator + (CurrencyAmount a, CurrencyAmount b)
    {
        if (!hasSameCurrency(a, b))
            throw new ArgumentException();
        return a.amount + b.amount;        
    }
    public static decimal operator - (CurrencyAmount a, CurrencyAmount b)
    {
        if (!hasSameCurrency(a, b))
            throw new ArgumentException();
        return a.amount - b.amount;        
    }
    public static decimal operator * (CurrencyAmount a, CurrencyAmount b)
    {
        if (!hasSameCurrency(a, b))
            throw new ArgumentException();
        return a.amount * b.amount;        
    }
    public static decimal operator / (CurrencyAmount a, CurrencyAmount b)
    {
        if (!hasSameCurrency(a, b))
            throw new ArgumentException();
        return a.amount / b.amount;        
    }

    // TODO: implement type conversion operators
    public static implicit operator double (CurrencyAmount c) => (double) c.amount;
    public static implicit operator decimal (CurrencyAmount c) => (decimal) c.amount;
}
