using System;
namespace Scoundrel;

public static class Hand
{
    public static int health { get; set; } = 20;
    public static bool healed { get; set; } = false;
    public static Stack<Black> weaponStack = new Stack<Black>();
    public static Diamond? equippedWeapon { get; set; }

    public static bool checkWeaponValidity(int damage)
    {
        if (weaponStack.Count() > 0) return weaponStack.Peek().value >= damage;
        return true;    
    }
    
    public static void checkHealth()
    {
        if (health < 0) 
        {
            Console.WriteLine("You are dead! Press any key to exit."); 
            Console.Read();
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine($"Your health is now {health}.");
        }
    }

    public static void takeDamage(Black card)
    {
        string? input = "1";
        if (equippedWeapon != null && checkWeaponValidity(card.value))
        {
            Console.WriteLine("Press any key to use your weapon, or 1 to use your hands.");
            input = Console.ReadLine();
        } else {
            Console.WriteLine("You don't have a weapon that can be used against this card. Using hands.");
        }
        if (input == "1")
        {
            
            Console.WriteLine($"You took {card.value} damage.");
            health -= card.value;
            checkHealth();
            return;
        }
        int reducedDamage = (card.value - equippedWeapon.value) < 0 ? 0 : card.value - equippedWeapon.value;
        health -= reducedDamage;
        Console.WriteLine($"You took {reducedDamage} damage.");
        weaponStack.Push(card);
        Console.WriteLine($"{card.faceName} is now the highest value card you can use your weapon against.");
        checkHealth();
    }
}