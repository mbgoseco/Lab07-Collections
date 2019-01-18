using System;
using System.Collections;
using System.Collections.Generic;
using Collections.Classes;

namespace Collections
{
    public class Program
    {
        static void Main(string[] args)
        {
            Deck<Card> dealer = new Deck<Card>();
            Deck<Card> playerOne = new Deck<Card>();
            Deck<Card> playerTwo = new Deck<Card>();

            for (int i = 0; i < Enum.GetValues(typeof(Suit)).Length; i++)
            {
                for (int j = 0; j < Enum.GetValues(typeof(Value)).Length; j++)
                {
                    Suit suit = (Suit)Enum.Parse(typeof(Suit), Enum.GetName(typeof(Suit), i));
                    Value value = (Value)Enum.Parse(typeof(Value), Enum.GetName(typeof(Value), j));
                    Card card = new Card(suit, value);
                    dealer.AddCard(card);
                }
            }
            Card another = new Card(Suit.Hearts, Value.Ten);
                    dealer.AddCard(another);

            Console.WriteLine($"Dealer has {dealer.CountCards(dealer)} cards");
            Console.WriteLine();
            Console.WriteLine("Dealing Cards...");
            Console.WriteLine();
            Deal(dealer, playerOne, playerTwo);
            Console.WriteLine($"Player One has {playerOne.CountCards(playerOne)} cards");
            Console.WriteLine();
            Console.WriteLine($"Player Two has {playerTwo.CountCards(playerTwo)} cards");
            Console.WriteLine();
            Console.WriteLine($"Dealer has {dealer.CountCards(dealer)} cards");
            Console.WriteLine();


        }

        public static void Deal(Deck<Card> dealer, Deck<Card> p1, Deck<Card> p2)
        {
            int counter = 2;
            
            for (int i = dealer.currentIndex - 1; i >= 0; i--)
            {
                if (counter % 2 == 0)
                {
                    p1.AddCard(dealer.cards[i]);
                    dealer.RemoveCard(dealer.cards[i]);
                    counter++;
                }
                else
                {
                    p2.AddCard(dealer.cards[i]);
                    dealer.RemoveCard(dealer.cards[i]);
                    counter++;
                }
                if (i == 1 && p1.currentIndex == p2.currentIndex)
                {
                    return;
                }
            }
        }
    }
}
