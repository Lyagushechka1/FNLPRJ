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
    public class WarGame
    {
        private List<Card> player1Deck;
        private List<Card> player2Deck;

        public WarGame()
        {
            Deck deck = new Deck();
            player1Deck = new Queue<Card>(deck.Deal(18));
            player2Deck = new Queue<Card>(deck.Deal(18));
        }

        public (Card, Card, string) PlayRound()
        {
            if (player1Deck.Count == 0 || player2Deck.Count == 0)
            {
                return (null, null, "Game over!");
            }

            Card player1Card = player1Deck.Dequeue();
            Card player2Card = player2Deck.Dequeue();
            string result;

            if (player1Card.Value > player2Card.Value)
            {
                player1Deck.Enqueue(player1Card);
                player1Deck.Enqueue(player2Card);
                result = "Player 1 wins this round!";
            }
            else if (player1Card.Value < player2Card.Value)
            {
                player2Deck.Enqueue(player1Card);
                player2Deck.Enqueue(player2Card);
                result = "Player 2 wins this round!";
            }
            else
            {
                result = "War! No winner for this round.";
            }

            return (player1Card, player2Card, result);
        }

        public int GetPlayer1DeckCount()
        {
            return player1Deck.Count;
        }

        public int GetPlayer2DeckCount()
        {
            return player2Deck.Count;
        }
    }
}
