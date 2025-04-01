using System;

namespace Scoundrel;

public static class Room
{
    public static List<Card> room = new List<Card>();
    public static int roomNumber { get; set; } = 0;
    public static int numberOfCards { get; set; } = 0;
    public static void generateRoom() 
    {
        if (numberOfCards > 1) return;
        while (numberOfCards < 4)
        {
            if (Deck.deck.Count == 0) break;
            room.Add(Deck.drawCard());
            numberOfCards++;
        }
        Hand.healed = false;
        Console.WriteLine($"You are in room {roomNumber}.");
        roomNumber++;
    }
    public static void removeCard(Card card)
    {
        room.Remove(card);
        numberOfCards--;
        generateRoom();
    }

    public static void clearRoom()
    {
        room.Clear();
        numberOfCards = 0;
    }
}
