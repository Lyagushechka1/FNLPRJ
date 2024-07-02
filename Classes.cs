using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Game_
{
    public class Card
    {
        public int Value { get; set; }  
        public string Suit { get; set; }
        public Card(int value, string suit) 
        {
            Value = value;
            Suit = suit;
        }
        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
    public class Deck
    {
        List<Card> cards = new List<Card>();
        public Deck() 
        { 
            string[] suit = { "Hearts", "Diamonds", "Clubs", "Spades" };
            for (int i = 0; i <= 13; i++)
            {
                foreach (string suit2 in suit)
                {
                    cards.Add(new Card(i, suit2));
                    Console.WriteLine("Card Edded");
                }
            }
            Shuffle();
        }
        public void Shuffle()
        {
            Random random = new Random();
            cards = cards.OrderBy(c => random.Next()).ToList();
        }
        public List<Card> Deal(int numberOfCards)
        {
            List<Card> hand = cards.Take(numberOfCards).ToList();
            cards.RemoveRange(0, numberOfCards);
            return hand;
        }
    }
    public class  WarGame
    {
        public List<Card> player1;
        public List<Card> player2;
        public WarGame()
        {
            Deck deck = new Deck(); 
            player1 = deck.Deal(26);
            player2 = deck.Deal(26);
        }
        public string PlayRound()
        {
            if (player1.Count == 0 || player2.Count == 0)
            {
                return "Game over!";
            }

            Card player1Card = player1[0];
            Card player2Card = player2[0];
            player1.RemoveAt(0);
            player2.RemoveAt(0);

            if (player1Card.Value > player2Card.Value)
            {
                player1.Add(player1Card);
                player2.Add(player2Card);
                return "Player 1 wins this round!";
            }
            else if (player1Card.Value < player2Card.Value)
            {
                player2.Add(player1Card);
                player2.Add(player2Card);
                return "Player 2 wins this round!";
            }
            else
            {
                return "War!";
            }
        }
    }
}
