using System;

// TODO: define the 'AccountType' enum
[Flags]
enum AccountType : byte
{
    Guest = 0b00000001,
    User = 0b00000011,
    Moderator = 0b00000111
}

// TODO: define the 'Permission' enum
[Flags]
enum Permission : byte
{
    Read = 0b00000001,
    Write = 0b00000010,
    Delete = 0b00000100,
    All = 0b00000111,
    None = 0b00000000
}


static class Permissions
{
    public static Permission Default(AccountType accountType) => !Enum.IsDefined(typeof(AccountType), accountType) ? Permission.None : (Permission)Enum.ToObject(typeof(Permission), accountType);
        
    public static Permission Grant(Permission current, Permission grant) => current = current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => current = current &= ~revoke;

    public static bool Check(Permission current, Permission check) => current.HasFlag(check);
}
