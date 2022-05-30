using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blackjack.Models
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
            Cards = createShuffledDeck();
            
        }


        public List<Card> shuffleDeck(List<Card> cards)
        {
            Random rnd = new Random();
            List<Card> shuffledCards = cards.OrderBy(a => rnd.Next()).ToList();
            return shuffledCards;
        }

        public List<Card> createShuffledDeck()
        {
            string[] suits = { "hearts", "diamonds", "clubs", "spades" };
            string[] names = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
            List<Card> newDeck = new List<Card>();

            foreach (string suit in suits)
            {
                for (int i = 0; i < 13; i++)
                {
                    Card card;
                    if (names[i].Equals("jack") || names[i].Equals("queen") || names[i].Equals("king"))
                    {
                        card = new Card(suit, names[i], 10);
                    }
                    else if (names[i].Equals("ace"))
                    {
                        card = new Card(suit, names[i], 1);
                    }
                    else
                    {
                        card = new Card(suit, names[i], i + 2);
                    }
                    newDeck.Add(card);
                }
                Console.WriteLine(suit);
            }
            List<Card> newShuffledDeck = shuffleDeck(newDeck);
            return newShuffledDeck;
        }

    }
}