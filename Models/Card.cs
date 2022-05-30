using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blackjack.Models
{
    public class Card
    {

        public string Suit { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public Card(string suit, string name, int value)
        {
            Suit = suit;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name} of {Suit}";
        }

    }
}