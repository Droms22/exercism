using System;
using System.Collections.Generic;

public class Authenticator
{
    // TODO: Implement the Authenticator.Admin property
    public Identity Admin 
    { 
        get {
            var identity = new Identity{Email="admin@ex.ism"};
            identity.FacialFeatures = new FacialFeatures{EyeColor="green",PhiltrumWidth=0.9m}; 
            identity.NameAndAddress = new List<string>{"Chanakya", "Mumbai", "India"};
            return identity;
        }
    }

    // TODO: Implement the Authenticator.Developers property
    public IDictionary<string, Identity> Developers 
    { 
        get {
            var identity = new Identity{Email="bert@ex.ism"};
            identity.FacialFeatures = new FacialFeatures{EyeColor="blue",PhiltrumWidth=0.8m}; 
            identity.NameAndAddress = new List<string>{"Bertrand", "Paris", "France"};

            var identity2 = new Identity{Email="anders@ex.ism"};
            identity2.FacialFeatures = new FacialFeatures{EyeColor="brown",PhiltrumWidth=0.85m}; 
            identity2.NameAndAddress = new List<string>{"Anders", "Redmond", "USA"};
            
            return new Dictionary<string,Identity>{{"Bertrand",identity}, {"Anders",identity2}};
        }
    }
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public string EyeColor { get; set; }
    public decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public string Email { get; set; }
    public FacialFeatures FacialFeatures { get; set; }
    public IList<string> NameAndAddress { get; set; }
}
