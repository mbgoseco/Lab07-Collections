using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections.Classes
{
    public class Deck<T> : IEnumerable<T>
    {
        T[] cards = new T[1];
        int currentIndex = 0;

        public void AddCard(T card)
        {
            if (currentIndex < cards.Length)
            {
                Array.Resize(ref cards, cards.Length + 1);
            }
            cards[currentIndex] = card;
            currentIndex++;
        }

        public void RemoveCard(T card)
        {
            Array.Reverse(cards);
            Array.Resize(ref cards, cards.Length - 1);
            Array.Reverse(cards);
            currentIndex--;
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
