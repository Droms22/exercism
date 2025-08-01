using System;
using System.Numerics;

public static class DiffieHellman
{
    private static readonly Random random = new Random();
    
    public static BigInteger PrivateKey(BigInteger primeP) 
    {
        return random.Next(2,(int) primeP);
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) 
    {
        return (BigInteger) (Math.Pow((double)primeG,(double)privateKey) % (double) primeP);
    }

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) 
    {
        return (BigInteger) (Math.Pow((double) publicKey, (double) privateKey) % (double) primeP);
    }
}