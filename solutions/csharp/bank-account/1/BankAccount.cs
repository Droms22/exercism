using System;

public class BankAccount
{
    public bool status;
    public decimal balance;
    public static object balanceLock = new();
    
    public void Open()
    {
        status = true;
        balance = 0m;
    }

    public void Close()
    {
        if (status = false) throw new InvalidOperationException();
        status = false;
    }

    public decimal Balance
    {
        get
        {
            return status == true ? balance : throw new InvalidOperationException();
        }
    }

    public void UpdateBalance(decimal change)
    {
        lock (balanceLock)
        {
            balance += change;
        }
    }
}
