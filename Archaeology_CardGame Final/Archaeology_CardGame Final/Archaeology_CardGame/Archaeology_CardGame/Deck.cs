using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Archaeology_CardGame
{
    public class Deck
    {
        protected List<Card> _cards;
        public Deck()
        {
            _cards = new List<Card>();
            for(var i = 0; i < 18; i++) AddCard(new Shard());
            for (var i = 0; i < 16; i++) AddCard(new Scrap());
            for (var i = 0; i < 14; i++) AddCard(new Coin());
            for (var i = 0; i < 8; i++) AddCard(new Talisman());
            for (var i = 0; i < 6; i++) AddCard(new Cup());
            for (var i = 0; i < 4; i++) AddCard(new Mask());
        }

        private void AddCards(Card card)
        {
            for (var k = 1; k <= card.CardNum; k++) AddCard(card);
        }
        public int Count => _cards.Count;

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        private static void Shuffle<T>(List<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public void Shuffle()
        {
            Shuffle(_cards);
        }

        public Card Dig()
        {
            var drawnCard = _cards[0];
            _cards.Remove(drawnCard);
            return drawnCard;
        }
    }
}