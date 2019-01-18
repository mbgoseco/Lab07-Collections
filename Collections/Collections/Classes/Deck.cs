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

        public void AddCard(T card)
        {
            if (currentIndex >= cards.Length)
            {
                Array.Resize(ref cards, cards.Length + 52);
            }
            cards[currentIndex] = card;
            currentIndex++;
        }

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
