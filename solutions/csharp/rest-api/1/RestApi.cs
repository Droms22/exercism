using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

public class User
{
    [JsonProperty("name")]
    public string Name;

    [JsonProperty("owes")]
    public SortedDictionary<string, int> Owes = new();

    [JsonProperty("owed_by")]
    public SortedDictionary<string, int> OwedBy = new();  

    [JsonProperty("balance")]
    public int Balance => OwedBy.Values.Sum() - Owes.Values.Sum();
}

public class UsersPayload
{
    [JsonProperty("users")]
    public List<string> Users;
}

public class UserPayload
{
    [JsonProperty("user")]
    public string Name;
}

public class IOU
{
    [JsonProperty("lender")]
    public string Lender;

    [JsonProperty("borrower")]
    public string Borrower;

    [JsonProperty("amount")]
    public int Amount;
}

public class RestApi
{
    private List<User> _users;
    
    public RestApi(string database)
    {
        this._users = JsonConvert.DeserializeObject<List<User>>(database);
    }

    public string Get(string url, string payload = null)
    {
        return url switch
        {
                "/users" => GetUsers(payload),
                _ => throw new Exception()
        };
    }

    public string Post(string url, string payload)
    {
        return url switch
        {
                "/add" => AddUser(payload),
                "/iou" => AddIOU(payload),
                _ => throw new Exception()
        };
    }

    public string GetUsers(string payload)
    {
        if (payload is null)
            return JsonConvert.SerializeObject(_users.OrderBy(user => user.Name));

        var usersPayload = JsonConvert.DeserializeObject<UsersPayload>(payload);
        return JsonConvert.SerializeObject(_users.Where(user => usersPayload.Users.Contains(user.Name)));
    }

    public string AddUser(string payload)
    {
         if (payload is null)
             return string.Empty;

        UserPayload userPayload = JsonConvert.DeserializeObject<UserPayload>(payload);
        var newUser = new User(){ Name = userPayload.Name };
        _users.Add(newUser);
        return JsonConvert.SerializeObject(newUser);
    }

    public string AddIOU(string payload)
    {
         if (payload is null)
             return string.Empty;

        IOU iou = JsonConvert.DeserializeObject<IOU>(payload);
        _users.First(user => user.Name == iou.Borrower).Owes.Add(iou.Lender, iou.Amount);
        _users.First(user => user.Name == iou.Lender).OwedBy.Add(iou.Borrower, iou.Amount);

        UpdateOwes();
        
        return JsonConvert.SerializeObject(_users.Where(user => user.Name == iou.Borrower || user.Name == iou.Lender).OrderBy(user => user.Name));
    }

    private void UpdateOwes()
    {
        foreach (var user in _users)
        {
            var owesToResolve = user.Owes.Keys.Intersect(user.OwedBy.Keys).ToList();
            foreach (var owe in owesToResolve)
            {
                int owesAmount = user.Owes[owe];
                int owedByAmount = user.OwedBy[owe];

                if (owesAmount > owedByAmount)
                {
                    user.Owes[owe] = owesAmount - owedByAmount;
                    user.OwedBy.Remove(owe);
                }
                else if (owedByAmount > owesAmount)
                {
                    user.OwedBy[owe] = owedByAmount - owesAmount;
                    user.Owes.Remove(owe);
                }
                else 
                {
                    user.Owes.Remove(owe);
                    user.OwedBy.Remove(owe);
                }
            }
        }
    }
}
