using System;
using System.Linq;
using System.Reflection;

public class DndCharacter
{
    private static Random random;
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public DndCharacter()
    {
        random = new Random();
        Strength = ThrowDices();
        Dexterity = ThrowDices();
        Constitution = ThrowDices();
        Intelligence = ThrowDices();
        Wisdom = ThrowDices();
        Charisma = ThrowDices();
        Hitpoints = 10 + Modifier(Constitution);
    }
    
    public static int Modifier(int score)
    {
        return (int)Math.Floor((double)(score - 10) / 2);
    }

    public static int Ability() 
    {
        return ThrowDices();
    }

    public static DndCharacter Generate()
    {   
        return new DndCharacter();        
    }

    private static int ThrowDices()
    {
        var dices = Enumerable.Range(0, 4).Select(_ => random.Next(1, 7)).ToList();
        var min = dices.Min();
        dices.Remove(min);
        return dices.Sum();
    }
}
