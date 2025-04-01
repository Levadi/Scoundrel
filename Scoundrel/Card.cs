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
    protected void selfDestruct()
    {
        Room.removeCard(this);
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
        Hand.takeDamage(this);
        selfDestruct();
    }
}

public class Heart : Card
{
    public Heart(int value)
    {
        this.value = value;
        suit = 2;
        setName();
        setSuit();
    }

    public override void playCard()
    {
        Console.WriteLine($"You play the {faceName} of {suitName}.");
        if (Hand.healed) 
        {
            Console.WriteLine("You have already healed in this room. The card will be discarded.");
            selfDestruct();
            return;
        }
        Hand.healed = true;
        Hand.health += value;
        if (Hand.health > 20) Hand.health = 20;
        Console.WriteLine($"Healed to {Hand.health} health.");
        selfDestruct();
    }
}

public class Diamond : Card
{
    public Diamond(int value)
    {
        this.value = value;
        suit = 3;
        setName();
        setSuit();
    }

    public override void playCard()
    {
        Hand.equippedWeapon = this;
        Hand.weaponStack.Clear();
        Console.WriteLine($"Equipped {faceName} of {suitName}.");
        selfDestruct();
    }
}