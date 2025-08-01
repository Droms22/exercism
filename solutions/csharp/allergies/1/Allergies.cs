using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private List<Allergen> _allergens;
    
    public Allergies(int mask)
    {
        _allergens = new();

        for (int i = 0; i < 8; i++)
        {
            if ((mask & (int)Math.Pow(2, i)) != 0)
            {
                mask -= (int)Math.Pow(2, i);
                switch (i)
                {
                    case 7:
                        _allergens.Add(Allergen.Cats);
                        break;
                    case 6:
                        _allergens.Add(Allergen.Pollen);
                        break;
                    case 5:
                        _allergens.Add(Allergen.Chocolate);
                        break;
                    case 4:
                        _allergens.Add(Allergen.Tomatoes);
                        break;
                    case 3:
                        _allergens.Add(Allergen.Strawberries);
                        break;
                    case 2:
                        _allergens.Add(Allergen.Shellfish);
                        break;
                    case 1:
                        _allergens.Add(Allergen.Peanuts);
                        break;
                    case 0:
                        _allergens.Add(Allergen.Eggs);
                        break;
                }
            }
        }
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return _allergens.Contains(allergen);
    }

    public Allergen[] List()
    {
        return _allergens.ToArray();
    }
}