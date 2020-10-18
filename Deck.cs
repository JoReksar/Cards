using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Modelling_Project
{
    static class Deck
    {
        public static int CountCards => CurrentDeck.Count;
        public static bool IsInfinite { get; set; } = false;
        private static List<Card> CurrentDeck { get; set; } = new List<Card>();

        private static readonly List<Card> originalDeck = new List<Card>();
        private static readonly Random generator = new Random();

        static Deck()
        {
            Array suits = Enum.GetValues(typeof(Suit));
            Array ranks = Enum.GetValues(typeof(Rank));

            foreach (Suit suit in suits)
                foreach (Rank rank in ranks)
                {
                    Image image = new Image() { Source = new BitmapImage(new Uri(Path.GetFullPath($"../../Cards/{suit.ToString().ToLower()}_{rank.ToString().ToLower()}.jpg"))) };
                    originalDeck.Add(new Card(suit, rank, image));
                }

            CurrentDeck = new List<Card>(originalDeck);
        }

        public static void ResetDeck()
        {
            CurrentDeck = new List<Card>(originalDeck);
        }
        public static void ShuffleDeck()
        {
            CurrentDeck = CurrentDeck.OrderBy(card => generator.Next()).ToList();
        }
        public static Card DrawCard()
        {
            Card currentCard = CurrentDeck.First();

            if(IsInfinite)
            {
                CurrentDeck.Add(currentCard);
            }

            CurrentDeck.Remove(currentCard);
            return currentCard;
        }
    }
}
