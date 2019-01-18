using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Collections;
using Collections.Classes;

namespace XUnitTestCollections
{
    public class UnitTest1
    {
        // Test that a card is added to a deck
        [Fact]
        public void CardIsAddedToDeck()
        {
            Deck<Card> testDeck = new Deck<Card>();
            Card card = new Card(Suit.Clubs, Value.King);
            testDeck.AddCard(card);

            Assert.Equal(Suit.Clubs, testDeck.cards[0].Suit);
            Assert.Equal(Value.King, testDeck.cards[0].Value);
        }

        // Test that a card is added to a deck
        [Fact]
        public void CardHasProperties()
        {
            Card card = new Card(Suit.Diamonds, Value.Queen);

            Assert.Equal(Suit.Diamonds, card.Suit);
            Assert.Equal(Value.Queen, card.Value);
        }

        // Test that a card that exists in a deck can be removed
        [Fact]
        public void RemoveCardInDeck()
        {
            Deck<Card> testDeck = new Deck<Card>();
            Card cardOne = new Card(Suit.Hearts, Value.Nine);
            Card cardTwo = new Card(Suit.Spades, Value.Ace);
            testDeck.AddCard(cardOne);
            testDeck.AddCard(cardTwo);

            testDeck.RemoveCard(testDeck.cards[0]);

            Assert.Equal(Suit.Spades, testDeck.cards[0].Suit);
            Assert.Equal(Value.Ace, testDeck.cards[0].Value);
        }

        // Test that a card that does NOT exist in a deck cannot be removed
        [Fact]
        public void RemoveCardNotInDeck()
        {
            Deck<Card> testDeck = new Deck<Card>();
            Card card = new Card(Suit.Hearts, Value.Ace);
            testDeck.AddCard(card);

            Card notCard = new Card(Suit.Diamonds, Value.Five);
            
            Exception ex = Assert.Throws<Exception>(() => testDeck.RemoveCard(notCard));

            Assert.Equal("Cannot remove card that is not in player's deck.", ex.Message);
        }
    }
}
