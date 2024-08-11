﻿using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TwoDecks
{
    class Deck : INotifyPropertyChanged
    {
        private readonly Random random = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Card> Cards { get; private set; } = new ObservableCollection<Card>();

        public Deck(bool fillDeck)
        {
            if (fillDeck) FillDeck();
        }

        public void FillDeck()
        {
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    Cards.Add(new Card((Values)value, (Suits)suit));
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }
        public void Add(Values value, Suits suit)
        {
            Cards.Add(new Card(value, suit));
        }

        public void Remove(int index)
        {
            Cards.RemoveAt(index);
        }
        public void Remove(Card card)
        {
            Remove(card.Value, card.Suit);
        }
        public void Remove(Values value, Suits suit)
        {
            var cardsToRemove = Cards.Where(x => x.Value == value && x.Suit == suit).ToList();
            foreach (var card in cardsToRemove) Cards.Remove(card);
        }

        public void ShuffleDeck()
        {
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                (Cards[n], Cards[k]) = (Cards[k], Cards[n]);
            }
        }

        public void SortBySuit()
        {
            var sortedCards = Cards.OrderBy(card => card.Suit).ToList();
            Cards.Clear();
            foreach (var card in sortedCards) Cards.Add(card);
        }

        public void SortByValue()
        {
            var sortedCards = Cards.OrderBy(card => card.Value).ToList();
            Cards.Clear();
            foreach (var card in sortedCards) Cards.Add(card);
        }

        public void SortBySuitAndValue()
        {
            List<Card> sortedCards = new List<Card>();
            foreach (var suit in Enum.GetValues(typeof(Suits)))
            {
                var suitCards = Cards.Where(c => c.Suit == (Suits)suit).OrderBy(c => c.Value);
                foreach (var suitCard in suitCards) sortedCards.Add(suitCard);
            }
            Cards.Clear();
            foreach (var card in sortedCards) Cards.Add(card);
        }

        public void PrintCards()
        {
            for (int i = 0; i < Cards.Count; i++) Console.WriteLine(Cards[i]);
        }

        public void Clear()
        {
            Cards.Clear();
        }

        public void Reset()
        {
            Cards.Clear();
            FillDeck();
        }
    }
}