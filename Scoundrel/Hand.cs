using System;
namespace Scoundrel;

public static class Hand
{
    public static int health { get; set; } = 20;
    public static bool healed { get; set; } = false;
    public static Stack<Black> weaponStack = new Stack<Black>();
    public static Diamond equippedWeapon { get; set; }

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

    public static void takeDamage(int damage)
    {
        string input = "1";
        if (equippedWeapon != null && checkWeaponValidity(damage))
        {
            Console.WriteLine("Press any key to use your weapon, or 1 to use your hands.");
            input = Console.ReadLine();
        } else {
            Console.WriteLine("You don't have a weapon that can be used against this card. Using hands.");
        }
        switch (input)
        {
            case "1":
                Console.WriteLine($"You took {damage} damage.");
                health -= damage;
                break;
            default:
                int reducedDamage = (damage - equippedWeapon.value) < 0 ? 0 : damage - equippedWeapon.value;
                Console.WriteLine($"You took {reducedDamage} damage.");
                health -= reducedDamage;
                break;
        }
        checkHealth();
    }
}