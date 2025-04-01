using System;

namespace Scoundrel;

public static class Game
{
    public static void displayCards()
    {
        int cardIndex = 1;
        Console.WriteLine("Cards in the room:");
        foreach (Card card in Room.room)
        {
            Console.WriteLine($"{cardIndex}. {card.faceName} of {card.suitName}");
            cardIndex++;
        }
    }

    public static void askRunAway()
    {
        Console.WriteLine("Do you want to run away? (y/n)");
        string? input = Console.ReadLine();
        if (input == "y") {
            Deck.runAway(Room.room);
            displayCards();
        }
    }

    public static void makeChoice()
    {
        Console.WriteLine("Choose a card to play (1-4): ");
        string? input = Console.ReadLine();
        int choice = int.Parse(input) - 1;
        if (choice < 0 || choice >= Room.room.Count) {
            Console.WriteLine("Invalid choice. Please choose a number between 1 and 4.");
            makeChoice();
        }
        Card chosenCard = Room.room[choice];
        chosenCard.playCard();
    }
    public static void startGame()
    {
        Deck.createDeck();
        while (Deck.deck.Count + Room.numberOfCards > 0) {
            Room.generateRoom();
            displayCards();
            if (Room.numberOfCards == 4) askRunAway();
            makeChoice();
        }
        Console.WriteLine("You won!");
        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();
        Environment.Exit(0);
    }
}
