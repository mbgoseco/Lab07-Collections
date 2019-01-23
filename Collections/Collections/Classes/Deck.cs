using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections.Classes
{
    public class Deck<T> : IEnumerable<T>
    {
        public T[] cards = new T[52];
        public int currentIndex = 0;

        /// <summary>
        /// Adds a created Card object to a given deck. Increases the array size of cards in a deck if its size is exceeded.
        /// </summary>
        /// <param name="card">New Card object</param>
        public void AddCard(T card)
        {
            if (currentIndex >= cards.Length)
            {
                Array.Resize(ref cards, cards.Length + 52);
            }
            cards[currentIndex] = card;
            currentIndex++;
        }

        /// <summary>
        /// Removes a specific card from a deck matching the suit and value if it exists in the deck.
        /// </summary>
        /// <param name="card">Target card to remove</param>
        public void RemoveCard(T card)
        {
            bool cardExists = false;
            T[] newArr = new T[cards.Length - 1];
            int counter = 0;

            foreach (T item in cards)
            {
                if (item != null)
                {
                    if (!card.Equals(item))
                    {
                        newArr[counter] = item;
                        counter++;
                    } else
                    {
                        currentIndex--;
                        cardExists = true;
                    }
                }
            }
            if (!cardExists)
            {
                throw new Exception("Cannot remove card that is not in player's deck.");
            }

            cards = newArr;
        }

        /// <summary>
        /// Loops through an entre deck list, displays each card to the console, and returns the total number of cards
        /// </summary>
        /// <param name="deck">Deck of Card objects</param>
        /// <returns>Total number of cards</returns>
        public int CountCards(Deck<Card> deck)
        {
            foreach (Card card in deck)
            {
                switch (Enum.GetName(typeof(Suit), card.Suit))
                {
                    case "Spades":
                        Console.Write($"[{card.Value} ♠]");
                        break;
                    case "Clubs":
                        Console.Write($"[{card.Value} ♣]");
                        break;
                    case "Diamonds":
                        Console.Write($"[{card.Value} ♦]");
                        break;
                    case "Hearts":
                        Console.Write($"[{card.Value} ♥]");
                        break;
                }
            }
            Console.WriteLine();
            return deck.currentIndex;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                yield return cards[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
