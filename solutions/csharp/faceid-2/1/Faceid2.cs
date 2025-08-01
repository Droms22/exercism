using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(Object obj)
    {
        FacialFeatures facialFeature = (FacialFeatures) obj;
        return (this.EyeColor == facialFeature.EyeColor && this.PhiltrumWidth == facialFeature.PhiltrumWidth) ? true : false;
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(Object obj)
    {
        Identity identity = (Identity) obj;
        return (this.Email == identity.Email && this.FacialFeatures.EyeColor == identity.FacialFeatures.EyeColor && this.FacialFeatures.PhiltrumWidth == identity.FacialFeatures.PhiltrumWidth) ? true : false;
    }

    public override int GetHashCode()
    {
        return Email.GetHashCode() ^ FacialFeatures.GetHashCode();
    }
}

public class Authenticator
{
    public static Identity admin = new("admin@exerc.ism",new FacialFeatures("green",0.9m));
    public List<Identity> users = new(); 
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => admin.Equals(identity);

    public bool Register(Identity identity)
    {
        if (!users.Contains(identity))
        {
            users.Add(identity);
            return true;
        }
        return false;
    }

    public bool IsRegistered(Identity identity) => users.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA.Equals(identityB) && identityA.GetHashCode() == identityB.GetHashCode();
}
