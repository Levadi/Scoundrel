namespace Scoundrel;

public class Program
{
    public static void Main(string[] args)
    {
        Hand.health = 20;
        Hand.healed = false;

        Diamond diamond = new Diamond(5);
        Black club = new Black(12, 0);
        Black spade = new Black(11, 1);
        Heart heart = new Heart(5);

        club.playCard();
        diamond.playCard();
        spade.playCard();
        heart.playCard();
        heart.playCard(); // Should not heal again
    }
}

