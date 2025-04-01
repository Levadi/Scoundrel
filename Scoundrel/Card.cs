using System;
namespace Scoundrel;

public abstract class Card
{

    protected List<string> cardNames = new List<string>()
    {
        "Two",
        "Three",
        "Four",
        "Five",
        "Six",
        "Seven",
        "Eight",
        "Nine",
        "Ten",
        "Jack",
        "Queen",
        "King",
        "Ace"
    };

    protected List<string> suits = new List<string>()
    {
        "Clubs",
        "Spades",
        "Hearts",
        "Diamonds"
    };

    public int value { get; set; }
    public int suit { get; set; }
    public string faceName { get; set; } = "";
    public string suitName { get; set; } = "";

    protected void setName()
    {
        faceName = cardNames[value - 2];
    }
    protected void setSuit()
    {
        suitName = suits[suit];
    }

    public abstract void playCard();
}

public class Black : Card
{
    public Black(int value, int suit)
    {
        this.value = value;
        this.suit = suit;
        setName();
        setSuit();
    }

    public override void playCard()
    {
        Console.WriteLine($"You fight the {faceName} of {suitName}.");
        Hand.takeDamage(value);
        Hand.weaponStack.Push(this);
        Console.WriteLine($"{faceName} is now the highest value card you can use your weapon against.");
    }
}

public class Heart : Card
{
    public Heart(int value)
    {
        this.value = value;
        this.suit = 2;
        setName();
        setSuit();
    }

    public override void playCard()
    {
        Console.WriteLine($"You play the {faceName} of {suitName}.");
        if (Hand.healed) 
        {
            Console.WriteLine("You have already healed in this room. The card will be discarded.");
            return;
        }
        Hand.healed = true;
        Hand.health += value;
        if (Hand.health > 20) Hand.health = 20;
        Console.WriteLine($"Healed to {Hand.health} health.");
    }
}

public class Diamond : Card
{
    public Diamond(int value)
    {
        this.value = value;
        this.suit = 3;
        setName();
        setSuit();
    }

    public override void playCard()
    {
        Hand.equippedWeapon = this;
        Hand.weaponStack.Clear();
        Console.WriteLine($"Equipped {faceName} of {suitName}.");
    }
}