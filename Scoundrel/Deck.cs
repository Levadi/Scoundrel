using System;

namespace Scoundrel;

public static class Deck
{
    public static List<Card> cards = new List<Card>();
    public static Stack<Card> deck = new Stack<Card>();

    public static void createDeck()
    {
        for (int i = 2; i <= 14; i++)
        {
            cards.Add(new Black(i, 0));
            cards.Add(new Black(i, 1));
            if (i < 10) 
            {
                cards.Add(new Heart(i));
                cards.Add(new Diamond(i));
            }
        }
        shuffleDeck();
    }

    private static void shuffleDeck()
    {
        Random rand = new Random();
        deck = new Stack<Card>(cards.OrderBy(x => rand.Next()));
    }

    public static Card? drawCard()
    {
        if (deck.Count == 0) return null;
        return deck.Pop();
    }

    public static void runAway(List<Card> room)
    {
        cards = deck.ToList();
        foreach (Card card in room)
        {
            cards.Add(card);
        }
        deck = new Stack<Card>(cards.AsEnumerable().Reverse());
        Room.clearRoom();
        Room.generateRoom();
    }
}
