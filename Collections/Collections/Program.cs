using System;
using System.Collections.Generic;
using Collections.Classes;

namespace Collections
{
    public class Program
    {
        static void Main(string[] args)
        {
            Deck<Card> dealer = new Deck<Card>();

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

            dealer.CountCards(dealer);
        }
    }
}
