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

            Console.WriteLine($"Dealer has {dealer.CountCards(dealer)} cards");
            Console.WriteLine();
            Deal(dealer, playerOne, playerTwo);
            Console.WriteLine($"Player One has {playerOne.CountCards(playerOne)} cards");
            Console.WriteLine();
            Console.WriteLine($"Player Two {playerTwo.CountCards(playerTwo)} cards");
            Console.WriteLine();
            Console.WriteLine($"Dealer has {dealer.CountCards(dealer)} cards");


        }

        public static void Deal(Deck<Card> dealer, Deck<Card> p1, Deck<Card> p2)
        {
            //for (int i = 0; i < dealer.CountCards(dealer); i++)
            //{
            //    p1.AddCard(card);
            //}

            int counter = 2;
            
            foreach (Card card in dealer)
            {
                if (counter % 2 == 0)
                {
                    p1.AddCard(card);
                    counter++;
                }
                else
                {
                    p2.AddCard(card);
                    counter++;
                }
            }
        }
    }
}
